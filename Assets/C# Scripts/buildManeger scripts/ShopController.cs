using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{

    public GameObject shopPanel;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void Cancel()
    {
        shopPanel.SetActive(false);
    }
}
