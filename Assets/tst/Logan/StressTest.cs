using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Spawn objects until a certain threshold is passed
// selectable thresholds:
//      fps < 30 five times
//      cpu utilization > 80% five times within one minute
//      until blocks push through the walls of the container

public class StressTest : MonoBehaviour
{
    public Text fpsText;
    private float deltaTime;

    void Start()
    {
    }

    void Update()
    {
        UpdateFPS();
    }

    void UpdateFPS()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil (fps).ToString();
    }
}
