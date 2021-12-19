using Combat;
using UnityEngine;
using Utils;

public class FireWall : MonoBehaviour
{
    public Rigidbody2D rb;
    public int baseDamage = 20;
    public int activeTime = 5;
    

    public DamageType damageType = DamageType.Magical;
    //public GameObject impactEffect;
    
    void Start()
    {
        Invoke("DestroyAfterTime", activeTime ); 
    }
    
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Here to do in our Case Dmg
        if (other.gameObject.layer == 6)
        {
            other.GetComponent<Enemy>()?.TakeDamage(baseDamage, Util.GetLocalPlayer(), damageType);
            Debug.Log("Hit something with FireWall");
        }
        
        
        //TODO From Breakys if we have a Enemy we can trigger Dmg on it
        // Enemy enemy = GitInfo.GetComponent<Enemy>();
        // if (enemy != null)
        // {
        //     enemy.TakeDamage(damage);
        // }
        
        Debug.Log("Hit something with FireWall");

        //TODO if we want impactEffects we can use this
        //Instantiate(impactEffect, transform.position, transform.rotation);
        
        //Destroys the Object (Projectile)
    }

    void DestroyAfterTime()
    {
        Destroy(gameObject);
    }
}