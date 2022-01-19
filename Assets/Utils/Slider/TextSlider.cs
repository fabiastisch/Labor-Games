using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextSlider : MonoBehaviour
{
    [SerializeField] protected TMP_Text _text;
    [SerializeField] protected Slider _slider;

    [SerializeField] protected Color flashColor = Color.white;
    private float flashTime = 0.08f;

    private Color primaryColor;
    protected virtual void Awake()
    {
        primaryColor = _slider.fillRect.GetComponent<Image>().color;

    }
    public void SetValue(float value)
    {
        if (float.IsInfinity(value) || float.IsNaN(value))
        {
            _slider.value = 0;
        }
        else
        {
            _slider.value = value;
        }
    }

    public void Flash()
    {
        StopCoroutine(nameof(FlashCoroutine));
        ResetFlash();
        StartCoroutine(nameof(FlashCoroutine));
    }


    public void SetText(string text)
    {
        _text.text = text;
    }

    IEnumerator FlashCoroutine()
    {
        Image image = _slider.fillRect.GetComponent<Image>();
        image.color = flashColor;
        yield return new WaitForSeconds(flashTime);
        image.color = primaryColor;
    }

    private void ResetFlash()
    {
        Image image = _slider.fillRect.GetComponent<Image>();
        image.color = primaryColor;
    }
}