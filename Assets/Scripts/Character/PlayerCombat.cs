using System;
using UnityEngine;

namespace Character {
    public class PlayerCombat: MonoBehaviour {
        public Transform attackPoint;
        [SerializeField] private float attackRange = 0.5f;
        [SerializeField] private LayerMask enemyLayers;
        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                Attack();
            }
        }

        void Attack() {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            String hitlist = "Hitted " + hitEnemies.Length + " Objects:\n\t";
            foreach (var enemy in hitEnemies) {
                hitlist += enemy.name + " ";
            }

            Debug.Log(hitlist);
        }

        private void OnDrawGizmosSelected() {
            if (attackPoint == null)return;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}