using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{

    [SerializeField] Slider healthBarSlider;
    [SerializeField] Image fillImage;
    [SerializeField] Image ghostFillImage;


    Coroutine slideHealthRoutine;
    Health health;
  
    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void Start()
    {
        UpdateHealthBar();

        health.OnHit.AddListener(UpdateHealthBar);
    }
    public void UpdateHealthBar()

    {
    

        healthBarSlider.maxValue = health.GetHealth;
        healthBarSlider.value = health.GetCurrentHealth;

        if(slideHealthRoutine != null)
        {
            StopCoroutine(slideHealthRoutine);
            slideHealthRoutine = null;
        }
        slideHealthRoutine=  StartCoroutine(SlideHealth());

    }

    IEnumerator SlideHealth()
    {
        float targetFillAmount = fillImage.fillAmount;
        while (ghostFillImage.fillAmount > targetFillAmount)
        {
            ghostFillImage.fillAmount -= Time.deltaTime * .3f;

            yield return null;
        }

        slideHealthRoutine = null;
    }
}
