using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSlider : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Slider _slider;

    public void SetValue(float value)
    {
        _slider.value = value;
    }

    public void SetLevel(int level)
    {
        _text.text = level.ToString();
    }

}