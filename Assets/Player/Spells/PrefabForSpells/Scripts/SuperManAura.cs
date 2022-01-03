using System.Collections.Generic;
using System.Linq;
using Combat;
using UnityEngine;
using Utils;

public class SuperManAura : MonoBehaviour
{
    public DamageType damageType = DamageType.Magical;
    private List<Collider2D> enemyList = new List<Collider2D>();

    [SerializeField] private float maxHpFactor = 0.05f;


    [SerializeField] private float timer = 2f;
    [SerializeField] private float timerMax = 2f;

    private void Update()
    {
        //todo add Charisma Referenz

        //use time do Subtract things
        timer -= Time.deltaTime;
        //after Time is over do something and restart Timer
        if (timer <= 0f)
        {
            KnockBackList();
            timer += timerMax;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!enemyList.Contains(other))
        {
            enemyList.Add(other);
            DoDmg(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (enemyList.Contains(other))
        {
            enemyList.Remove(other);
        }
    }

    private void KnockBackList()
    {
        if (!enemyList.Any())
        {
            return;
        }

        for (int counter = enemyList.Count - 1; counter >= 0; counter--)
        {
            if (enemyList[counter] != null)
            {
                GameObject other = enemyList[counter].gameObject;
                DoDmg(other);
            }
        }
    }

    private void DoDmg(GameObject other)
    {
        if (other.layer == 6)
        {
            float MaxHpDmg = other.GetComponent<Enemy>().GetMaxHealth() * maxHpFactor;

            other.GetComponent<Enemy>()?.TakeDamage(MaxHpDmg, Util.GetLocalPlayer(), damageType);
        }
    }
}