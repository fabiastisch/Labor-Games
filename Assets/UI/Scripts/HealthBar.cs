using Utils;
namespace UI.Scripts
{
    public class HealthBar : TextSlider
    {
        private Combat.Character _character;

        void Start()
        {
            _character = Util.GetLocalPlayer();
            _character.OnHealthChanged += OnHealthChanged;
            OnHealthChanged();
        }

        private void OnHealthChanged()
        {
            SetText(_character.GetActualHealth().ToString());
            SetValue(_character.GetPercentageHpSmall());
        }

    }
}