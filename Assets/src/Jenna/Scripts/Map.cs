/*
 * Filename: Map.cs
 * Developer: Jenna-Luz Pura
 * Purpose: Defines the most generic map type.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Defines a base class for different types of game maps.
 *
 * Member variables:
 * levelCount -- protected int to hold the number of levels.
 * levels -- protected GameObject[] to hold an array of all levels.
 */
public class Map : MonoBehaviour
{
    protected int levelCount;
    protected GameObject[] levels;
}
