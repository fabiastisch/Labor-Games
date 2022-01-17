using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Combat
{
    public class SomeEnemy : Enemy
    {
        [Header("Attack Range")] [SerializeField]
        protected float attackRange = 3f;

        [Header("Gizmos Attack Range")] [SerializeField]
        protected Color gizmosColor;

        [SerializeField] protected bool showGizmos;

        protected AIPlayerDetector _playerDetector;

        protected float _attackTimer = 0f;

        protected bool _isDead = false;

        protected override bool IsAtTarget => _playerDetector.DirectionToTarget.magnitude < attackRange;

        protected override void Start()
        {
            base.Start();
            _playerDetector = GetComponent<AIPlayerDetector>();
            _attackTimer = 1 / attackSpeed;
        }

        protected override void Update()
        {
            base.Update();
            if (_isDead) return;
            if (_playerDetector.PlayerDetected && IsAtTarget) Attack();
        }
        protected virtual void FixedUpdate()
        {
            //Debug.Log("Fixed: " + _playerDetector.PlayerDetected);
            if (_isDead) return;
            if (_playerDetector.PlayerDetected && !IsAtTarget) Move();
        }
        protected virtual void Attack()
        {
            if (_attackTimer >= 0f)
            {
                _attackTimer -= Time.deltaTime;
                return;
            }
            _attackTimer = 1 / attackSpeed;
            _playerDetector.Target.GetComponent<Character>().TakeDamage(attackDamage, this, DamageType.Physical, false);
        }

        protected virtual void Move()
        {
            //Debug.Log("Move");
            var directionToTarget = _playerDetector.DirectionToTarget;
            ChangeSpriteDirection(directionToTarget.x);
            float step = movementSpeed * Time.deltaTime;
            transform.position =
                Vector2.MoveTowards(transform.position, _playerDetector.Target.transform.position, step);
        }

        private void OnDrawGizmos()
        {
            if (showGizmos)
            {
                Gizmos.color = gizmosColor;
                Gizmos.DrawSphere(transform.position, attackRange);
            }
        }
        protected override void Die(Character enemy)
        {
            _isDead = true;
            base.Die(enemy);
            if (!GetType().IsSubclassOf(typeof(SomeEnemy))) Destroy(gameObject);
        }
    }
}