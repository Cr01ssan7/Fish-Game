using UnityEngine;

using UnityEngine;

public class FishSimulation : MonoBehaviour
{
    [Header("Fish Settings")]
    public int maxFish = 500;                 // Permanent

    [Header("Random Ranges")]
    public int minFishCaught = 100;
    public int maxFishCaught = 300;

    public int minHours = 1;
    public int maxHours = 10;

    [Header("Risk Settings")]
    public float riskFactor = 1f;             // Multiplier for (FishCaught/100 * Hours)
    public float riskPercentage = 30f;        // Chance out of 100

    [Header("Value Settings")]
    public int minValue = 5;                  // Value per fish (random range)
    public int maxValue = 20;

    [Header("Permanent Cash")]
    public int cash = 0;                      // Permanent during play

    [Header("Last Run Results (Read Only)")]
    public int fishCaught;
    public int hours;
    public float fishPerHour;
    public float calculatedRiskFactor;
    public bool riskOccurred;

    public int value;                         // Random value per fish
    public int cashGain;                      // fishCaught * value

    // Call this from a UI Button
    public void RunSimulation()
    {
        // Stop simulation if no fish left
        if (maxFish <= 0)
        {
            Console.WriteLine("Simulation stopped: No fish left in the population.");
            return;
        }

        // Randomize fish caught and hours
        fishCaught = Random.Range(minFishCaught, maxFishCaught + 1);
        hours = Random.Range(minHours, maxHours + 1);

        // Randomize fish value
        value = Random.Range(minValue, maxValue + 1);

        // Calculate fish per hour
        fishPerHour = (float)fishCaught / hours;

        // Calculate risk factor
        calculatedRiskFactor = (fishCaught / 100f) * hours * riskFactor;

        // Roll chance
        float roll = Random.Range(0f, 100f);
        riskOccurred = roll < riskPercentage;

        // Apply risk penalty
        if (riskOccurred)
        {
            int loss = Mathf.RoundToInt(calculatedRiskFactor * 10f);
            maxFish -= loss;
            if (maxFish < 0) maxFish = 0;
        }

        // Calculate cash gain
        cashGain = fishCaught * value;

        // Add to permanent cash
        cash += cashGain;

        // Console output
        Console.WriteLine($"Run Complete → Caught {fishCaught} fish in {hours} hours ({fishPerHour:F2}/hr).");
        Console.WriteLine($"Value per fish: {value}. CashGain: {cashGain}. Total Cash: {cash}.");
        Console.WriteLine($"Risk Occurred: {riskOccurred}. MaxFish now = {maxFish}");
    }
}
