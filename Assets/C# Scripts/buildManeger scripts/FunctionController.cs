using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionController : MonoBehaviour
{
    public static GameObject pole = null;
    private static int price = 50;

    public void setDelete(GameObject empty)
    {
        Destroy(pole);
        PlayerStats.Money += (pole.GetComponent<TowerScripts>().money) / 2;
        Instantiate(empty, pole.transform.position, pole.transform.rotation);
        gameObject.SetActive(false);
    }

    public void DamageUp()
    {
        if (PlayerStats.Money >= price)
        {
            var script = pole.GetComponent<TowerScripts>();
            script.damage += Mathf.RoundToInt(script.damage * 0.1f);
            script.money += price;
            PlayerStats.Money -= price;
        }
    }

    public void RangeUp()
    {
        if (PlayerStats.Money >= price)
        {
            var script = pole.GetComponent<TowerScripts>();
            script.range *= 1.1f;
            script.money += price;
            PlayerStats.Money -= price;
        }
    }

    public void AttackSpeedUp()
    {
        if (PlayerStats.Money >= price)
        {
            var script = pole.GetComponent<TowerScripts>();
            script.CD *= 0.9f;
            script.money += price;
            PlayerStats.Money -= price;
        }
    }
}
