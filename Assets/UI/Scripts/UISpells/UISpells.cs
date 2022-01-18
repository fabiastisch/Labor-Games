using System.Collections.Generic;
using System.Linq;
using Player;
using UnityEngine;
using Utils;
namespace UI.Scripts.UISpells
{
    public class UISpells : MonoBehaviour
    {

        private List<SpellCaster> spellCasters = new List<SpellCaster>();

        [SerializeField] private List<ClassAbilitySpell> Abilities;
        [SerializeField] private WeaponPrimarySpell weaponPrimary;
        [SerializeField] private WeaponEffectSpell weaponEffect;
        [SerializeField] private DashSpell dashSpell;

        private PlayerHand _playerHand;
        private void Start()
        {
            _playerHand = Util.GetLocalPlayer().hand;

            weaponPrimary.LinkWeapon(_playerHand);
            weaponEffect.LinkWeaponEffect(_playerHand);

        }
        public void AddSpellListAbilities(List<GameObject> spellList)
        {
            spellCasters = spellList.Select(x => x.GetComponent<SpellCaster>()).ToList();

            if (Abilities.Count != spellCasters.Count)
            {
                Debug.LogError("SpellCasters Count is not equal UI Abilities: " + Abilities.Count + " | " + spellCasters.Count);
            }

            for (var i = 0; i < Abilities.Count; i++)
            {
                Abilities[i].LinkSpell(spellCasters[i]);
            }

        }

        public void UpdateBindingDisplayText()
        {
            foreach (ClassAbilitySpell classAbilitySpell in Abilities)
            {
                classAbilitySpell.UpdateBindingDisplayText();
            }
            weaponEffect.UpdateBindingDisplayText();
            weaponPrimary.UpdateBindingDisplayText();
            dashSpell.UpdateBindingDisplayText();
        }
    }
}