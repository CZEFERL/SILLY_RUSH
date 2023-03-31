using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{

    public GameObject LosePanel;

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.Lives <= 0)
            Lose();
    }


    public void Lose()
    {
        LosePanel.SetActive(true);
        Time.timeScale = 0f;
    }


    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 0f;
    }


    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }


}
