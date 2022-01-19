using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

namespace Player.Passives.PassiveForClasses
{
    [CreateAssetMenu(menuName = "ScriptableObject/Passive/PassiveAfterXAttacksAoe")]
    public class PassiveAfterXAttacks : LevelPassive
    {
        [SerializeField] private float attacksNeeded = 10;
        [SerializeField] private float actualAttacks = 0;

        [SerializeField] private GameObject aoeObject;
   
        [SerializeField] private List<GameObject> collection = new List<GameObject>();
       
        //Gets the dead player
        public override void Activation(GameObject parent)
        {
            if (actualAttacks >= attacksNeeded)
            {
                actualAttacks = 0;
                SpawnObject();
            }
        }
   
        public override void BeginCooldown(GameObject parent)
        {
            base.BeginCooldown(parent);
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
                    Destroy(other.gameObject);
                }
            }
        }
   
        private void SpawnObject()
        {
            GameObject aoe = Instantiate(aoeObject, Util.GetLocalPlayer().transform.position, Quaternion.identity);
            collection.Add(aoe);
        }
    }
}