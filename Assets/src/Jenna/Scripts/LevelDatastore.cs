using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDatastore
{
    private static int currentLevel = 1;

    public void ChangeLevel()
    {
        currentLevel = 2;
    }

    public void PrintLevel()
    {
        Debug.Log("Current level is " + currentLevel);
    }
}
