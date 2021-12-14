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


        protected override bool IsAtTarget => _playerDetector.DirectionToTarget.magnitude < attackRange;

        protected override void Start()
        {
            base.Start();
            _playerDetector = GetComponent<AIPlayerDetector>();
        }

        private void FixedUpdate()
        {
            //Debug.Log("Fixed: " + _playerDetector.PlayerDetected);

            if (_playerDetector.PlayerDetected && !IsAtTarget) Move();
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