
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Attack Speed")]
public class UpgradeAttackSpeed : Upgrade
{
    public override void DoUpgrade()
    {
        Player.Instance.shooter.SetAttackSpeed(upgradeData.GetNextLevelValue(CurrentLevel));

        base.DoUpgrade();
    }
}
