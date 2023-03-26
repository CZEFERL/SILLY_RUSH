using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [Header("Other")]
    public GameObject shopPanel;
    public GameObject AllCell;

    [Header("Building")]
    public GameObject dot;
    public GameObject dot2;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void Cancel()
    {
        shopPanel.SetActive(false);
        for (int i = 0; i < AllCell.transform.childCount; i++)
        {
            if (AllCell.transform.GetChild(i).GetComponent<BuildManager>().activeCell == true)
            {
                AllCell.transform.GetChild(i).GetComponent<BuildManager>().activeCell = false;
                break;
            }
        }
    }

    public void BuildDot()
    {
        for (int i = 0; i < AllCell.transform.childCount; i++)
        {
            if (AllCell.transform.GetChild(i).GetComponent<BuildManager>().activeCell == true && AllCell.transform.GetChild(i).GetComponent<BuildManager>().building == false)
            {
                AllCell.transform.GetChild(i).GetComponent<BuildManager>().setBuild(dot);
            }
        }

    }
}
