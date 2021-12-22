using UnityEngine;

namespace LevelingAndClasses.LevelingScripts.Passives.Spells
{
    [CreateAssetMenu(menuName = "Abillitys/Flamewall")]
    public class AreaOfEffect : Passive

    {
        // public float flyDuration;
        // public float speed;
        [SerializeField] private GameObject magicProjectile;
    
        //I cant Drag a Scene Object into here so i need to initialize it in the script
        private Vector3 initializePos;

        [SerializeField] private int maxXDistance = 10;
        [SerializeField] private int maxYDistance = 10;
        // [SerializeField] private Animation CastAnimation;
    

        public override void Activation(GameObject parent)
        {
            initializePos = parent.transform.GetComponent<MouseTrack>().GetMouseWorldPositon();

            if (parent.transform.position.x - initializePos.x >= -maxXDistance &&
                parent.transform.position.x - initializePos.x <= maxXDistance &&
                parent.transform.position.y - initializePos.y >= -maxYDistance &&
                parent.transform.position.y - initializePos.y <= maxYDistance)
            {
                AreaAttack();
            }
            else
                Debug.Log("Failed Area of Effect, cause of Range");

        }

        public override void BeginCooldown(GameObject parent)
        {
            base.BeginCooldown(parent);
        }

        void AreaAttack()
        {
            Debug.Log("Cast AreaAttack");
            Instantiate(magicProjectile, initializePos, Quaternion.identity);
        }
    }
}
