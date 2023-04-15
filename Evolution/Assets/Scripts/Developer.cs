using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Developer
{
    [MenuItem("Development/Delete All Balls")]
    public static void DelteAllBalls()
    {
        Debug.Log("Developer menu item one - selected");
    }

    [MenuItem("Development/Stop Spawning")]
    public static void StopSpawning()
    {
        Debug.Log("Developer menu item two - selected");
    }

}
