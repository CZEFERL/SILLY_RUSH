using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{

    public GameObject WinPanel;


    public void Win()
    {
        WinPanel.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }


    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 0f;
    }


    public void NextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }


    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
