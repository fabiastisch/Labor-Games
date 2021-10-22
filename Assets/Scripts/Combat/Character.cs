using UnityEngine;

namespace Combat
{
    public abstract class Character : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer playSprite;
        [SerializeField] private Rigidbody2D rb;

        [Header("Movement")] [SerializeField] protected float movementSpeed = 4f;

        [SerializeField] private float maxHealth = 100f;
        private float _currentHealth;

        protected void Reset()
        {
            playSprite = GetComponent<SpriteRenderer>();
            rb = GetComponent<Rigidbody2D>();
        }

        protected virtual void Start()
        {
            _currentHealth = maxHealth;
        }

       // protected abstract void Attack();
        protected abstract void Die();

        protected abstract void Move();
        
        //Swaps the sprite to the moving direction.
        protected void ChangeSpriteDirection(float direction) {
            if (direction < 0) {
                playSprite.flipX = true;
            }
            else if (direction > 0) {
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

        protected virtual void TakeDamage(float amountHp)
        {
            _currentHealth -= amountHp;
            _currentHealth = _currentHealth < 0 ? 0 : _currentHealth;
            if (_currentHealth == 0)
            {
                Debug.Log(gameObject.name + " died...");
                Die();
            }
        }

        protected virtual void Heal(float amountHp)
        {
            _currentHealth += amountHp;
            _currentHealth = _currentHealth > maxHealth ? maxHealth : _currentHealth;
        }
    }
}