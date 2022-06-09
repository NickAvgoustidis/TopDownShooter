using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{

    [SerializeField] Slider healthBarSlider;
    [SerializeField] Image fillImage;
    [SerializeField] Image ghostFillImage;
    [Header("Health Bar FX Options")]
    [SerializeField] float delay = .2f;
    [Range(0.1f, 1)]
    [SerializeField] float speed = 0.2f;

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

        if (slideHealthRoutine != null)
        {
            StopCoroutine(slideHealthRoutine);
            slideHealthRoutine = null;
        }
        slideHealthRoutine = StartCoroutine(SlideHealth());

    }

    IEnumerator SlideHealth()
    {
        float targetFillAmount = fillImage.fillAmount;
        if (delay > 0)
        {
            yield return new WaitForSeconds(delay);
        }

        while (ghostFillImage.fillAmount > targetFillAmount)
        {
            ghostFillImage.fillAmount -= Time.deltaTime * speed;

            yield return null;
        }

        slideHealthRoutine = null;
    }
}
