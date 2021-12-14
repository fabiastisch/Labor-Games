using Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effects
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
        private bool isSpawnt = false;

        public override void Activate(GameObject player) {
            RecolorSphere(spriteRenderer, elementTyp);
            time += Time.deltaTime * speed;
            if (!isSpawnt)
            {
                sphere = Instantiate(sphereToRotate, new Vector3(player.transform.position.x, player.transform.position.y, 0), Quaternion.identity);
                isSpawnt = true;
            }
            

            rotationCenter = player.transform.position;
            float posX = rotationCenter.x + Mathf.Cos(time) * radius;
            float posY = rotationCenter.y + Mathf.Sin(time) * radius;

            sphere.transform.position = new Vector2(posX, posY);

            //Enemy Layer == 6
            int enemyLayerMask = 1 << 6;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(sphere.transform.position, sphere.transform.localScale.x, enemyLayerMask);
            foreach (Collider2D enemyCollider in colliders)
            {
                enemyCollider.GetComponent<Enemy>()?.TakeDamage(baseDamage, elementTyp);
            }
        }
        public override void Deactivate()
        {
            isSpawnt = false;
            Destroy(sphere.gameObject);
        }

        private void RecolorSphere(SpriteRenderer sphereSprite, DamageType type)
        {
            switch (type)
            {
                case DamageType.Fire:
                    sphereSprite.color = Color.red;
                    return;
                case DamageType.Frost:
                    sphereSprite.color = Color.cyan;
                    return;
                case DamageType.Lightning:
                    sphereSprite.color = Color.yellow;
                    return;
                case DamageType.Physical:
                    sphereSprite.color = Color.gray;
                    return;
                case DamageType.Poison:
                    sphereSprite.color = Color.green;
                    return;
                case DamageType.Magical:
                    sphereSprite.color = Color.blue;
                    return;
                case DamageType.Shadow:
                    sphereSprite.color = Color.black;
                    return;
            }
        }
    }
}
