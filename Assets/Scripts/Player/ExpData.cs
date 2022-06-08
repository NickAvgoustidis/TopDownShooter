using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Exp Data Settings")]
public class ExpData : ScriptableObject
{
    [SerializeField] private int firstLevelReq = 10;
    [SerializeField] private float exponantialFactor = .2f;
    [SerializeField] private int maxLevel = 100;
    [SerializeField] private List<int> xpPerLevel;


    [ContextMenu("Set Levels")]
    private void SetLevels()
    {
      if(xpPerLevel.Count > 0)  xpPerLevel.Clear();

        xpPerLevel.Add(firstLevelReq);

        for (int i = 1; i < maxLevel; i++)
        {
            int xp = Mathf.CeilToInt(xpPerLevel[i - 1] + (xpPerLevel[i-1] * exponantialFactor));

            xpPerLevel.Add(xp);
        }
    }

    public int GetNextLevelXP(int currentLevel)
    {
        return xpPerLevel[currentLevel];
    }

}
