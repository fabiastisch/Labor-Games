using System.Collections.Generic;
using Combat;
using UnityEngine;
using Utils;

public class MagicAoeExplosion : MonoBehaviour
{
    public float baseDamage = 40;
    public float factor = 0.2f;
    public int activeTime = 1;

    [SerializeField] private StatTypeSO statType;

    private List<Collider2D> enemyInAoeList = new List<Collider2D>();

    public DamageType damageType = DamageType.Magical;
    //public GameObject impactEffect;
    
    void Start()
    {
        Invoke("DestroyAfterTime", activeTime );
        baseDamage = StatManager.Instance.GetStat(statType) * factor;
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
    
    public void DestroyAfterTime()
    {
        Destroy(gameObject);
    }
    
}
