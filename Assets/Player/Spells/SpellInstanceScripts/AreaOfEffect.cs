using UnityEngine;
using Utils;

namespace LevelingAndClasses.LevelingScripts.Passives.Spells
{
    [CreateAssetMenu(menuName = "ScriptableObject/Spell/Flamewall")]
    public class AreaOfEffect : Spell

    {
        // public float flyDuration;
        // public float speed;
        //I cant Drag a Scene Object into here so i need to initialize it in the script
        private Vector3 initializePos;

        [SerializeField] private int maxXDistance = 10;
        [SerializeField] private int maxYDistance = 10;
        // [SerializeField] private Animation CastAnimation;
    

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
            Instantiate(magicProjectile, initializePos, Quaternion.identity);
        }
    }
}
