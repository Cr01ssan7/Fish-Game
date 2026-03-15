using UnityEngine;
using TMPro;

public class SimulationDisplay : MonoBehaviour
{
    public FishSimulation Simulation;

    public TextMeshProUGUI fishCaughtText;
    public TextMeshProUGUI hoursText;
    public TextMeshProUGUI cashText;

    void Start()
    {
        if (Simulation == null)
        {
            Simulation = FindObjectOfType<FishSimulation>();
        }
        Refresh();
    }

    void Update()
    {
        if (Simulation == null)
        { 
            Simulation = FindObjectOfType<FishSimulation>();
        }
        if (Simulation != null)
        {
            Refresh();
        }
    }

    void Refresh()
    {
        if (fishCaughtText != null)
        {
            fishCaughtText.text = Simulation != null ? Simulation.fishCaught.ToString() : "N/A";
        }
        if (hoursText != null)
        {
            hoursText.text = Simulation != null ? Simulation.hours.ToString() : "N/A";
        }
        if (cashText != null)
        {
            cashText.text = Simulation != null ? Simulation.cash.ToString() : "N/A";
        }

    }
}
