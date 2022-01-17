using UnityEngine;

namespace UI.Scripts.UISpells
{
    public class ClassAbilitySpell : UISpell
    {
        private SpellCaster linkedSpellCaster;

        
        public void LinkSpell(SpellCaster spellCaster)
        {
            linkedSpellCaster = spellCaster;
            spellCaster.OnSpellChanged += SpellCasterOnOnSpellChanged;
        }
        private void SpellCasterOnOnSpellChanged()
        {
            if (linkedSpellCaster && linkedSpellCaster.spell)
            {
                _image.sprite = linkedSpellCaster.spell.abitllityIcon;
                _image.color = Color.white;
            }
            else
            {
                SimpleUnlink();
            }

        }

        private void Update()
        {
            if (linkedSpellCaster && linkedSpellCaster.spell)
            {
                if (linkedSpellCaster.GetState() == PassiveSlot.PassiveState.cooldown)
                {
                    float current = linkedSpellCaster.getCooldown();
                    float max = linkedSpellCaster.getMaxCooldown();
                    UpdateCooldown(Mathf.CeilToInt(current), current / max);
                }
                else
                {
                    HideCooldown();
                }
            }
        }

    }
}