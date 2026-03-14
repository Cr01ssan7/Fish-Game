using System;
using System.Runtime.Serialization;
using UnityEngine;

public class HoverGlow : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;
    private Color OriginalColor;
    public Color HOVERCOLOR = Color.rgb(255, 255, 255, 50);

    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        OriginalColor = SpriteRenderer.color;
    }

    void mouseEnter(int hoverColor)
    {
        SpriteRenderer.color = hoverColor;
    }

    void mouseExit(int originalColor)
    {
        SpriteRenderer.color = originalColor;
    }

    OnMouseOver() {
        mouseEnter(HOVERCOLOR);
    }

    OnMouseExit()
    {
        mouseExit(OriginalColor);
    }

    void Update()
    {

}
