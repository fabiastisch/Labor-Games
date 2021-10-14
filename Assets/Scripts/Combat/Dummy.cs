using System;
using UnityEngine;

namespace Combat {
    public class Dummy : MonoBehaviour, IAttackable {
        [SerializeField] private float maxHealth = 100;
        private float currentHealth;

        private void Start() {
            currentHealth = maxHealth;
        }

        public void TakeDamage(float damage) {
            maxHealth -= damage;
            if (maxHealth <= 0) {
                throw new NotImplementedException("HP is less than 0");
            }
        }
    }
}