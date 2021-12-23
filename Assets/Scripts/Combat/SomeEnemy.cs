using System;
using UnityEngine;

namespace Combat
{
    public class SomeEnemy : Enemy
    {
        [Header("Attack Range")] [SerializeField]
        private float attackRange = 3f;

        [Header("Gizmos Attack Range")] [SerializeField]
        private Color gizmosColor;

        [SerializeField] private bool showGizmos;

        private AIPlayerDetector _playerDetector;

        private float _attackTimer = 0f;

        protected override bool IsAtTarget => _playerDetector.DirectionToTarget.magnitude < attackRange;

        protected override void Start()
        {
            base.Start();
            _playerDetector = GetComponent<AIPlayerDetector>();
            _attackTimer = 1 / attackSpeed;
        }

        private void Update()
        {
            if (_playerDetector.PlayerDetected && IsAtTarget) Attack();
        }
        private void FixedUpdate()
        {
            //Debug.Log("Fixed: " + _playerDetector.PlayerDetected);

            if (_playerDetector.PlayerDetected && !IsAtTarget) Move();
        }
        private void Attack()
        {
            if (_attackTimer >= 0f)
            {
                _attackTimer -= Time.deltaTime;
                return;
            }

            _attackTimer = 1 / attackSpeed;
            _playerDetector.Target.GetComponent<Character>().TakeDamage(attackDamage, this, DamageType.Physical, false);
        }

        protected void Move()
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
    }
}