/*
 * Filename: LevelDatastore.cs
 * Developer: Jenna-Luz Pura
 * Purpose: Holds persistent data about each level.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Uses static variables to carry level information across scenes.
 *
 * Member Variables:
 * instance -- static LevelDatastore to ensure only one instance exists.
 * levelCount -- static int to hold the number of levels.
 * unlockedLevels -- string key and bool value static Dictionary to store which levels are unlcoked.
 * finishedLevels -- int key and bool value static Dictionary to store which levels have been
 *    completed.
 * nextLevel -- static string to hold the name of the next level.
 */
public class LevelDatastore
{
    private static LevelDatastore instance;
    private static int levelCount;
    private static Dictionary<string, bool> unlockedLevels;
    private static Dictionary<int, bool> finishedLevels;
    private static string nextLevel;

    /*
     * LevelDatastore constructor.
     * Checks if a LevelDatastore instance is already created (Singleton pattern).
     * Unlocks only the the first level.
     * Sets all levels to 'unfinished'.
     *
     * Parameters:
     * levelNumber -- int to set the number of levels, with a default value of 5.
     */
    public LevelDatastore(int levelNumber = 5)
    {
        if (instance == null) { // Singleton pattern
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

    /*
     * Sets finishedLevels at the levelIndex to be true.
     * If the level is not the last level then the next level is unlocked and nextLevel is set to
     *    the name of that level.
     * If the level is the last level, then nextLevel is set to the name of the last level.
     *
     * Parameters:
     * level -- string to hold the name of the level just finished.
     */
    public void FinishLevel(string level)
    {
        if (unlockedLevels.ContainsKey(level)) {
            int levelIndex = int.Parse(level.Replace("Level", ""));
            finishedLevels[levelIndex] = true;

            if (levelIndex < levelCount) {
                unlockedLevels["Level" + (levelIndex + 1)] = true;
                nextLevel = "Level" + (levelIndex + 1);
            } else {
                nextLevel = "Level5";
            }
        }
    }

    /*
     * Parameters:
     * level -- string to hold th ename of the level.
     *
     * Returns:
     * unlockedLevels[level] -- bool false if unlocked and true of locked.
     */
    public bool GetLevelStatus(string level)
    {
        return unlockedLevels[level];
    }

    /*
     * Prints unlocked and finished state of each level as well as the name of the next level.
     */
    public void PrintLevelStatus()
    {
        for (int i = 1; i <= levelCount; i++) {
            Debug.Log("JP Unlocked " + i + " " + unlockedLevels["Level" + i]);
            Debug.Log("JP Finished " + i + " " + finishedLevels[i]);
        }

        Debug.Log("JP Next level " + nextLevel);
    }

    /*
     * Returns the level index of the next level.
     *
     * Returns:
     * nextLevel -- int converts string to level index.
     */
    public int GetNextLevel()
    {
        return int.Parse(nextLevel.Replace("Level", ""));
    }
}
