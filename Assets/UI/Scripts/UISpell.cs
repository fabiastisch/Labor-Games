using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISpell : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Image _cooldownImage;
    [SerializeField] private TMP_Text _coolDownText;

    private SpellCaster linkedSpellCaster;

    private void Start()
    {
        SpellCasterOnOnSpellChanged();
        HideCooldown();
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
    private void HideCooldown()
    {
        UpdateCooldown(0, 0f);
    }

    public void UpdateCooldown(int seconds, float percentage)
    {
        _coolDownText.text = seconds > 0 ? seconds.ToString() : "";
        _cooldownImage.fillAmount = percentage;
    }
}