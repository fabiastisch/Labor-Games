using System.Collections.Generic;
using System.Linq;
using Combat;
using UnityEngine;


public class ElectricAura : MonoBehaviour
{
    public DamageType damageType = DamageType.Physical;
    private List<Collider2D> enemyList = new List<Collider2D>();
    public GameObject thunderAoe;

    private List<GameObject> thunderList = new List<GameObject>();

    [SerializeField] 
    private float timer = 1f;
    [SerializeField]
    private float timerMax = 1f;

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
                ThunderTrigger(other);
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
            ThunderTriggerAll();
            timer += timerMax;
        }
        
    }
    

    private void ThunderTrigger(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            Debug.LogWarning("Bzzt");
            GameObject thunderObject = Instantiate(thunderAoe, other.transform.position, Quaternion.identity);
            thunderList.Add(thunderObject);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if(enemyList.Contains(other))
            enemyList.Remove(other);
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
                    Debug.LogWarning("Bzzt");
                    GameObject thunderObject = Instantiate(thunderAoe, other.transform.position, Quaternion.identity);
                    thunderList.Add(thunderObject);
                }
            }
        }
    }

}