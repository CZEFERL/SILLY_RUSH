using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarScript : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Rotate(Transform enemy)
    {
        if (enemy.position.x - transform.position.x > 0)
            spriteRenderer.sprite = sprite1;
        else
            spriteRenderer.sprite = sprite2;
    }
}
