using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameInformation
{
    public static int CurrentExperience { get; set; }
    public static int CurrentPlayerLevel { get; set; }
    public static float CurrentGameDifficulty { get; set; }
    public static int IncreasedLevel { get; set; }

    public static void IncreaseDifficulty()
    {
        CurrentGameDifficulty += 0.1f;
        IncreasedLevel++;
    }

    static GameInformation()
    {
        CurrentGameDifficulty = 1; //This is multiplied by various factors, so base will be always 1.
        IncreasedLevel = 1;
    }
}
