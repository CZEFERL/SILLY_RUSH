using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneChangeSprite : MonoBehaviour
{
    private Enemy plane;
    private SpriteRenderer spriteRenderer;
    public Sprite damagedPlane;

    private void Start()
    {
        plane = gameObject.GetComponent<Enemy>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (plane.health < plane.maxHealth * 0.4f)
        {
            spriteRenderer.sprite = damagedPlane;
            enabled = false;
        }
    }
}
