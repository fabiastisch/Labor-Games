using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

namespace Player.Passives.PassiveForClasses
{
    [CreateAssetMenu
        (menuName = "ScriptableObject/Passive/AfterTime")]
    public class AfterTimePassiveAoe : LevelPassive
    {
        [SerializeField] private GameObject aoeObject;
        [SerializeField] private List<GameObject> collection = new List<GameObject>();


        public override void Activation(GameObject parent)
        {
            SpawnObject();
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
            collection.Clear();
        }
        
        private void SpawnObject()
        {
            GameObject aoe = Instantiate(aoeObject, Util.GetLocalPlayer().transform.position, Quaternion.identity);
            collection.Add(aoe);
        }
    }
}