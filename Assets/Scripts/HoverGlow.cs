using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using UnityEngine;

public class HoverGlow : MonoBehaviour
public class HoverHighlight : MonoBehaviour
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

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        bool isHovering = hit.collider != null && hit.collider.gameObject == gameObject;

        if (isHovering) {
            Console.WriteLine("hit");
            sr.color = highlightColor; }
        else {
            Console.WriteLine("hit");
            sr.color = originalColor;
        }
    }
}