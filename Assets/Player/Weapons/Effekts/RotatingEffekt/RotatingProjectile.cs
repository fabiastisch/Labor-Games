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
        private GameObject weapon;
        public GameObject sphereToRotate;
        private GameObject sphere;
        private float time = 0f;

        Vector2 rotationCenter;
        public float speed = 5;
        public float radius = 2;
        private bool isSpawnt = false;

        private void Awake()
        {
            isSpawnt = false;
        }

        public override void Activate(GameObject EquipedWeapon) {
            weapon = EquipedWeapon;
            time += Time.deltaTime * speed;
            if (!isSpawnt)
            {
                sphere = Instantiate(sphereToRotate, new Vector3(weapon.transform.position.x, weapon.transform.position.y, 0), Quaternion.identity);
                isSpawnt = true;
            }

            rotationCenter = weapon.transform.position;
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
    }
}
