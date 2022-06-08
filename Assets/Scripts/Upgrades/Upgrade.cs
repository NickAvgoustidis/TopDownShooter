using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Upgrade : DescribableObject
{
    [SerializeField] protected UpgradeData upgradeData;

    public int CurrentLevel { get; set; }

    public Action OnUpgrade;

    public bool isAtMaxLevel => CurrentLevel >= upgradeData.GetMaxLevel;

    public virtual void DoUpgrade()
    {
        CurrentLevel++;
        OnUpgrade?.Invoke();
    }
}
