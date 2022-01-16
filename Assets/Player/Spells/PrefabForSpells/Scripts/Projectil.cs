using System.Collections.Generic;
using Combat;
using UnityEngine;
using Utils;

public class Projectil : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private Rigidbody2D rb;
    
    [SerializeField] private float baseDamage = 40;
    [SerializeField] private float damage;
    
    [SerializeField] private bool timeDestroy;
    [SerializeField] private float timeToDestroy;
    
    [SerializeField] private float factor;
    [SerializeField] private float scaleValue;
    
    [SerializeField] private float startTime;
    [SerializeField] private float resetTime;

    [SerializeField] private DamageType damageType = DamageType.Magical;

    [SerializeField]
    private ActualStatsThatGetUsed.ActualValues valueFactor = ActualStatsThatGetUsed.ActualValues.actualAbillityPower;
    
    private List<Collider2D> enemyList = new List<Collider2D>();


    public virtual void Update()
    {
        BaseDmgFromValueAndFactor();
        TimeScalingOption();
        startTime -= Time.deltaTime;
        if (startTime <= 0f)
        {
            TimeOption(enemyList);
            startTime += resetTime;
        }
    }

    public virtual void TimeScalingOption()
    {
    }

    public virtual void Start()
    {
        rb.velocity = transform.right * speed;
        if(timeDestroy)
            Invoke("DestroyAfterTime", timeToDestroy ); 
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            other.GetComponent<Enemy>()?.TakeDamage(baseDamage,Util.GetLocalPlayer() ,damageType);
        }
        EnterOption(other);
    }
    
    public virtual void OnTriggerExit2D(Collider2D other)
    {
        //Here to do in our Case Dmg
        if (other.gameObject.layer == 6)
        {
            other.GetComponent<Enemy>()?.TakeDamage(baseDamage,Util.GetLocalPlayer() ,damageType);
        }
        ExitOption(other);
    }

    public virtual void DestroyAfterTime()
    {
        Destroy(gameObject);
    }
    
    public virtual void BaseDmgFromValueAndFactor()
    {
        //scaleValue = ActualStatsThatGetUsed.Instance.ReturnValue((int) valueFactor);
        damage = scaleValue * factor;
        if (damage < baseDamage)
        {
            damage = baseDamage;
        }
    }
    
    public virtual void TimeOption( List<Collider2D> enemyList)
    {
    }
    
    public virtual void EnterOption(Collider2D other)
    {
        DestroyAfterTime();
    }
    
    public virtual void ExitOption(Collider2D other)
    {
        DestroyAfterTime();
    }
    
    
}
