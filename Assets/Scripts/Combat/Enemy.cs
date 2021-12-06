using UnityEngine;

namespace Combat
{
    public abstract class Enemy : Character
    {
        protected Transform target;

        protected virtual bool IsAtTarget { get; set; }
        protected float canAttack;
        protected float attackSpeed = 1f;
        protected float attackDamage = 10f;

        protected override void Die()
        {
            Destroy(gameObject);
        }
    }
}