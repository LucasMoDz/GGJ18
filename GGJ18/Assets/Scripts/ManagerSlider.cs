using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Random = UnityEngine.Random;

public static class SliderEvents
{
    public static Action<bool> SliderActivation;
}

public class ManagerSlider : MonoBehaviour
{
    public RectTransform range;
    public float maxPositionY = 144;
    public float minPositionY = -144;
    public float ratioRangeSlider = .2f;

    private Slider slider;
    private Coroutine activeCoroutine;
    private float totalPositionRange;
    private float normalizedMaxRange, normalizedMinRange;
    private bool sliderIsActive;
    
    private void Awake()
    {
        if (range == null)
        {
            Debug.LogError("\"Range\" is null, please fix it.\n");
            return;
        }
        
        range.localPosition = Vector3.zero;
        totalPositionRange = maxPositionY + Mathf.Abs(minPositionY);
        
        range.sizeDelta = new Vector2(range.sizeDelta.x, this.GetComponent<RectTransform>().sizeDelta.y * ratioRangeSlider);

        slider = this.GetComponent<Slider>();

        SliderEvents.SliderActivation += _value =>
        {
            sliderIsActive = _value;

            if (!_value || activeCoroutine != null)
                return;

            activeCoroutine = StartCoroutine(StartSliderMovementCO());
        };
    }

    private IEnumerator StartSliderMovementCO()
    {
        float step, seconds, startPosition, targetPosition;
        float halfHeigth = totalPositionRange * (ratioRangeSlider / 2);
        Vector3 temp_position = range.localPosition;

        StartCoroutine(CheckRangeValidationCO());

        sliderIsActive = true;

        while (sliderIsActive)
        {
            step = 0.0f;
            seconds = Random.Range(.2f, .5f);
            startPosition = range.localPosition.y;
            targetPosition = Random.Range(minPositionY, maxPositionY);
            
            yield return new WaitForSecondsRealtime(seconds);

            while (step < 1.0f)
            {
                step += Time.deltaTime / (seconds * 1.2f);
				temp_position.y = Mathf.Lerp(startPosition, targetPosition, step);
                range.localPosition = temp_position;

                normalizedMaxRange = (temp_position.y + maxPositionY + halfHeigth) / totalPositionRange;
                normalizedMinRange = (temp_position.y + maxPositionY - halfHeigth) / totalPositionRange;

                yield return null;
            }

            yield return null;
        }

        activeCoroutine = null;
    }

    private IEnumerator CheckRangeValidationCO()
    {
        while (sliderIsActive)
        {
            if (slider.value < normalizedMaxRange && slider.value > normalizedMinRange)
            {
                SymbolsEvents.IncreaseAlpha();
            }
            else
            {
                SymbolsEvents.DecreaseAlpha();
            }

            yield return null;
        }
    }
}