using System;
using UnityEngine;
using Utils.SceneLoader;

namespace Character
{
    public class PlayerCombat : MonoBehaviour
    {
        public Transform attackPoint;
        [SerializeField] private float attackRange = 0.5f;

        [SerializeField] private LayerMask enemyLayers;

        // TODO: Remove
        [SerializeField] private SceneLoader loader;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
            }

            // TODO: Remove
            if (Input.GetKey(KeyCode.P))
            {
                loader.LoadScene("Dungeon");
            }
        }

        void Attack()
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            String hitlist = "Hitted " + hitEnemies.Length + " Objects:\n\t";
            foreach (var enemy in hitEnemies)
            {
                hitlist += enemy.name + " ";
            }

            Debug.Log(hitlist);
        }

        private void OnDrawGizmosSelected()
        {
            if (attackPoint == null) return;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}