using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartScript : MonoBehaviour
{
    public GameObject Button;

    public bool StartFlag = false;

    public void StartScene()
    {
        if (Time.timeScale == 0f)
            Time.timeScale = 1f;
        Destroy(Button.gameObject);

    }

}
