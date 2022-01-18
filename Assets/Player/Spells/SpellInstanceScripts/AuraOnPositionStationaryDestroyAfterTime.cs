namespace LevelingAndClasses.LevelingScripts.Passives.Spells
{
   using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

    [CreateAssetMenu(menuName = "ScriptableObject/Spell/AuraOnPositionSationaryDestroyAfterTime")]
    public class AuraOnPositionStationaryDestroyAfterTime : Spell

    {
        // public float flyDuration;
        // public float speed;
        //I cant Drag a Scene Object into here so i need to initialize it in the script
        private Vector3 initializePos;

        [SerializeField] private int maxXDistance = 10;
        [SerializeField] private int maxYDistance = 10;
        // [SerializeField] private Animation CastAnimation;
    
        private List<GameObject> collection;
        [SerializeField] private bool destroy = true;
        public override void Activation(GameObject parent)
        {
            initializePos = Util.GetLocalPlayer().transform.position;
            AreaAttack();
           

        }

        void AreaAttack()
        {
            //Debug.Log("Cast AreaAttack");
            GameObject aoe = Instantiate(magicProjectile, initializePos, Quaternion.identity);
            collection.Add(aoe);
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
                    if(destroy)
                        Destroy(other.gameObject);
                }
            }
        }
    }
}