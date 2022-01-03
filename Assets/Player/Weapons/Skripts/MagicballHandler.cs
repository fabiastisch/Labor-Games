using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Combat;
using Player;
using Utils;

namespace EquipableWeapon
{
    public class MagicballHandler : MonoBehaviour
    {
        [SerializeField] private GameObject aoeObject;

        private float missleSpeed;
        private float damage;
        private float aoeDamage;
        private float aoeTime;
        private float aoeRange;

        private Vector3 enemyPosition;

        private Rigidbody2D rb;
        private Vector2 mousePosition;
        
        private Magicwand magicWand;
        private PlayerBase player;
        private DamageType damageType;
        private MouseTrack mouseTrack;

        private bool isEnemyHit = false;
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            MousepositionDelay();
            rb.MovePosition((Vector2)transform.position + mousePosition * missleSpeed * Time.fixedDeltaTime);
        }

        private void Update()
        {
            int enemyLayerMask = 1 << 6;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, transform.localScale.x, enemyLayerMask);
            foreach (Collider2D enemyCollider in colliders)
            {
                Enemy enemy = enemyCollider.GetComponent<Enemy>();
                if (enemy.GetComponent<Enemy>() != null)
                {
                    enemy.TakeDamage(damage, player, damageType);
                    enemyPosition = enemy.transform.position;
                    isEnemyHit = true;
                    DestroyBall();
                }
            }
        }

        public void SetBallsStats(Magicwand magicWand, float missleSpeed, float damage, float aoeDamage, float aoeRange,float aoeTime, DamageType damageType, PlayerBase player)
        {
            this.magicWand = magicWand;
            this.missleSpeed = missleSpeed;
            this.damage = damage;
            this.aoeDamage = aoeDamage;
            this.aoeTime = aoeTime;
            this.player = player;
            this.damageType = damageType;
            this.aoeRange = aoeRange;

            mouseTrack = player.GetComponent<MouseTrack>();
            MousepositionDelay();

            Invoke("DestroyBall", 3);
        }

        private void MousepositionDelay()
        {
            mousePosition = mouseTrack.GetPlayerToMousePosition();
        }


        private void DestroyBall()
        {
            if (isEnemyHit)
            {
                SpawnAOE(enemyPosition);
            }
            else
            {
                SpawnAOE(transform.position);
            }
            
            magicWand.canFireAgain = true;
            Destroy(gameObject);
        }

        private void SpawnAOE(Vector3 position)
        {
            //TODO: Placing aoe-object to given radius
            GameObject placeableObject = Instantiate(aoeObject, position, Quaternion.identity);
            FireWall firewall = placeableObject.GetComponent<FireWall>();
            firewall.damageType = damageType;
            firewall.baseDamage = (int)aoeDamage;
            firewall.activeTime = (int)aoeTime;
        }
    }
}
