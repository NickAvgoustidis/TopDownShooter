
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Damage Done")]
public class UpgradeDamage : Upgrade
{
    public override void DoUpgrade()
    {
        Player.Instance.shooter.SetDamageDone((int)upgradeData.GetNextLevelValue(CurrentLevel));

        
        base.DoUpgrade();
    }
}
