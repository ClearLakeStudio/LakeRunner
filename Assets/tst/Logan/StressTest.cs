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
    public Text fpsDrop;
    public Text cpuText;
    public Text spawnRateText;
    public Text itemCount;

    public GameObject prefab;
    private int numPrefabs;
    //public float spawnRate = 1;
    public Slider spawnRate;
    public Button fpsButton;
    public Button cpuButton;
    public Button collisionButton;

    public int fpsThreshold;
    private int fpsDropCount;
    private bool busy;
    private float deltaTime;

    void Start()
    {
    }

    void Update()
    {
        UpdateFPS();
        UpdateSpawnRate();
        if (!busy) {
            StartCoroutine(SpawnPrefab(spawnRate.value));
        }
    }

    void UpdateSpawnRate()
    {
        spawnRateText.text = spawnRate.value.ToString();
    }

    void UpdateFPS()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil (fps).ToString();
        if (fps < fpsThreshold) {
            fpsDropCount++;
        }
        fpsDrop.text = fpsDropCount.ToString();
        if (fpsDropCount > 5) {
            //Time.timeScale = 0;
        }
    }

    IEnumerator SpawnPrefab(float time)
    {
        busy = true;
        yield return new WaitForSeconds(time);

        GameObject newObject = Instantiate(prefab);
        if (newObject.transform.position.y > 2) {
            Time.timeScale = 0;
        }
        numPrefabs++;
        itemCount.text = numPrefabs.ToString();
        busy = false;
    }
}
