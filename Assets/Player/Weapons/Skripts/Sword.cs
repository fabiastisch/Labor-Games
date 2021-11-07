using Combat;
using UnityEngine;

namespace EquipableWeapon
{
    public class Sword : Weapon
    {
        private Animator animator;
        private float attackCD;

        // Start is called before the first frame update
        void Start()
        {
            base.Start();
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            //weaponEffeckt.DoEffekt();
        }

        public override void Attack(CombatStats combatStats)
        {
            if (attackCD < Time.time)
            {
                attackCD = Time.time + baseAttackcooldown;
                animator.Play("SwingSwordAnimation");
                Vector3 impactPos = transform.GetChild(0).position;
                // Enemy Layer is 6, to get the mask we have to shift from 1
                int enemyLayerMask = 1 << 6;
                Collider2D[] colliders = Physics2D.OverlapCircleAll(impactPos, baseRange, enemyLayerMask);
                foreach (Collider2D enemyCollider in colliders)
                {
                    enemyCollider.GetComponent<Enemy>()?.TakeDamage(baseDamage, damageType);
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