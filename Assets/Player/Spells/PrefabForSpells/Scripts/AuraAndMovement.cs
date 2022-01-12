using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

public class AuraAndMovement : AuraBase
{
    private List<Collider2D> enemyList = new List<Collider2D>();
    [SerializeField] private float force;
    [SerializeField] private bool push;
    [SerializeField] private bool dmg;
    

    public override void TimeOption()
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
                    Vector2 direction =
                        (other.gameObject.transform.position - Util.GetLocalPlayer().gameObject.transform.position)
                        .normalized;
                    if (push)
                        other.gameObject.GetComponent<Rigidbody2D>().AddForce(-direction * force, ForceMode2D.Impulse);
                    else
                        other.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);

                    if (dmg)
                        DoDmg(other.gameObject);
                }
            }
        }
    }
    
    public override void EnterOption(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            if (other.gameObject.layer == 6)
            {
                Vector2 direction =
                    (other.gameObject.transform.position - Util.GetLocalPlayer().gameObject.transform.position)
                    .normalized;
                if (push)
                    other.gameObject.GetComponent<Rigidbody2D>().AddForce(-direction * force, ForceMode2D.Impulse);
                else
                    other.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);

                if (dmg)
                    DoDmg(other.gameObject);
            }
        }
    }
}
