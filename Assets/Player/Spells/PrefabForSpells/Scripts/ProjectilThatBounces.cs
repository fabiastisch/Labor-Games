using UnityEngine;

namespace Player.Spells.PrefabForSpells.Scripts
{
    public class ProjectilThatBounces : Projectil
    {
        public override void EnterOption(Collider2D other)
        {
            if (other.gameObject.layer == 6 || other.gameObject.layer == 11)
            {
                this.gameObject.GetComponent<Rigidbody2D>().velocity =
                    -this.gameObject.GetComponent<Rigidbody2D>().velocity;
            }
        }
    }
}