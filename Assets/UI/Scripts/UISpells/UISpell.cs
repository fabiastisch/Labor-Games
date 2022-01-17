using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Scripts.UISpells
{
    public class UISpell : MonoBehaviour
    {
        [SerializeField] protected Image _image;
        [SerializeField] protected Image _cooldownImage;
        [SerializeField] protected TMP_Text _coolDownText;

        protected virtual void Start()
        {
            SimpleUnlink();
            HideCooldown();
        }

        protected void UpdateSprite(Sprite sprite)
        {
            if (sprite)
            {
                _image.sprite = sprite;
                _image.color = Color.white;
            }
            else SimpleUnlink();
        }

        protected void SimpleUnlink()
        {
            _image.sprite = null;
            _image.color = new Color(1, 1, 1, 0f);
        }

        protected void HideCooldown()
        {
            UpdateCooldown(0, 0f);
        }

        protected void UpdateCooldown(int seconds, float percentage)
        {
            _coolDownText.text = seconds > 0 ? seconds.ToString() : "";
            _cooldownImage.fillAmount = percentage;
        }
    }
}