using System;
using UI.CombatText;
using UnityEngine;
using Utils;

namespace Combat
{
    public abstract class Character : MonoBehaviour
    {
        [SerializeField] protected SpriteRenderer playSprite;
        [SerializeField] protected Rigidbody2D rb;

        [Header("Movement")] [SerializeField] protected float movementSpeed = 4f;

        [SerializeField] private float maxHealth = 100f;
        protected float _currentHealth;

        public static event Action<Character> OnEntityDies;


        protected void Reset()
        {
            playSprite = GetComponent<SpriteRenderer>();
            rb = GetComponent<Rigidbody2D>();
        }

        protected virtual void Start()
        {
            _currentHealth = maxHealth;
        }

        //protected abstract void Attack();
        //protected abstract void Die();

        //protected abstract void Move();

        //Swaps the sprite to the moving direction.
        protected void ChangeSpriteDirection(float direction)
        {
            if (direction < 0)
            {
                playSprite.flipX = true;
            }
            else if (direction > 0)
            {
                playSprite.flipX = false;
            }
        }

        public virtual void UpdateHealth(float amountHp)
        {
            if (amountHp > 0f)
            {
                Heal(amountHp);
            }
            else
            {
                TakeDamage(-amountHp);
            }
        }

        /**
         * Returns true if the entity dies
         */
        public virtual bool TakeDamage(float amountHp, Character enemy, DamageType damageType, bool isCrit = false)
        {
            if (enemy && enemy.Equals(Util.GetLocalPlayer()))// Check if the Attacker is the Player
            {
                Util.GetLocalPlayer().InvokeOnPlayerMakeACrit();
            }
            bool dies = TakeDamage(amountHp, damageType, isCrit);
            if (dies) OnEntityDies?.Invoke(enemy);
            return dies;
        }
        
        private bool TakeDamage(float amountHp, DamageType damageType = DamageType.Magical, bool isCrit = false)
        {
            _currentHealth -= amountHp;
            _currentHealth = _currentHealth < 0 ? 0 : _currentHealth;

            DamagePopup.Create(transform.position, amountHp, damageType, isCrit);
            if (_currentHealth == 0)
            {
                Debug.Log(gameObject.name + " died...");
                Die();
                return true;
            }
            return false;
        }

        protected virtual void Die()
        {
        }

        public virtual void Heal(float amountHp)
        {
            _currentHealth += amountHp;
            _currentHealth = _currentHealth > maxHealth ? maxHealth : _currentHealth;
        }

        public float GetMaxHealth()
        {
            return maxHealth;
        }

        public float GetActualHealth()
        {
            return _currentHealth;
        }

        /**
         * Percentage in values between 0 and 1
         */
        public float GetPercentageHpSmall()
        {
            return _currentHealth / maxHealth;
        }

        public int GetPercentageHpHigh()
        {
            return (int) (_currentHealth / maxHealth * 100f);
        }
    }
}