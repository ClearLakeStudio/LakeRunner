/*
 * Filename: LevelDatastore.cs
 * Developer: Jenna-Luz Pura
 * Purpose: Defines the methods used for the inter-level map.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDatastore
{
    private static LevelDatastore instance;
    private static int levelCount;
    private static Dictionary<string, bool> unlockedLevels;
    private static Dictionary<int, bool> finishedLevels;
    private static string nextLevel;

    public LevelDatastore(int levelNumber = 5)
    {
        if (instance == null) {
            instance = this;
            levelCount = levelNumber;
            nextLevel = "Level1";

            unlockedLevels = new Dictionary<string, bool>();
            finishedLevels = new Dictionary<int, bool>();

            unlockedLevels["Level1"] = true;  // level 1 will always be unlocked

            // all other levels will be locked
            for (int i = 2; i <= levelCount; i++) {
                unlockedLevels["Level" + i] = false;
            }

            // no levels will be finished
            for (int i = 1; i <= levelCount; i++) {
                finishedLevels[i] = false;
            }
        }
    }

    public void ChangeLevel()
    {
        unlockedLevels["Level2"] = true;
        finishedLevels[2] = true;
        //nextLevel = "Jenna-Luz";
    }

    public void EndOfLevel(string level, bool finished)
    {
        if (unlockedLevels.ContainsKey(level)) {
            int levelIndex = int.Parse(level.Replace("Level", ""));
            finishedLevels[levelIndex] = finished;

            if (levelIndex < levelCount && finished == true) {
                unlockedLevels["Level" + (levelIndex + 1)] = finished;
                nextLevel = "Level" + (levelIndex + 1);
            }
        }
    }

    public bool GetLevelStatus(string level)
    {
        return unlockedLevels[level];
    }

    public void PrintLevelStatus()
    {
        for (int i = 1; i <= levelCount; i++) {
            Debug.Log("JP Unlocked " + i + " " + unlockedLevels["Level" + i]);
            Debug.Log("JP Finished " + i + " " + finishedLevels[i]);
        }

        Debug.Log("JP Next level " + nextLevel);
    }

    public int GetNextLevel()
    {
        return int.Parse(nextLevel.Replace("Level", ""));
    }
}
