using System.Collections;
using System.Collections.Generic;
using Combat;
using Player;
using UnityEngine;
using Utils;

namespace Dungeon.Spikes
{
    public class ArrowTrap : MonoBehaviour
    {
        [SerializeField] private float damageInterval = .2f;
        [SerializeField] private float damage = 12f;
        [SerializeField] private DamageType damageType;
        [SerializeField] private bool isCrit;

        private Animator animator;

        private List<Collider2D> playersInTrap = new List<Collider2D>();

        public float startDelay = 0f;

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            InvokeRepeating(nameof(ApplyDamage), .5f, damageInterval);
            StartCoroutine(nameof(DelayedAnimation));
        }

        // The delay coroutine
        IEnumerator DelayedAnimation()
        {
            animator.Play("Idle");
            yield return new WaitForSeconds(startDelay);
            animator.Play("MoveUP");
        }

        private void ApplyDamage()
        {
            if (playersInTrap.Count == 0) return;
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Down")) return;


            foreach (Collider2D col in playersInTrap)
            {
                //DamagePopup.Create(col.transform.position, damage);
                col.GetComponent<PlayerBase>().TakeDamage(damage, damageType, isCrit);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            //Debug.Log("OnTriggerEnter2D: " + other.gameObject.name);
            if (other.CompareTag("Player") || other.CompareTag("Vulnerable"))
            {
                playersInTrap.Add(other);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            //Debug.Log("OnTriggerExit2D: " + other.gameObject.name);
            if (other.CompareTag("Player") || other.CompareTag("Vulnerable"))
            {
                playersInTrap.Remove(other);
            }
        }
    }
}