using System;
using UnityEngine;

namespace Combat {
    public class Dummy : MonoBehaviour, IAttackable {
        [SerializeField] private float hp = 100;

        public void Attack(float damage) {
            hp -= damage;
            if (hp <= 0) {
                throw new NotImplementedException("HP is less than 0");
            }
        }
    }
}