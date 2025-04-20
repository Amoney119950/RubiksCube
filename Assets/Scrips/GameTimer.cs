using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Assign your TextMeshPro UI element here
    private float elapsedTime = 0f;
    private bool isTimerRunning = false;

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime; // Increment time
            UpdateTimerUI(); // Update the displayed timer text
        }
    }

    // Start the timer
    public void StartTimer()
    {
        isTimerRunning = true;
        elapsedTime = 0f; // Reset timer if necessary
    }

    // Stop the timer
    public void StopTimer()
    {
        isTimerRunning = false;
    }

    // Update the text on the UI
    private void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60); // Calculate minutes
        int seconds = Mathf.FloorToInt(elapsedTime % 60); // Calculate seconds
        timerText.text = $"{minutes:00}:{seconds:00}"; // Format time as MM:SS
    }
}
