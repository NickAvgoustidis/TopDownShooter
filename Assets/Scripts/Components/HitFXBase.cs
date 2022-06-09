using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFXBase : MonoBehaviour
{
    enum FXType { Flash, Scale, Both }

    [SerializeField] SpriteRenderer renderer;

    [SerializeField] FXType fxType;
    [Header("Flash Options")]
    [SerializeField] Color flashColor = Color.white;
    [SerializeField] int flashTimes = 2;
    [SerializeField] float flashDuration = .5f;
    Color defaultColor;

    [Header("Scale Options")]
    [SerializeField] Vector2 targetScale;
    [SerializeField] float duration;
    [SerializeField] float speed = 1.5f;

    Coroutine flashRoutine;
    Coroutine ScaleRoutine;
    Vector2 defaultScale;
    private void Start()
    {
        defaultColor = renderer.color;
        defaultScale = transform.localScale;
    }

    public void HandleFX()
    {
        switch (fxType)
        {
            case FXType.Flash:

                StartFlashRoutine();

                break;
            case FXType.Scale:

                StartScaleRoutine();

                break;
            case FXType.Both:
                StartFlashRoutine();
                StartScaleRoutine();
                break;
            default:
                break;
        }
    }

    private void StartScaleRoutine()
    {
        if (ScaleRoutine != null)
        {
            StopCoroutine(ScaleRoutine);
            ScaleRoutine = null;
        }
        ScaleRoutine = StartCoroutine(Scale());
    }

    private void StartFlashRoutine()
    {
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
            flashRoutine = null;
        }
        flashRoutine = StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        int flashCount = 0;
        while (flashCount <= flashTimes)
        {
            renderer.color = flashColor;

            yield return new WaitForSeconds(flashDuration);

            renderer.color = defaultColor;

            flashCount++;
        }

        flashRoutine = null;
    }

    IEnumerator Scale()
    {
        transform.localScale = defaultScale;

        while(!transform.localScale.Equals(targetScale))
        {
        transform.localScale = Vector2.MoveTowards(transform.localScale, targetScale, (duration) * Time.deltaTime * speed);
            yield return null;
        }


        while(!transform.localScale.Equals(defaultScale))
        {
            transform.localScale = Vector2.MoveTowards(transform.localScale, defaultScale, (duration) * Time.deltaTime * speed);
            yield return null;
        }



        ScaleRoutine = null;

    }
}
