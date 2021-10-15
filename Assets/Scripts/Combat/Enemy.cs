using UnityEngine;

namespace Combat
{
    public class Enemy : MonoBehaviour
    {
        public float movementSpeed = 3f;
        private Transform target;
        private bool isAtTarget = false;
        [SerializeField] private float canAttack;
        private float attackSpeed = 1f;
        private float attackDamage = 10f;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                target = other.transform;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                target = null;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                isAtTarget = true;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                isAtTarget = false;
            }
        }

        private void FixedUpdate()
        {
            if (target != null)
            {
                if (!isAtTarget)
                {
                    float step = movementSpeed * Time.deltaTime;
                    transform.position = Vector2.MoveTowards(transform.position, target.position, step);
                }
                else
                {
                    if (attackSpeed <= canAttack)
                    {
                        target.gameObject.GetComponent<Health>().UpdateHealth(-attackDamage);
                        canAttack = 0f;
                    }
                    else canAttack += Time.deltaTime;
                }
            }
        }
    }
}