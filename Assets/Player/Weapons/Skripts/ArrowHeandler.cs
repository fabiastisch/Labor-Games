using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Combat;
using Player;
using Utils;

namespace EquipableWeapon
{
    public class ArrowHeandler : MonoBehaviour
    {
        private float speed;
        private float damage;
        private DamageType damageType;
        private PlayerBase player;
        private Vector2 mouseDirection;
        private bool isFlying = false;
        private Rigidbody2D rb;
        private float timer;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        private void FixedUpdate()
        {
            if (!isFlying) return;
            rb.MovePosition((Vector2)transform.position + mouseDirection * speed * Time.fixedDeltaTime);
        }

        void Update()
        {
            if (!isFlying) return;
            Vector3 impactPos = transform.GetChild(0).position;
            // Enemy Layer is 6, to get the mask we have to shift from 1
            int enemyLayerMask = 1 << 6;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(impactPos, 0.5f, enemyLayerMask);
            foreach (Collider2D enemyCollider in colliders)
            {
                Enemy enemy = enemyCollider.GetComponent<Enemy>();
                if (enemy.GetComponent<Enemy>() != null)
                {
                    enemy.TakeDamage(damage, player, damageType);
                    DestroyArrow();
                }
            }
        }

        public void setArrowStats(float speed, float damage, bool shouldfly, DamageType damageType, PlayerBase player)
        {
            this.speed = speed;
            this.damage = damage;
            this.damageType = damageType;
            this.player = player;
            isFlying = shouldfly;

            mouseDirection = (player.GetComponent<MouseTrack>().GetMouseWorldPositon() - (Vector2)player.transform.position).normalized;

            RotateArrow();
            Invoke("DestroyArrow", 3);
        }

        private void RotateArrow()
        {
            float degrees = (float)Util.GetAngleFromVector(mouseDirection);
            transform.eulerAngles = Vector3.forward * degrees;
        }

        private void DestroyArrow()
        {
            Destroy(gameObject);
        }

    }
}
