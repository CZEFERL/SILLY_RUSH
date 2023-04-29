using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehavior : MonoBehaviour
{
    public Slider slider;
    public Color low = Color.red;
    public Color high = Color.green;
    public Vector3 offset;

    public void Start()
    {
        transform.gameObject.GetComponent<Canvas>().worldCamera = Camera.main;
    }
    public void SetHealth(int health, int maxHealth)
    {
        slider.gameObject.SetActive(health < maxHealth);

        slider.value = health;
        slider.maxValue = maxHealth;
        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }

    public void Update()
    {
        slider.transform.position = transform.parent.position + offset;
    }
}
