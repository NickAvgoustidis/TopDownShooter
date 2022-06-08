using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Bullet Upgrades/ Explosive")]
public class UpgradeToExplosiveBullet : Upgrade
{
    public override void DoUpgrade()
    {
        Player.Instance.shooter.ChangeBulletType(BulletType.Explosive);
        Player.Instance.shooter.SetUpBulletTargets((int)upgradeData.GetNextLevelValue(CurrentLevel));
        base.DoUpgrade();
    }
}
