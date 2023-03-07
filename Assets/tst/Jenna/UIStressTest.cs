using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStressTest : MonoBehaviour
{
    public GameObject prefab;
    private float xBound = 8.49f;
    private float yBound = 4.7f;
    private GameObject pastObject;
    private GameObject newObject;
    private bool spawning = false;
    public Text countText;
    private int count = 0;

    void Start()
    {
        pastObject = Instantiate(prefab, new Vector3(-xBound, yBound, 10), Quaternion.identity);
        count++;
        UpdateCount();
    }

    void Update()
    {
        if (spawning == false) {
            StartCoroutine(SpawnLevel());
        }
    }

    void UpdateCount()
    {
        countText.text = "Lake Count: " + count.ToString();
    }

    IEnumerator SpawnLevel()
    {
        spawning = true;
        yield return new WaitForSeconds(0.1f);

        if ((pastObject.transform.position.x + 0.75f) > xBound) {
            if ((pastObject.transform.position.y - 1) < (-yBound)) {
                Time.timeScale = 0;
            }

            newObject = Instantiate(prefab, new Vector3(-xBound, pastObject.transform.position.y - 0.25f, 10), Quaternion.identity);
        } else {
            newObject = Instantiate(prefab, new Vector3(pastObject.transform.position.x + 1, pastObject.transform.position.y, 10), Quaternion.identity);
        }

        pastObject = newObject;
        count++;
        UpdateCount();
        spawning = false;
    }
}
