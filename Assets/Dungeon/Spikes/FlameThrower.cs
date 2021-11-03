using System.Collections;
using System.Collections.Generic;
using Combat;
using Player;
using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    [SerializeField] private float damageInterval = .2f;
    [SerializeField] private float damage = 12f;
    [SerializeField] private DamageType damageType;

    [SerializeField] private bool isCrit;

    // Start is called before the first frame update
    private Animator animator;

    private List<Collider2D> playersInTrap = new List<Collider2D>();

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating(nameof(ApplyDamage), .5f, damageInterval);
    }

    private void ApplyDamage()
    {
        if (playersInTrap.Count == 0) return;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("flamethrower_1_down")) return;


        foreach (Collider2D col in playersInTrap)
        {
            //DamagePopup.Create(col.transform.position, damage);
            col.GetComponent<PlayerBase>().TakeDamage(damage, damageType, isCrit);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playersInTrap.Add(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playersInTrap.Remove(other);
        }
    }
}