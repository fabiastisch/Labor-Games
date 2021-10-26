using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Combat
{
    public class OldHealthWithSlider : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100f;
        private float currentHealth;
        [SerializeField] [CanBeNull] private GameObject sliderPrefab;
        private Slider slider;

        public virtual void Start()
        {
            currentHealth = maxHealth;
            if (sliderPrefab is { })
            {
                slider = Instantiate(sliderPrefab.gameObject, transform).GetComponentInChildren<Slider>();
            }

            UpdateSlider();
        }

        private void FixedUpdate()
        {
            if (slider.gameObject.activeSelf)
            {
                UpdateSliderPosition();
            }
        }

        private void UpdateSliderPosition()
        {
            if (Camera.main is { })
                slider.transform.position = Camera.main.WorldToScreenPoint(transform.position + (Vector3) Vector2.up);
            else Debug.Log("Camera.Main is Null");
        }

        public void UpdateHealth(float amountHp)
        {
            //Debug.Log("Update Health: " + currentHealth + " "+(amountHp >= 0 ? "+" : "") + amountHp);
            if (amountHp > 0f)
            {
                Heal(amountHp);
            }
            else
            {
                TakeDamage(-amountHp);
            }

            UpdateSlider();
        }

        private void UpdateSlider()
        {
            slider.value = currentHealth / maxHealth;
            if (slider.value > .9f)
            {
                slider.gameObject.SetActive(false);
            }
            else
            {
                slider.gameObject.SetActive(true);
                UpdateSliderPosition();
            }
        }

        private void TakeDamage(float amountHp)
        {
            currentHealth -= amountHp;
            currentHealth = currentHealth < 0 ? 0 : currentHealth;
            if (currentHealth == 0)
            {
                Debug.Log(gameObject.name + " Object died...");
            }
        }

        private void Heal(float amountHp)
        {
            currentHealth += amountHp;
            currentHealth = currentHealth > maxHealth ? maxHealth : currentHealth;
        }
    }
}