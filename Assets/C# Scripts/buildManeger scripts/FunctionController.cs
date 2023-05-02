using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionController : MonoBehaviour
{
    public static GameObject pole = null;

    public void setDelete(GameObject empty)
    {
        Destroy(pole);
        PlayerStats.Money += (pole.GetComponent<TowerScripts>().money) / 2;
        Instantiate(empty, pole.transform.position, pole.transform.rotation);
        gameObject.SetActive(false);

    }
}
