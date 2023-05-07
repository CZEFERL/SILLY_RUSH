using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public PauseMenu pauseMenu;
    public GameObject WinPanel;

    public void Win()
    {
        pauseMenu.enabled = false;
        WinPanel.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 0f;
    }


    public void NextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level" + (int.Parse(SceneManager.GetActiveScene().name.ToCharArray()[^1].ToString()) + 1).ToString());
    }


    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
