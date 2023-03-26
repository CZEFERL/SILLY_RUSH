using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public bool building;
    public GameObject shopPanel;
    public bool road;
    public bool activeCell;


    void Start()
    {
        
    }


    void Update()
    {
        if (shopPanel.active)
            return;

        if (Input.GetKeyDown(KeyCode.Mouse0) && transform.GetChild(0).GetComponent<Image>().color == Color.green)
        {
            if (road == false)
            {
                shopPanel.SetActive(true);
                activeCell = true;
            }
        }
    }

    void OnMouseEnter()
    {
        if (shopPanel.active)
            return;

        if (building == true)
            transform.GetChild(0).GetComponent<Image>().color = Color.red;
        else
            transform.GetChild(0).GetComponent<Image>().color = Color.green;
    }

    void OnMouseExit()
    {
        transform.GetChild(0).GetComponent<Image>().color = Color.white; 
    }


    public void setBuild(GameObject build)
    {

        Instantiate(build).transform.position = transform.GetChild(1).transform.position;
        building = true;
        activeCell = false;
    }
}
