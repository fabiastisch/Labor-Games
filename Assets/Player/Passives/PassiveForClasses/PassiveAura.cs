using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Player.Passives.PassiveForClasses
{
    [CreateAssetMenu
        (menuName = "ScriptableObject/Passive/AuraOnPlayer")]
    public class PassiveAura : LevelPassive
    {
        [SerializeField] private GameObject aura;
        private List<GameObject> collection;
        
        public override void Activation(GameObject parent)
        {
            Aura();
        }

        public override void Removed(GameObject parent)
        {
            foreach (var aura in collection)
            {
                Destroy(aura);
            }
        }
        
        void Aura()
        {
            //Debug.Log("Cast AreaAttack");
            GameObject auraProjektil = Instantiate(aura, Util.GetLocalPlayer().transform.position, Quaternion.identity);
            Debug.Log(auraProjektil);
            auraProjektil.transform.parent = Util.GetLocalPlayer().transform;
            collection.Add(auraProjektil);
        }
    }
}