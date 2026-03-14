using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using UnityEngine;

public class HoverGlow : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;
    private Color OriginalColor;
    public Color HOVERCOLOR = OriginalColor;

    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        OriginalColor = SpriteRenderer.color;
        HOVERCOLOR *= 1.5f;
    }

    void mouseEnter(Color hoverColor)
    {
        SpriteRenderer.color = hoverColor;
    }

    void mouseExit(Color originalColor)
    {
        SpriteRenderer.color = originalColor;
    }

    void OnMouseOver()
    {
        mouseEnter(HOVERCOLOR);
        
        Console.WriteLine("Mouse over on " + gameObject.name);
    }

    void OnMouseExit()
    {
        mouseExit(OriginalColor);
        
    }

    void Update()
    {

    }
}
