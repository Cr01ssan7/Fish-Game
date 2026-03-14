using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using UnityEngine;

public class HoverGlow : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color originalColor;
    private Color highlightColor;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        highlightColor = originalColor * 1.5f;
    }

    void OnMouseEnter()
    {
        sr.color = highlightColor;
        Debug.Log("ENTER");
    }

    void OnMouseExit()
    {
        sr.color = originalColor;
        Debug.Log("EXIT");
    }
}