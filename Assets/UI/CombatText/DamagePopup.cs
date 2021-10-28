using Combat;
using TMPro;
using UnityEngine;
using Utils;

namespace UI.CombatText
{
    public class DamagePopup : MonoBehaviour
    {
        private static int sortingOrder = 0;

        [Header("FontSize")] [SerializeField] private float normalFontSize = 36;
        [SerializeField] private float criticalFontSize = 44;

        [Header("DamageTypes")] [SerializeField]
        private Color criticalOutlineColor;

        [SerializeField] private Color physicalDamageColor;
        [SerializeField] private Color magicDamageColor;
        [SerializeField] private Color poisonDamageColor;
        [SerializeField] private Color lightningDamageColor;
        [SerializeField] private Color frostDamageColor;
        [SerializeField] private Color fireDamageColor;
        [SerializeField] private Color shadowDamageColor;


        [Header("FadeOut")] [SerializeField] private Vector2 moveVector = new Vector2(.7f, 2f) * 25f;
        [SerializeField] private float disappearSpeed = 3f;
        [SerializeField] private float startDisappearTimer = 1f;

        [Header("HighlightSize")] [SerializeField]
        private float increaseScaleAmount = 1f;

        [SerializeField] private float decreaseScaleAmount = 1f;

        private TextMeshPro textMesh;
        private Color textColor;
        private float disappearTimerMax;

        public static DamagePopup Create(Vector2 position, float damageValue,
            DamageType damageType = DamageType.Physical, bool isCriticalHit = false)
        {
            Transform damagePopup = Instantiate(GameAssets.Instance.damagePopupPrefab, position, Quaternion.identity);

            DamagePopup popup = damagePopup.GetComponent<DamagePopup>();

            popup.Setup((int) damageValue, damageType, isCriticalHit);

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

        private void SetDamageTypColor(DamageType damageType)
        {
            switch (damageType)
            {
                case DamageType.Physical:
                    textColor = physicalDamageColor;
                    break;
                case DamageType.Magical:
                    textColor = magicDamageColor;
                    break;
                case DamageType.Fire:
                    textColor = fireDamageColor;
                    break;
                case DamageType.Frost:
                    textColor = frostDamageColor;
                    break;
                case DamageType.Lightning:
                    textColor = lightningDamageColor;
                    break;
                case DamageType.Poison:
                    textColor = poisonDamageColor;
                    break;
                case DamageType.Shadow:
                    textColor = shadowDamageColor;
                    break;
                default:
                    Debug.Log("Color not found for DamageType: " + damageType);
                    textColor = physicalDamageColor;
                    break;
            }

            textMesh.faceColor = textColor;
            //textMesh.color = textColor;
        }

        public void Setup(int damageAmount, DamageType damageType, bool isCriticalHit)
        {
            textMesh.SetText(damageAmount.ToString());

            SetDamageTypColor(damageType);

            if (isCriticalHit)
            {
                textMesh.fontSize = criticalFontSize;
                textMesh.outlineColor = criticalOutlineColor;
            }
            else
            {
                textMesh.fontSize = normalFontSize;
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
                textMesh.faceColor = textColor;
                if (textColor.a < 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}