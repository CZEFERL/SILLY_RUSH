using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScripts : MonoBehaviour
{
    public int playerHealth;
    public Text healthText;

    void Start()
    {
        healthText.text = playerHealth.ToString();
    }
    void Update()
    {

    }
    public void ChangeHelth(int count)
    {
        playerHealth += count;
        healthText.text = playerHealth.ToString();

    }
}