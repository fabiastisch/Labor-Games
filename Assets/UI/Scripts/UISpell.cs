using System;
using UnityEngine;
using UnityEngine.UI;

public class UISpell : MonoBehaviour
{
    [SerializeField] private Image _image;
    
    private SpellCaster linkedSpellCaster;

    private void Start()
    {
        SpellCasterOnOnSpellChanged();
    }

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
            _image.sprite = null;
            _image.color = new Color(1, 1, 1, 0f);
        }

    }
}