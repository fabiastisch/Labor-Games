using UnityEngine;
namespace Utils.Slider
{
    public class HealthBar : TextSlider
    {
        private Combat.Character _character;

        void Start()
        {
            _character = Util.GetLocalPlayer();
            _character.OnHealthChanged += OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            SetText(_character.GetActualHealth().ToString());
            SetValue(_character.GetPercentageHpSmall());
        }

    }
}