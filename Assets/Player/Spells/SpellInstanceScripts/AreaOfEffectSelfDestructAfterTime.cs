using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

    [CreateAssetMenu(menuName = "ScriptableObject/Spell/AreaOfEffectSelfDestroyAfterTime")]
    public class AreaOfEffectSelfDestructAfterTime : Spell

    {
        // public float flyDuration;
        // public float speed;
        //I cant Drag a Scene Object into here so i need to initialize it in the script
        private Vector3 initializePos;

        [SerializeField] private int maxXDistance = 10;
        [SerializeField] private int maxYDistance = 10;
        // [SerializeField] private Animation CastAnimation;
    
        private List<GameObject> collection;
        public override void Activation(GameObject parent)
        {
            initializePos = Util.GetLocalPlayer().transform.GetComponent<MouseTrack>().GetMouseWorldPositon();

            if (Util.GetLocalPlayer().transform.position.x - initializePos.x >= -maxXDistance &&
                Util.GetLocalPlayer().transform.position.x - initializePos.x <= maxXDistance &&
                Util.GetLocalPlayer().transform.position.y - initializePos.y >= -maxYDistance &&
                Util.GetLocalPlayer().transform.position.y - initializePos.y <= maxYDistance)
            {
                AreaAttack();
            }
            else
                Debug.Log("Failed Area of Effect, cause of Range");

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
                
                    Destroy(other.gameObject);
                }
            }
        }
    }
    
    