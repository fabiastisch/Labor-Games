using Player;
using UnityEngine;

namespace Combat
{
    public class SimpleEnemy : Enemy
    {
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
                IsAtTarget = true;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                IsAtTarget = false;
            }
        }

        private void FixedUpdate()
        {
            if (target != null)
            {
                if (!IsAtTarget)
                {
                    float step = movementSpeed * Time.deltaTime;
                    transform.position = Vector2.MoveTowards(transform.position, target.position, step);
                }
                else
                {
                    if (attackSpeed <= canAttack)
                    {
                        // TODO: implement health reduction
                        target.gameObject.GetComponent<PlayerBase>().TakeDamage(attackDamage, this, DamageType.Physical, false);
                        //target.gameObject.GetComponent<PlayerBase>().UpdateHealth(-attackDamage);
                        
                        canAttack = 0f;
                    }
                    else canAttack += Time.deltaTime;
                }
            }
        }

        protected void Move()
        {
            
        }
    }
}