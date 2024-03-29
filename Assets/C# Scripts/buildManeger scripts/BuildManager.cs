using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public GameObject shopPanel;
    private GameObject FunctionPanel;

    private void Awake()
    {
        shopPanel = GameObject.Find("Canvas").transform.Find("Shop").gameObject;
        FunctionPanel = GameObject.Find("Canvas").transform.Find("FunctionPanel").gameObject;
    }

    void OnMouseDown()
    {
        if (shopPanel.activeInHierarchy)
            return;

        if (FunctionPanel.activeInHierarchy)
            return;

        if (Time.timeScale == 0 && GameObject.Find("StartScene").GetComponent<StartScript>().StartFlag)
            return;

        GetComponent<AudioSource>().Play();
        shopPanel.SetActive(true);
        ShopController.place = gameObject;
    }
}