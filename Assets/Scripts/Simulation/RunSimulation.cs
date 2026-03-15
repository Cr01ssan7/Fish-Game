using System.Runtime.Serialization;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneInitializer : MonoBehaviour
{
    public string targetSceneName = "S_Nemo's Nook";

    public GameObject simulationPrefab;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != targetSceneName)
            return;
        if (simulationPrefab != null)
        {
            GameObject go = Instantiate(simulationPrefab);
            var sim = go.GetComponent<FishSimulation>();
            if (sim != null)
            {
                var display = Object.FindFirstObjectByType<SimulationDisplay>();
                if (display != null)
                {
                    display.Simulation = sim;
                }

                sim.RunSimulation();
            } 
            else
            {
                Debug.Log("Error: Simulation prefab does not have a Fish Simulation component.");
            }
        } else
        {
            GameObject go = new GameObject("FishSimulation");
            var sim = go.AddComponent<FishSimulation>();
            sim.RunSimulation();
        }
    }
}
