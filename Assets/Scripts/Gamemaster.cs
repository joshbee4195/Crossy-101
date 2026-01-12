using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Gen        //general
{
    public static int coins = 20;

    public static int score = 0;
    public static int pureScore = 0;

    public static int highScore = 0;


    public static int level = 0;



    public static int cha = 1;  //1 is chicken, 2 is whale

    public static bool start = false;

    
    public static Scene lastScene;
    public static string previousSceneName;


    public static int buyPrice = 10;

}

public static class Chars
{
    public static bool whale = false;
}


public static class Merge
{
    public static GameObject obj1;
    public static GameObject obj2;

    public static int xp = 0;
    public static int LVL = 1;

    public static bool Conv = false;

    public static bool[] Layer2Land = new bool[] {false, false, false, false, false, false, false, false, false, false, false, false};
    public static GameObject[] Layer2BLocks;    // =new bool[] {false, false, false, false, false, false, false, false, false, false, false, false};

    public static Vector3[] blockPos;


    public static int Layer2Occ;

    public static int highestChar = 0;
}


public static class Practice
{
    public static int Scenario; //1-9

    public static int SectionsSpawned;

    public static bool isPaused;

    public static bool newPolice = true;

    public static int ResetCount;

    /*
     * Police:

1 - Single
2 - Double
3 - Train pressure

Cycles:

4 - Car walls
5 - Consecutive 4 cycles
6 - Checkerboard cycles

Lane priority:

7 - Slow moving lane
8 - Train waiting
9 - Multi trains
    
*/

}
