using System;
using EquipableWeapon;
using Player;
using UnityEngine;

namespace UI.Scripts.UISpells
{
    public class WeaponPrimarySpell : UISpell
    {
        private PlayerHand _playerHand;

        public void LinkWeapon(PlayerHand playerHand)
        {
            _playerHand = playerHand;
            _playerHand.OnWeaponChanged += PlayerHandOnOnWeaponChanged;
            PlayerHandOnOnWeaponChanged();
        }

        private void PlayerHandOnOnWeaponChanged()
        {
            Weapon weapon = _playerHand.currentWeapon;
            UpdateSprite(weapon.GetComponent<SpriteRenderer>().sprite);
        }

        private void Update()
        {
            if (_playerHand)
            {
                Weapon weapon = _playerHand.currentWeapon;
                if (weapon.isOnCooldown)
                {
                    UpdateCooldown(Mathf.CeilToInt(weapon.currentCooldown),
                        weapon.currentCooldown / weapon.maxCooldown);
                }
            }
        }
    }
}