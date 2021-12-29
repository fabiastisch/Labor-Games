using System.Collections.Generic;
using Combat;
using UnityEngine;
using Utils;

public class MagicAoeExplosion : MonoBehaviour
{
    public int baseDamage = 40;
    public int activeTime = 1;

    private List<Collider2D> enemyInAoeList = new List<Collider2D>();

    public DamageType damageType = DamageType.Magical;
    //public GameObject impactEffect;
    
    void Start()
    {
        Invoke("DestroyAfterTime", activeTime ); 
    }
    
    
    /**
     * If Something Enters hitbox it gets dmg
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Here to do in our Case Dmg
        if(!enemyInAoeList.Contains(other))
            enemyInAoeList.Add(other);
        
        if (other.gameObject.layer == 6)
        {
            other.GetComponent<Enemy>()?.TakeDamage(baseDamage, Util.GetLocalPlayer(), damageType);
        }
    }
    
    void DestroyAfterTime()
    {
        Destroy(gameObject);
    }

    public void DestroyMe()
    {
        Destroy(gameObject); 
    }
}
