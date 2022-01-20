using System.Collections.Generic;
using System.Linq;
using Dungeon;
using UnityEngine;
using Utils;

namespace Player.Passives.PassiveForClasses
{
    [CreateAssetMenu
        (menuName = "ScriptableObject/Passive/AoeAfterMoveCondtion")]
    public class PassiveAoeAfterMoveCondition : LevelPassive
    {
        private List<GameObject> collection = new List<GameObject>();
        [SerializeField] private GameObject aoeObject;

        [SerializeField] private bool hasImportantCooldown;
        [SerializeField] private bool invincible = false;
        public override void Activation(GameObject parent)
        {
            SpawnAoe();
        }

        public override void BeginCooldown(GameObject parent)
        {
            if (hasImportantCooldown)
            {
                DestroyCollection();
            }
        }


        public override void Removed(GameObject parent)
        {
            DestroyCollection();
        }

        private void SpawnAoe()
        {
            GameObject aoe = Instantiate(aoeObject, Util.GetLocalPlayer().transform.position, Quaternion.identity);
            collection.Add(aoe);
        }

        private void DestroyCollection()
        {
            Util.GetLocalPlayer().Invulnerable = false;
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
    }
}