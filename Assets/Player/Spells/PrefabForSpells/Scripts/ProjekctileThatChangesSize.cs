using UnityEngine;

namespace Player.Spells.PrefabForSpells.Scripts
{
    public class ProjekctileThatChangesSize : Projectil
    {
        [SerializeField] private float startScalingTime;
        [SerializeField] private float resetScalingTime;

        [SerializeField] private float sizeChange;
        public override void TimeScalingOption()
        {
            startScalingTime -= Time.deltaTime;
            if (startScalingTime <= 0f)
            {
                var transform1 = transform;
                transform1.localScale = transform1.localScale * sizeChange;
                startScalingTime = resetScalingTime;
            }
        }
    }
}