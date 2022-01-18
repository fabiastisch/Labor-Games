using System;
using System.Collections.Generic;
using System.Collections;
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
        public event Action<Character> OnDeath;
        public event Action OnHealthChanged;

        public List<DebuffTypeSO> currentDebuffList = new List<DebuffTypeSO> { };

        #region HealthRegeneration
        public float healthRegeneration = 1f;
        private bool isRegenHealth = false;
        private float healthRegenRate = 1f;
        #endregion

        public Shields shields = new Shields();

        public event Action OnInvulnerableChanges;
        private bool _invulnerable = false;
        public bool Invulnerable
        {
            get => _invulnerable;
            set
            {
                _invulnerable = value;
                OnInvulnerableChanges?.Invoke();
            }
        }

        //Updating Method
        protected virtual void Update()
        {
            if (_currentHealth < maxHealth && !isRegenHealth)
            {
                StartCoroutine(RegainHealth());
            }

            if (currentDebuffList.Count > 0)
            {
                foreach (DebuffTypeSO debuff in currentDebuffList)
                {
                    debuff.UpdateDebuff(this);
                }
            }
        }

        protected void Reset()
        {
            playSprite = GetComponent<SpriteRenderer>();
            rb = GetComponent<Rigidbody2D>();
        }

        protected virtual void Start()
        {
            _currentHealth = maxHealth;
            OnHealthChanged?.Invoke();
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
        public virtual bool TakeDamage(float amountHp, Character enemy, DamageType damageType, bool isSpell = false, bool isCrit = false)
        {
            if (isSpell)
                if (Util.GetLocalPlayer().Equals(enemy))
                    Util.GetLocalPlayer().InvokeOnPlayerHitSpell(this.gameObject);

            if (enemy && enemy.Equals(Util.GetLocalPlayer())) // Check if the Attacker is the Player
            {
                Util.GetLocalPlayer().InvokeOnPlayerMakeACrit();
            }
            bool dies = TakeDamage(amountHp, damageType, isCrit);
            if (dies)
            {
                OnEntityDies?.Invoke(enemy);
                OnDeath?.Invoke(enemy);
                Die(enemy);
            }
            return dies;
        }

        private bool TakeDamage(float amountHp, DamageType damageType = DamageType.Magical, bool isCrit = false)
        {
            // check Invulnerable
            if (Invulnerable) return false;
            // Take Damage on Shield
            amountHp = shields.TakeDamage(amountHp);
            // Reduce actual Health
            _currentHealth -= amountHp;
            _currentHealth = _currentHealth < 0 ? 0 : _currentHealth;

            DamagePopup.Create(transform.position, amountHp, damageType, isCrit);
            OnHealthChanged?.Invoke();
            if (_currentHealth == 0)
            {
                Debug.Log(gameObject.name + " died...");
                return true;
            }
            return false;
        }

        protected virtual void Die(Character enemy)
        {
        }

        public virtual void Heal(float amountHp)
        {
            _currentHealth += amountHp;
            _currentHealth = _currentHealth > maxHealth ? maxHealth : _currentHealth;
            OnHealthChanged?.Invoke();
        }


        public void SetDebuff(DebuffTypeSO debuff)
        {
            debuff.currentlyApplied = true;
            if (currentDebuffList.Contains(debuff)) return;
            currentDebuffList.Add(debuff);
        }

        public void RemoveDebuff(DebuffTypeSO debuff)
        {
            if (!currentDebuffList.Contains(debuff)) return;
            currentDebuffList.Remove(debuff);
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

        public void AddShield(Shield shield)
        {
            shields.Add(shield);
        }
        public bool HasShield()
        {
            return shields.HasShield();
        }

        private IEnumerator RegainHealth()
        {
            isRegenHealth = true;
            while (_currentHealth < maxHealth)
            {
                Heal(healthRegeneration);
                yield return new WaitForSeconds(healthRegenRate);
            }
            isRegenHealth = false;
        }

    }
}