using UnityEngine;

namespace Combat {
    public abstract class Enemy : Character {
        protected Transform target;
        
        [Header("Enemy")]
        public string enemyName;

        protected virtual bool IsAtTarget { get; set; }
        protected float canAttack;
        protected float attackSpeed = 1f;
        protected float attackDamage = 10f;

        protected override void Die() {
            base.Die();
            // TODO: Drop Loot and Exp
            Destroy(gameObject);
        }
    }
}