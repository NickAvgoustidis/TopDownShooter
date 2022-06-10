using System;
using UnityEngine;

public class ExpBlob : Collectible, IUpdate
{
    [SerializeField] private float expGain = 1;
    [SerializeField] private float destroyAfter = 15;

    public Action UpdateUI { get; set; }

    private void Start()
    {
        UIController.Instance.AddToUpdateXP(this);
        ExpManager.Instance.AddExp(this);

        Destroy(gameObject, destroyAfter);
    }

    public override void Interact()
    {

       if(GameInformation.IncreasedLevel % 5 == 0)
        {
            expGain++;
        }

        GameInformation.CurrentExperience += Mathf.CeilToInt( expGain);
        UpdateUI?.Invoke();

        Destroy(gameObject);
    }
}