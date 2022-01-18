using System;
namespace Combat
{
    public class Shield
    {
        private float _value;
        public float shieldingValue
        {
            get => _value;
            set
            {
                _value = value;
                if (_value > MaximumValue) _value = MaximumValue;
                isActive = value > 0;
                OnChanges?.Invoke();
            }
        }

        private float _maximumValue;
        public float MaximumValue
        {
            get => _maximumValue;
            set
            {
                _maximumValue = value;
                if (shieldingValue > _maximumValue) shieldingValue = _maximumValue;
                isActive = shieldingValue > 0;
                OnChanges?.Invoke();
            }
        }
        public bool isActive { get; private set; }
        public event Action OnChanges;

        public Shield(float value)
        {
            MaximumValue = value;
            shieldingValue = value;
        }
        public Shield(float value, float maximumValue)
        {
            MaximumValue = maximumValue;
            shieldingValue = value;
        }
        /**
         * Removed the amount of value from this Shield
         * Returns overKilling Damage
         */
        public float TakeDamage(float amount)
        {
            float overkill = shieldingValue - amount;
            if (overkill <= 0)
            {
                shieldingValue = 0;
                return overkill;
            }
            shieldingValue -= amount;
            return 0;
        }
    }
}