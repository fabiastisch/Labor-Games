using Combat;
using UnityEngine;
using Utils;


public class AuraKnockback : MonoBehaviour
{
    public DamageType damageType = DamageType.Physical;
    //public GameObject impactEffect;
    public float force = 0.02f;

    /**
     * If Something Enters hitbox it gets dmg
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            Debug.LogWarning("Hit The Bat With the FUCKING Head");
            Vector2 direction =
                (other.gameObject.transform.position - Util.GetLocalPlayer().gameObject.transform.position)
                .normalized;
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * force, ForceMode2D.Impulse);
        }
    }

}