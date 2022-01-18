using System;
using Player;
using UnityEngine;

namespace Combat
{
    public abstract class Enemy : Character
    {
        protected Transform target;

        [Header("Enemy")]
        public string enemyName;

        protected virtual bool IsAtTarget { get; set; }
        protected float canAttack;
        [SerializeField] public float attackSpeed = 1f;
        [SerializeField] public float attackDamage = 10f;

        [SerializeField] private int experience = 50;

        protected override void Die(Character enemy)
        {
            base.Die(enemy);
            DropExperience(enemy);
            // TODO: Drop Loot and Exp
            
        }
        private void DropExperience(Character player)
        {
            PlayerLevelManager playerLevelManager = player.GetComponent<PlayerLevelManager>();
            if (playerLevelManager)
            {
                playerLevelManager.AddExp(experience);
            }

        }
    }
}