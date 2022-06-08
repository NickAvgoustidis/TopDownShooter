
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Crit Damage")]
public class UpgradeCritDamage : Upgrade
{
    public override void DoUpgrade()
    {
        Player.Instance.shooter.SetCritDamage(upgradeData.GetNextLevelValue(CurrentLevel));
        base.DoUpgrade();
    }
}
