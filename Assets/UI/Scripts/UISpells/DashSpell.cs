using Player;
using TMPro;
using UnityEngine;
using Utils;
namespace UI.Scripts.UISpells
{
    public class DashSpell : UISpell
    {
        [SerializeField] protected TMP_Text _leftUsesText;

        [SerializeField] private Sprite _sprite;

        protected override void Start()
        {
            base.Start();
            PlayerBase player = Util.GetLocalPlayer();
            player.OnDashCooldownUpdated += OnDashCooldownUpdated;
            
            UpdateSprite(_sprite);
        }
        private void OnDashCooldownUpdated(float cooldownTimer, float maxCooldown, int currentUsesLeft, int maxUsesLeft)
        {
            //UpdateCooldown();

            bool onMaxUses = currentUsesLeft == maxUsesLeft;
            float percentage = onMaxUses ? 0f : cooldownTimer / maxCooldown;
            UpdateCooldown(onMaxUses ? 0 : Mathf.CeilToInt(cooldownTimer), percentage);

            _leftUsesText.text = currentUsesLeft >= 1 ? currentUsesLeft.ToString() : "";

            if (maxUsesLeft <= 1)
            {
                _leftUsesText.text = "";
            }

        }
    }
}