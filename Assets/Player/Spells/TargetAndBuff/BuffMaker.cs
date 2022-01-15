using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

namespace Player.Spells.TargetAndBuff
{
    [CreateAssetMenu(menuName = "ScriptableObject/Spell/Buff")]
    public class BuffMaker : Spell
    {
        private List<GameObject> collection;
        [SerializeField] private Vector3 playerPosition;
        
        public  override void Activation(GameObject parent)
        {
            playerPosition = Util.GetLocalPlayer().transform.position;
            MagicProjectilemaker();
            Buff();
        }
        
        public virtual void MagicProjectilemaker()
        {
            GameObject projectile = Instantiate(magicProjectile, playerPosition, Quaternion.identity);
            projectile.transform.parent = Util.GetLocalPlayer().transform;
            collection.Add(projectile);
        }

        public virtual void Buff()
        {
            
        }

        public virtual void Debuff()
        {
            
        }
        
        public override void BeginCooldown(GameObject parent)
        {
            if (!collection.Any())
            {
                return;
            }

            for (int counter = collection.Count - 1; counter >= 0; counter--)
            {
                if (collection[counter] != null)
                {
                    GameObject other = collection[counter].gameObject;
                    Debuff();
                    Destroy(other.gameObject);
                }
            }
        }
        
        public override void Removed(GameObject parent)
        {
            if (!collection.Any())
            {
                return;
            }

            for (int counter = collection.Count - 1; counter >= 0; counter--)
            {
                if (collection[counter] != null)
                {
                    GameObject other = collection[counter].gameObject;
                    Debuff();
                    Destroy(other.gameObject);
                }
            }
        }
        
        
    }
}