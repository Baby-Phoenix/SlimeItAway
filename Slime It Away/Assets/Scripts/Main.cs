using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static bool isPlayAgain = false;
    public void Play()
    {
        if (!isPlayAgain)
            SceneManager.LoadScene("Tutorial");

        else
            SceneManager.LoadScene("Forest");

    }
    public void Exit()
    {
        Application.Quit();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Main");
        isPlayAgain = true;
    }
}
