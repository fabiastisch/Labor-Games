using Player;
using UnityEngine;
using Weapons.Effects;

namespace UI.Scripts.UISpells
{
    public class WeaponEffectSpell : UISpell
    {
        private PlayerHand _playerHand;

        public void LinkWeaponEffect(PlayerHand playerHand)
        {
            _playerHand = playerHand;
            _playerHand.OnWeaponChanged += PlayerHandOnOnWeaponChangedEffect;
            PlayerHandOnOnWeaponChangedEffect();
        }
        private void PlayerHandOnOnWeaponChangedEffect()
        {

            if (_playerHand.currentWeapon.effect)
            {
                if (!_playerHand.currentWeapon.effect.uiImage)
                {
                    Debug.Log("Weapon Effect Sprite is missing: " + _playerHand.currentWeapon.effect.name);
                }
                UpdateSprite(_playerHand.currentWeapon.effect.uiImage);
            }
            else SimpleUnlink();
        }

        private void Update()
        {
            // TODO: Error on Swapping Weapon when effect is active
            if (_playerHand.currentWeapon)
            {
                if (_playerHand.currentWeapon.effect)
                {
                    if (_playerHand.effectHandler && _playerHand.effectHandler.state == EffectState.onRefreshing)
                    {
                        float current = _playerHand.effectHandler.cooldown;
                        float max = _playerHand.currentWeapon.effect.cooldown;
                        UpdateCooldown(Mathf.CeilToInt(current), current / max);
                    }
                }
            }
        }
    }
}