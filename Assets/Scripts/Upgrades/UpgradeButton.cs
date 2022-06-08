using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField]Upgrade upgrade;

    [SerializeField] TextMeshProUGUI nameText;

    public void Initialize(Upgrade upgrade)
    {
        this.upgrade = upgrade;
        nameText.text = upgrade.GetName;
    }
    
    public void Upgrade()
    {
        upgrade.DoUpgrade();
        GameManager.GameState = GameState.PLAYING;
    }
}
