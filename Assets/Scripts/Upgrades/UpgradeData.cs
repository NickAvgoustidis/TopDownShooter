using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu()]
public class UpgradeData : ScriptableObject
{
   
    [SerializeField] List<float> perLevelIncrease = new List<float>();
    [SerializeField] float growthRate;
    [SerializeField] float startingValue;
    [SerializeField] bool isIncremental = true;
    [SerializeField] int maxLevel;


    public int GetMaxLevel => maxLevel;

    [ContextMenu("Set Levels")]
    private void SetLevels()
    {
        if (perLevelIncrease.Count > 0) perLevelIncrease.Clear();

        perLevelIncrease.Add(startingValue);

        for (int i = 1; i < maxLevel; i++)
        {
            float nextUpgrade = ( perLevelIncrease[i -1] + growthRate);

            if (!isIncremental)
            {
                nextUpgrade = ( perLevelIncrease[i - 1] - growthRate);
            }

            perLevelIncrease.Add(nextUpgrade);
        }
    }

    public float GetNextLevelValue(int currentLevel)
    {
        return perLevelIncrease[currentLevel];
    }
}
