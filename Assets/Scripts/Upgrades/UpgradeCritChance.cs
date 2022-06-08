using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Crit Chance")]
public class UpgradeCritChance : Upgrade
{
    public override void DoUpgrade()
    {


        Player.Instance.shooter.SetCritChance(upgradeData.GetNextLevelValue(CurrentLevel));

        base.DoUpgrade();
    }
}
