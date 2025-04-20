using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class CubeCompletion : MonoBehaviour
{
    public Button completeButton;
    private CubeState cubeState;
    private ReadCube readCube;

    void Start()
    {
        this.cubeState = FindObjectOfType<CubeState>();
        this.readCube = FindObjectOfType<ReadCube>();

        // Initially hide the complete button
        if (this.completeButton != null)
        {
            this.completeButton.gameObject.SetActive(true);
            this.completeButton.onClick.AddListener(OnCompleteButtonClick);
        }
    }

    void Update()
    {
        if (!CubeState.autoRotating && CubeState.started && !PivotRotationIsInProgress())
        {
            CheckIfSolved();
        }
    }

    bool PivotRotationIsInProgress()
    {
        PivotRotation pivotRotation = FindObjectOfType<PivotRotation>();
        return pivotRotation != null && pivotRotation.IsRotating();
    }


    void CheckIfSolved()
    {
        this.readCube.ReadState();
        bool isSolved = IsCubeSolved();

        if (isSolved && this.completeButton != null)
        {
            this.completeButton.gameObject.SetActive(true);
        }
    }

    bool IsCubeSolved()
    {
        // Check if all faces match their center piece
        return AreFacesComplete(this.cubeState.up) &&
               AreFacesComplete(this.cubeState.down) &&
               AreFacesComplete(this.cubeState.left) &&
               AreFacesComplete(this.cubeState.right) &&
               AreFacesComplete(this.cubeState.front) &&
               AreFacesComplete(this.cubeState.back);
    }

    bool AreFacesComplete(List<GameObject> face)
    {
        // Get the center piece color (index 4 is the center)
        string centerColor = face[4].name[0].ToString();

        // Check if all pieces match the center
        foreach (GameObject piece in face)
        {
            if (piece.name[0].ToString() != centerColor)
            {
                return false;
            }
        }
        return true;
    }

    void OnCompleteButtonClick()
    {
        // Load the completion scene
        SceneManager.LoadScene("CompleteScene");
    }
}