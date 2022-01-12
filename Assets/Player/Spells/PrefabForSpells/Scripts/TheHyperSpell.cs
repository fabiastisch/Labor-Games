using System.Collections.Generic;
using System.Linq;
using Combat;
using UnityEngine;
using Utils;

namespace Player.Spells.PrefabForSpells.Scripts
{
    public class TheHyperSpell
    {
        public DamageType damageType = Combat.DamageType.Physical;
        private List<Collider2D> enemyList = new List<Collider2D>();

        [SerializeField] private float damage;
        [SerializeField] private float baseDamage;
        [SerializeField] private float factor;

        private float scaleValue;

        [SerializeField] private float startTime;
        [SerializeField] private float resetTime;

        [SerializeField] private GameObject hitParticle;

        [SerializeField] private float damageAmplifyAfterTime;
        [SerializeField] private float damageMigationAfterTime;
        [SerializeField] private float destroyTime;

        [SerializeField] private bool dmgAfterEntry;

        [SerializeField] private float moveForce;

        [SerializeField] private TypeOfAbillity _typeOfAbillity;


        private enum TypeOfAbillity
        {
            Aura,
            AuraDestroyAfterTime,
            Aoe,
            AoeDestroyAfterTime,
            ScalingAoe,
            DegradingAoe,
            Projectile,
            ProjectileDestroyAfterTime,
            ProjectileDestroyOnHit,
            Buff,
            BuffDestroyAfterTime,
            OnEnemy
        }

        private void Update()
        {
            UpdateValue();

            switch (_typeOfAbillity)
            {
                case TypeOfAbillity.Aoe:
                    startTime -= Time.deltaTime;
                    if (startTime <= 0f)
                    {
                        DoDmgToAll();
                        startTime += resetTime;
                    }

                    break;
                case TypeOfAbillity.ScalingAoe:
                    startTime -= Time.deltaTime;
                    if (startTime <= 0f)
                    {
                        DoDmgToAll();
                        startTime += resetTime;
                        AmplifyDmg();
                    }

                    break;
                case TypeOfAbillity.DegradingAoe:
                    startTime -= Time.deltaTime;
                    if (startTime <= 0f)
                    {
                        DoDmgToAll();
                        startTime += resetTime;
                        AmplifyDmg();
                    }

                    break;
                case TypeOfAbillity.Aura:
                    startTime -= Time.deltaTime;
                    if (startTime <= 0f)
                    {
                        DoDmgToAll();
                        startTime += resetTime;
                    }

                    break;
                case TypeOfAbillity.Buff:
                    startTime -= Time.deltaTime;
                    if (startTime <= 0f)
                    {
                        DoDmgToAll();
                        startTime += resetTime;
                    }

                    break;
                case TypeOfAbillity.Projectile:
                    startTime -= Time.deltaTime;
                    if (startTime <= 0f)
                    {
                        DoDmgToAll();
                        startTime += resetTime;
                    }

                    break;
                case TypeOfAbillity.ProjectileDestroyOnHit:
                    startTime -= Time.deltaTime;
                    if (startTime <= 0f)
                    {
                        DoDmgToAll();
                        startTime += resetTime;
                    }

                    break;
                case TypeOfAbillity.OnEnemy:
                    startTime -= Time.deltaTime;
                    if (startTime <= 0f)
                    {
                        DoDmgToAll();
                        startTime += resetTime;
                    }

                    break;
                case TypeOfAbillity.AoeDestroyAfterTime:
                    startTime -= Time.deltaTime;
                    if (startTime <= 0f)
                    {
                        DoDmgToAll();
                        startTime += resetTime;
                    }

                    break;
                case TypeOfAbillity.AuraDestroyAfterTime:
                    startTime -= Time.deltaTime;
                    if (startTime <= 0f)
                    {
                        DoDmgToAll();
                        startTime += resetTime;
                    }

                    break;
                case TypeOfAbillity.BuffDestroyAfterTime:
                    startTime -= Time.deltaTime;
                    if (startTime <= 0f)
                    {
                        DoDmgToAll();
                        startTime += resetTime;
                    }

                    break;
                case TypeOfAbillity.ProjectileDestroyAfterTime:
                    startTime -= Time.deltaTime;
                    if (startTime <= 0f)
                    {
                        DoDmgToAll();
                        startTime += resetTime;
                    }
                    break;
            }
        }

        private void DoDmgToAll()
        {
            if (!enemyList.Any())
            {
                return;
            }

            for (int counter = enemyList.Count - 1; counter >= 0; counter--)
            {
                if (enemyList[counter] != null)
                {
                    GameObject enemy = enemyList[counter].gameObject;
                    if (enemy.layer == 6)
                    {
                        enemy.GetComponent<Enemy>()?.TakeDamage(damage, Util.GetLocalPlayer(), damageType);
                    }
                }
            }
        }

        private void DoDmg(GameObject enemy)
        {
            if (enemy.layer == 6)
            {
                enemy.GetComponent<Enemy>()?.TakeDamage(damage, Util.GetLocalPlayer(), damageType);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (enemyList.Contains(other)) return;
            enemyList.Add(other);
            if (!dmgAfterEntry) return;
            DoDmg(other.gameObject);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (enemyList.Contains(other))
                enemyList.Remove(other);
        }

        private void BaseDmgFromValueAndFactor()
        {
            baseDamage = scaleValue * factor;
            if (damage < baseDamage)
            {
                damage = baseDamage;
            }
        }

        private void AmplifyDmg()
        {
            damage += damage * damageAmplifyAfterTime;
        }

        private void DownGradeDmg()
        {
            damage -= damage * damageMigationAfterTime;
        }

        private void UpdateValue()
        {
            BaseDmgFromValueAndFactor();
        }

        private void MoveEnemy(bool drag, GameObject objectToMove)
        {
            if (drag)
            {
                if (objectToMove.gameObject.layer == 6)
                {
                    Vector2 direction =
                        (objectToMove.transform.position - Util.GetLocalPlayer().gameObject.transform.position)
                        .normalized;
                    objectToMove.GetComponent<Rigidbody2D>().AddForce(-direction * moveForce, ForceMode2D.Impulse);
                }
            }
            else
            {
                if (objectToMove.gameObject.layer == 6)
                {
                    Vector2 direction =
                        (objectToMove.transform.position - Util.GetLocalPlayer().gameObject.transform.position)
                        .normalized;
                    objectToMove.GetComponent<Rigidbody2D>().AddForce(-direction * moveForce, ForceMode2D.Impulse);
                }
            }
        }
    }
}