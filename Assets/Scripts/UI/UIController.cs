using UnityEngine;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{
    [SerializeField] ExpData expSettings;
    [SerializeField] private Slider expCount;


    private void Start()
    {
        UpdateUI();
    }


    public void AddToUpdateXP(IUpdate update)
    {
        update.UpdateUI += UpdateUI;
    }

    public void UpdateUI()
    {
        expCount.maxValue = expSettings.GetNextLevelXP(GameInformation.CurrentPlayerLevel);

        expCount.value = GameInformation.CurrentExperience;
    }
}
