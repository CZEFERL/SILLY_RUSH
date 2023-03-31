using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public GameObject shopPanel;

    void OnMouseDown()
    {
        if (shopPanel.activeInHierarchy)
            return;

        shopPanel.SetActive(true);
        ShopController.place = gameObject.gameObject;
    }
}