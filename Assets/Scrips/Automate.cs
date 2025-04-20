using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Automate : MonoBehaviour
{
    public static List<string> moveList = new List<string>() { };
    private readonly List<string> allMoves = new List<string>()
    {
        "U", "D", "L", "R", "F", "B",
        "U2", "D2", "L2", "R2", "F2", "B2",
        "U'", "D'", "L'", "R'", "F'", "B'"
    };

    private CubeState cubeState;
    private ReadCube readCube;
    private bool isShuffling = false;
    private float timer = 0f;
    private bool isTimerRunning = false;
    private Text timerText; // Reference to the Text component for displaying time

    // Start is called before the first frame update
    void Start()
    {
        cubeState = FindObjectOfType<CubeState>();
        readCube = FindObjectOfType<ReadCube>();

        // Find the TimerText UI Text component and check if it's assigned
        timerText = GameObject.Find("TimerText")?.GetComponent<Text>();

        if (timerText == null)
        {
            Debug.LogError("TimerText UI Text component not found in the scene.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (moveList.Count > 0 && !CubeState.autoRotating && CubeState.started)
        {
            // Perform the move at the first index
            DoMove(moveList[0]);
            // Remove the move from the list
            moveList.RemoveAt(0);
        }

        if (isTimerRunning)
        {
            timer += Time.deltaTime; // Increment the timer
            DisplayTime(timer); // Update the UI with the timer
        }
    }

    public void Shuffle()
    {
        List<string> moves = new List<string>();
        int shuffleLength = UnityEngine.Random.Range(10, 30); // Random shuffle length
        for (int i = 0; i < shuffleLength; i++)
        {
            int randomMove = UnityEngine.Random.Range(0, allMoves.Count); // Random move selection
            moves.Add(allMoves[randomMove]);
        }
        moveList = moves;

        // Mark shuffling as done and start the timer
        isShuffling = true;
        StopTimer(); // Ensure timer is reset before shuffle

        // Start the timer once shuffle is complete
        StartTimer();
    }

    void StartTimer()
    {
        isTimerRunning = true; // Start the timer
    }

    void StopTimer()
    {
        isTimerRunning = false; // Stop the timer
    }

    void DisplayTime(float time)
    {
        if (timerText == null) return; // Prevent errors if timerText is null

        int hours = Mathf.FloorToInt(time / 3600);
        int minutes = Mathf.FloorToInt((time % 3600) / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        // Display the time in HH:MM:SS format
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }

    void DoMove(string move)
    {
        readCube.ReadState();
        CubeState.autoRotating = true;
        if (move == "U")
        {
            RotateSide(cubeState.up, -90);
        }
        if (move == "U'")
        {
            RotateSide(cubeState.up, 90);
        }
        if (move == "U2")
        {
            RotateSide(cubeState.up, -180);
        }
        if (move == "D")
        {
            RotateSide(cubeState.down, -90);
        }
        if (move == "D'")
        {
            RotateSide(cubeState.down, 90);
        }
        if (move == "D2")
        {
            RotateSide(cubeState.down, -180);
        }
        if (move == "L")
        {
            RotateSide(cubeState.left, -90);
        }
        if (move == "L'")
        {
            RotateSide(cubeState.left, 90);
        }
        if (move == "L2")
        {
            RotateSide(cubeState.left, -180);
        }
        if (move == "R")
        {
            RotateSide(cubeState.right, -90);
        }
        if (move == "R'")
        {
            RotateSide(cubeState.right, 90);
        }
        if (move == "R2")
        {
            RotateSide(cubeState.right, -180);
        }
        if (move == "F")
        {
            RotateSide(cubeState.front, -90);
        }
        if (move == "F'")
        {
            RotateSide(cubeState.front, 90);
        }
        if (move == "F2")
        {
            RotateSide(cubeState.front, -180);
        }
        if (move == "B")
        {
            RotateSide(cubeState.back, -90);
        }
        if (move == "B'")
        {
            RotateSide(cubeState.back, 90);
        }
        if (move == "B2")
        {
            RotateSide(cubeState.back, -180);
        }
    }

    void RotateSide(List<GameObject> side, float angle)
    {
        // Automatically rotate the side by the angle
        PivotRotation pr = side[4].transform.parent.GetComponent<PivotRotation>();
        pr.StartAutoRotate(side, angle);
    }
}
