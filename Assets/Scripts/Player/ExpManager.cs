using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpManager : Singleton<ExpManager>, IUpdate
{
    [SerializeField] private ExpData expSettings;

    public Action UpdateUI { get; set; }

    private void Start()
    {
        UIController.Instance.AddToUpdateXP(this);
        UpgradeManager.Instance.AddToLevelUp(this);
    }

    public void AddExp(IUpdate update)
    {
        update.UpdateUI += OnAddedXP;
    }

    public void OnAddedXP()
    {
        LevelUp();
    }

    private void LevelUp()
    {
        if (GameInformation.CurrentExperience >= expSettings.GetNextLevelXP(GameInformation.CurrentPlayerLevel))
        {

            int checkForLeftOverXp = GameInformation.CurrentExperience - expSettings.GetNextLevelXP(GameInformation.CurrentPlayerLevel);

            if (checkForLeftOverXp < 0)
            {
                checkForLeftOverXp = 0;
            }
            GameInformation.CurrentExperience = checkForLeftOverXp;
            //Level Up
            GameInformation.CurrentPlayerLevel++;

            UpdateUI?.Invoke();
        }
    }
}
