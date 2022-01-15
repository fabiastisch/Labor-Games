using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextSlider : MonoBehaviour
{
    [SerializeField] protected TMP_Text _text;
    [SerializeField] protected Slider _slider;

    public void SetValue(float value)
    {
        _slider.value = value;
    }

    public void SetText(string text)
    {
        _text.text = text;
    }

}