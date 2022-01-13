using System.Collections.Generic;
using System.Linq;
using Combat;
using UnityEngine;


public class ElectricAura : AuraBase
{
    private List<Collider2D> enemyList = new List<Collider2D>();
    public GameObject thunderAoe;
    private List<GameObject> thunderList = new List<GameObject>();
    
    private void ThunderTrigger(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            //Debug.LogWarning("Bzzt");
            GameObject thunderObject = Instantiate(thunderAoe, other.transform.position, Quaternion.identity);
            thunderList.Add(thunderObject);
        }
    }

    public override void TimeOption( List<Collider2D> list)
    {
        enemyList = list;
        ThunderTriggerAll();
    }

    public override void EnterOption(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            ThunderTrigger(other);
        }
    }

    private void ThunderTriggerAll()
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
                    //Debug.LogWarning("Bzzt");
                    GameObject thunderObject = Instantiate(thunderAoe, other.transform.position, Quaternion.identity);
                    thunderList.Add(thunderObject);
                }
            }
        }
    }
    

}