using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Bullet Upgrades/ Ricochet")]
public class UpgradeToRicochetBullet : Upgrade
{
    public override void DoUpgrade()
    {
        Player.Instance.shooter.ChangeBulletType(BulletType.Ricochet);
        Player.Instance.shooter.SetUpBulletTargets((int)upgradeData.GetNextLevelValue(CurrentLevel));
        base.DoUpgrade();
    }
}
