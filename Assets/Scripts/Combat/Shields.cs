using System;
using System.Collections.Generic;
namespace Combat
{
    public class Shields
    {
        private readonly List<Shield> _shields = new List<Shield>();
        public event Action OnShieldChanges;
        public event Action OnTakingDamage;

        public float TakeDamage(float amount)
        {
            bool hadShield = HasShield();
            for (var i = _shields.Count - 1; i >= 0; i--)
            {
                var shield = _shields[i];
                if (shield.isActive)
                {
                    amount = shield.TakeDamage(amount);
                }
            }
            if (hadShield) OnTakingDamage?.Invoke();
            return amount;
        }

        public float GetMaximumValue()
        {
            float value = 0f;
            foreach (var shield in _shields)
            {
                value += shield.MaximumValue;
            }
            return value;
        }

        public float GetValueSum()
        {
            float value = 0f;
            foreach (var shield in _shields)
            {
                value += shield.isActive ? shield.shieldingValue : 0f;
            }
            return value;
        }

        public bool HasShield()
        {
            foreach (Shield shield in _shields)
            {
                if (shield.isActive)
                {
                    return true;
                }
            }
            return false;
        }

        public void Add(Shield shield)
        {
            if (HasThisShield(shield))
            {
                shield.RefreshShield();
            }
            _shields.Add(shield);
            shield.OnChanges += ShieldOnOnChanges;
        }

        public void Remove(Shield shield)
        {
            _shields.Remove(shield);
            shield.OnChanges -= ShieldOnOnChanges;
        }
        
        public bool HasThisShield(Shield shield)
        {
            if (_shields.Contains(shield))
            {
                return true;
            }
            return false;
        }
        
        private void ShieldOnOnChanges()
        {
            OnShieldChanges?.Invoke();
        }
    }
}