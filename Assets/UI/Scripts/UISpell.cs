using EquipableWeapon;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Weapons.Effects;

public class UISpell : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Image _cooldownImage;
    [SerializeField] private TMP_Text _coolDownText;

    private SpellCaster linkedSpellCaster;
    private PlayerHand _playerHand;
    private bool _isLinkedEffect = false;

    private void Start()
    {
        SimpleUnlink();
        HideCooldown();
    }

    private void SimpleUnlink()
    {
        _image.sprite = null;
        _image.color = new Color(1, 1, 1, 0f);
    }

    #region ClassSpell
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
    #endregion

    #region Weapon
    public void LinkWeapon(PlayerHand playerHand)
    {
        _playerHand = playerHand;
        _playerHand.OnWeaponChanged += PlayerHandOnOnWeaponChanged;
        PlayerHandOnOnWeaponChanged();
    }
    private void PlayerHandOnOnWeaponChanged()
    {
        Weapon weapon = _playerHand.currentWeapon;
        _image.sprite = weapon.GetComponent<SpriteRenderer>().sprite;
        _image.color = Color.white;


    }
    public void LinkWeaponEffect(PlayerHand playerHand)
    {
        _isLinkedEffect = true;
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
            _image.sprite = _playerHand.currentWeapon.effect.uiImage;
            _image.color = Color.white;
        }
        else SimpleUnlink();
    }
    #endregion
    private void Update()
    {
        #region ClassSpell
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
        #endregion
        #region Weapon
        if (_playerHand)
        { 
            if (_isLinkedEffect)
            {
                // TODO: Error on Swapping Weapon when effect is active
                if (_playerHand.currentWeapon)
                {
                    if (_playerHand.currentWeapon.effect)
                    {
                        if (_playerHand.effectHandler.state == EffectState.onRefreshing)
                        {
                            float current = _playerHand.effectHandler.cooldown;
                            float max = _playerHand.currentWeapon.effect.cooldown;
                            UpdateCooldown(Mathf.CeilToInt(current), current / max);
                        }
                    }
                }
            }
            else
            {
                Weapon weapon = _playerHand.currentWeapon;
                if (weapon.isOnCooldown)
                {
                    UpdateCooldown(Mathf.CeilToInt(weapon.currentCooldown), weapon.currentCooldown / weapon.maxCooldown);
                }
            }

            //todo normal weapon

        }
        #endregion
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