using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using UnityEngine;

public class HoverGlow : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Color hoverColor;

    [Range(1f, 3f)]
    public float brightness = 1.5f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Store the original color
        originalColor = spriteRenderer.color;

        // Create a brightened version
        hoverColor = originalColor * brightness;
    }

    void OnMouseEnter()
    {
        spriteRenderer.color = hoverColor;
    }

    void OnMouseExit()
    {
        spriteRenderer.color = originalColor;
    }

}