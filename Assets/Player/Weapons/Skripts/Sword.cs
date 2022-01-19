using Combat;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;
using Weapons.Effects;
namespace EquipableWeapon
{
    public class Sword : Weapon
    {
        [Header("Sword-Stats")]
        private Animator animator;
        private float attackCD;
        public float baseAOERange;
        public float baseRange;
        public float baseAttackcooldown;

        // Start is called before the first frame update
        void Start()
        {
            base.Start();
            baseAOERange *= ((float)weaponRarity / 2);
            baseAttackcooldown /= ((float)weaponRarity / 2);
            animator = GetComponent<Animator>();
        }

        public override void Attack(InputAction.CallbackContext context,CombatStats combatStats, PlayerBase player)
        {
            if (attackCD < Time.time)
            {
                Util.GetLocalPlayer().Attacked();
                attackCD = Time.time + baseAttackcooldown;
                animator.Play("SwingSwordAnimation");
                Vector3 impactPos = transform.GetChild(0).position;
                // Enemy Layer is 6, to get the mask we have to shift from 1
                int enemyLayerMask = 1 << 6;
                Collider2D[] colliders = Physics2D.OverlapCircleAll(impactPos, baseRange, enemyLayerMask);
                foreach (Collider2D enemyCollider in colliders)
                {
                    Enemy enemy = enemyCollider.GetComponent<Enemy>();
                    if (enemy.GetComponent<Enemy>() != null)
                    {
                        enemy.TakeDamage(baseDamage, player, damageType);
                        if (baseStat != null) enemy.SetDebuff(baseStat);
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            if (!drawGizmos) return;
            Gizmos.color = new Color(1, 0, 0, 0.3f);
            Gizmos.DrawSphere(transform.GetChild(0).position, baseAOERange);
        }
    }
}