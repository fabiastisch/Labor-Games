using System.Collections.Generic;
using System.Linq;
using Combat;
using UnityEngine;
using Utils;


public class DragDmgAura : MonoBehaviour
{
    public DamageType damageType = DamageType.Physical;
    private List<Collider2D> enemyList = new List<Collider2D>();
    public float force = 1f;

    public float baseDamage = 2;
    [SerializeField] private float timer = 0.25f;
    [SerializeField] private float timerMax = 0.25f;

    /**
     * If Something Enters hitbox it gets dmg
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!enemyList.Contains(other))
        {
            enemyList.Add(other);

            if (other.gameObject.layer == 6)
            {
                Knockback(other);
            }
        }
    }

    private void Update()
    {
        //use time do Subtract things
        timer -= Time.deltaTime;
        //after Time is over do something and restart Timer
        if (timer <= 0f)
        {
            KnockBackList();
            timer += timerMax;
        }

    }


    private void Knockback(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            //Debug.LogWarning("Hit The Bat With the FUCKING Head");
            DoDmg(other.gameObject);
            Vector2 direction =
                (other.gameObject.transform.position - Util.GetLocalPlayer().gameObject.transform.position)
                .normalized;
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(-direction * force, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (enemyList.Contains(other))
            enemyList.Remove(other);
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
                if (other.gameObject.layer == 6)
                {
                   // Debug.LogWarning("Hit The Bat With the FUCKING Head");
                    Vector2 direction =
                        (other.transform.position - Util.GetLocalPlayer().gameObject.transform.position)
                        .normalized;
                    other.GetComponent<Rigidbody2D>().AddForce(-direction * force, ForceMode2D.Impulse);
                }
                DoDmg(other.gameObject);
            }
        }
    }

    private void DoDmg(GameObject enemy)
    {
        if (enemy.layer == 6)
        {
            enemy.GetComponent<Enemy>()?.TakeDamage(baseDamage, Util.GetLocalPlayer(), damageType);
            //Debug.Log("Hit something with FireWall");

        }

    }

}