using Combat;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Weapons.Effects
{
    [CreateAssetMenu (fileName= "RotatingEffect", menuName = "WeaponEffects/RotatingProjectile")]
    public class RotatingProjectile : Effect
    {
        //The weapon where to cast from
        private GameObject sphere;
        private float time = 0f;
        [Header("Object to rotate")] public SpriteRenderer spriteRenderer;
        public GameObject sphereToRotate;

        Vector2 rotationCenter;
        [Header("Rotationvalues")] public float speed = 5;
        public float radius = 2;

        public override void Activate(PlayerBase player) {

            Utils.ElementColoring.RecolorSpriteByDamagetyp(spriteRenderer, elementTyp);
            time += Time.deltaTime * speed;

            if (!sphere)
            {
                var playerPosition = player.transform.position;
                sphere = Instantiate(sphereToRotate, new Vector3(playerPosition.x, playerPosition.y, 0), Quaternion.identity);
;           }

            rotationCenter = player.transform.position;
            float posX = rotationCenter.x + Mathf.Cos(time) * radius;
            float posY = rotationCenter.y + Mathf.Sin(time) * radius;
            sphere.transform.position = new Vector2(posX, posY);

            //Enemy Layer == 6
            int enemyLayerMask = 1 << 6;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(sphere.transform.position, sphere.transform.localScale.x, enemyLayerMask);
            foreach (Collider2D enemyCollider in colliders)
            {
                enemyCollider.GetComponent<Enemy>()?.TakeDamage(baseDamage, player, elementTyp);
            }
        }
        public override void Deactivate()
        {
            Destroy(sphere.gameObject);
        }
    }
}
