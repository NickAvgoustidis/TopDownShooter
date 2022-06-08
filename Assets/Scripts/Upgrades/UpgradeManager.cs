using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : Singleton<UpgradeManager>
{

    [SerializeField] GameObject upgradePanel;

    [SerializeField] UpgradeButton[] upgradeButton;

    [SerializeField] List<Upgrade> upgrades = new List<Upgrade>();
    [SerializeField] List<Upgrade> availableUpgrades = new List<Upgrade>();

    [SerializeField] List<Upgrade> randomUpgrades = new List<Upgrade>();

    private void Start()
    {
        foreach(var upgrade in upgrades)
        {
            availableUpgrades.Add(upgrade);
        }

    }

    public void AddToLevelUp(IUpdate update)
    {
        update.UpdateUI += OnLevelUp;
    }
    [ContextMenu("Level up Test")]
    public void OnLevelUp()
    {
        upgradePanel.SetActive(true);
        GameManager.GameState = GameState.PAUSED;

        if (randomUpgrades.Count > 0) randomUpgrades.Clear();

        randomUpgrades = ListUtils.GetRandomUniquesFromList(availableUpgrades, upgradeButton.Length);

        foreach (var upgrade in randomUpgrades)
        {
            if (upgrade.isAtMaxLevel)
            {
                availableUpgrades.Remove(upgrade);
            }
        }


        for (int i = 0; i < upgradeButton.Length; i++)
        {
            Upgrade upgrade = randomUpgrades[i];

            upgradeButton[i].Initialize(upgrade);
        }


    }
}


public static class ListUtils
{
    public static List<T> GetRandomUniquesFromList<T>(List<T> myList, int numberOfRandoms)
    {

        List<int> indexesUsed = new List<int>();

        List<T> randoms = new List<T>();

        for (int i = 0; i < numberOfRandoms; i++)
        {
            int randomIndex = Random.Range(0, myList.Count);

            while (indexesUsed.Count > 0 && indexesUsed.Contains(randomIndex))
            {
                randomIndex = Random.Range(0, myList.Count);
            }

            indexesUsed.Add(randomIndex);

            randoms.Add(myList[randomIndex]);
        }

        return randoms;
    }
}