using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HoverTipManager : MonoBehaviour
{
    public TextMeshProUGUI TIPTEXT;
    public RectTransform TIPWINDOW;
    public Vector3 screenPosition;

    public static Action<string, Vector2> OnMouseHover;
    public static Action OnMouseLoseFocus;

    private void OnEnable()
    {
        OnMouseHover += ShowTip;
        OnMouseLoseFocus += HideTip;
    }

    void update()
    {
        screenPosition = Input.mousePosition;
    }

    private void OnDisable()
    {
        OnMouseHover -= ShowTip;
        OnMouseLoseFocus -= HideTip;
    }

    void Start()
    {
        HideTip();
    }

    private void ShowTip(string tip, Vector2 mousePos)
    {
        TIPTEXT.text = tip;
        TIPWINDOW.sizeDelta = new Vector2(TIPTEXT.preferredWidth > 200 ? 200 : TIPTEXT.preferredWidth, TIPTEXT.preferredHeight);

        TIPWINDOW.gameObject.SetActive(true);
        TIPWINDOW.transform.position = new Vector2(mousePos.x + TIPWINDOW.sizeDelta.x, mousePos.y + TIPWINDOW.sizeDelta.y);
    }

    private void HideTip()
    {
        TIPTEXT.text = default;
        TIPWINDOW.gameObject.SetActive(false);
    }
}