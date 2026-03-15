using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private FishSimulation FishSim;
    private int MaxFish;
    public string TIPMESSAGE;
    public float DELAY = 0.5f;

    void Start()
    {
        FishSim = FindFirstObjectByType<FishSimulation>();
        MaxFish = FishSim.maxFish;

        Debug.Log(MaxFish);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(StartTimer());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        HoverTipManager.OnMouseLoseFocus();
    }

    private void ShowMessage()
    {
        HoverTipManager.OnMouseHover(TIPMESSAGE, Input.mousePosition);
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(DELAY);

        ShowMessage();
    }
}