using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Player.Spells.PrefabForSpells.Scripts
{
    public class ProjektilWithHitAnimation : Projectil
    {
        public GameObject hitAnimation;
        [SerializeField] private float destroyHitAfterTime;

        private List<GameObject> hitCollection = new List<GameObject>();
        
        public override void TimeOption(List<Collider2D> enemyList)
        {
            base.TimeOption(enemyList);
        }

        public override void EnterOption(Collider2D other)
        {
            if (other.gameObject.layer == 6)
            {
                GameObject projectile = Instantiate(hitAnimation, other.transform.position, this.transform.rotation);
                hitCollection.Add(projectile);
                Invoke("DestroyAfter", destroyHitAfterTime);
                Destroy(self);
            }
        }

        public override void ExitOption(Collider2D other)
        {
            
        }

        public void DestroyAfter()
        {
            if (!hitCollection.Any())
            {
                return;
            }

            for (int counter = hitCollection.Count - 1; counter >= 0; counter--)
            {
                if (hitCollection[counter] != null)
                {
                    GameObject other = hitCollection[counter].gameObject;
                
                    Destroy(other.gameObject);
                }
            }
        }
    }
}