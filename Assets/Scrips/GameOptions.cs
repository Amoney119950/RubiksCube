using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOptions : MonoBehaviour
{
    public void EnterGame()
    {
        SceneManager.LoadScene("Game 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void TitleScreen()
    {
        SceneManager.LoadScene("Title");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
