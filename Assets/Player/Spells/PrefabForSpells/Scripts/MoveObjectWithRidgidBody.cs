using UnityEngine;

namespace Player.Spells.PrefabForSpells.Scripts
{
    public class MoveObjectWithRidgidBody : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float speed = 20f;

        public virtual void Start()
        {
            rb.velocity = transform.right * speed;
        }
    }
}