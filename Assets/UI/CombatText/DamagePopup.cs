using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;

namespace UI.CombatText
{
    public class DamagePopup : MonoBehaviour
    {
        private static int sortingOrder = 0;

        [Header("FontSize")] [SerializeField] private float normalFontSize = 36;
        [SerializeField] private float criticalFontSize = 44;

        [Header("Colors")] [SerializeField] private Color normalColor;
        [SerializeField] private Color criticalColor;

        [Header("FadeOut")] [SerializeField] private Vector2 moveVector = new Vector2(.7f, 2f) * 25f;
        [SerializeField] private float disappearSpeed = 3f;
        [SerializeField] private float startDisappearTimer = 1f;

        [Header("HighlightSize")] [SerializeField]
        private float increaseScaleAmount = 1f;

        [SerializeField]private float decreaseScaleAmount = 1f;

        private TextMeshPro textMesh;
        private Color textColor;
        private float disappearTimerMax;

        public static DamagePopup Create(Vector2 position, float damageValue, bool isCriticalHit = false)
        {
            var pos = Camera.main.WorldToScreenPoint(position);
            Transform damagePopup = Instantiate(GameAssets.Instance.damagePopupPrefab, position, Quaternion.identity);

            DamagePopup popup = damagePopup.GetComponent<DamagePopup>();

            popup.Setup((int) damageValue, isCriticalHit);

            return popup;
        }

        private void Awake()
        {
            textMesh = transform.GetComponent<TextMeshPro>();
        }

        private void Start()
        {
            disappearTimerMax = startDisappearTimer;
        }

        public void Setup(int damageAmount, bool isCriticalHit)
        {
            textMesh.SetText(damageAmount.ToString());

            if (isCriticalHit)
            {
                textMesh.fontSize = criticalFontSize;
                textColor = criticalColor;
            }
            else
            {
                textMesh.fontSize = normalFontSize;
                textColor = normalColor;
            }

            sortingOrder++;
            textMesh.sortingOrder = sortingOrder;
        }

        private void Update()
        {
            transform.position += (Vector3) moveVector * Time.deltaTime;

            if (startDisappearTimer > disappearTimerMax / 2)
            {
                // First Half
                transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
            }
            else
            {
                // Second Half
                transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
            }

            startDisappearTimer -= Time.deltaTime;
            if (startDisappearTimer < 0)
            {
                // Start disappearing
                textColor.a -= disappearSpeed * Time.deltaTime;
                textMesh.color = textColor;
                if (textColor.a < 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}