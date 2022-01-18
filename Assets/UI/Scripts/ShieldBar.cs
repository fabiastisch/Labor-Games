using Utils;
namespace UI.Scripts
{
    public class ShieldBar : TextSlider
    {
        private Combat.Character _character;

        void Start()
        {
            _character = Util.GetLocalPlayer();
            _character.shields.OnShieldChanges += ShieldsOnOnShieldChanges;
            ShieldsOnOnShieldChanges();
        }
        private void ShieldsOnOnShieldChanges()
        {
            float max = _character.shields.GetMaximumValue();
            float curr = _character.shields.GetValueSum();

            SetText(curr.ToString());
            SetValue(curr / max);
        }

    }
}