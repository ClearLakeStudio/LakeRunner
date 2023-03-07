using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OverworldLevel : MonoBehaviour
{
    private GameObject level;
    public bool levelMenuIsActive = false;
    public bool levelIsLoaded = false;

    // Start is called before the first frame update
    void Start()
    {
        level = GameObject.Find("Level");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OpenLevelMenu()
    {
        levelMenuIsActive = true;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("GameScene");
    }
}