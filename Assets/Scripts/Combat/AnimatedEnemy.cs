using System;
using System.Collections;
using UnityEngine;
namespace Combat
{
    public class AnimatedEnemy : SomeEnemy
    {
        protected string _currentState;
        protected Animator _animator;

        protected override void Start()
        {
            base.Start();
            _animator = GetComponent<Animator>();
        }
        protected void ChangeAnimationState(string newStateName)
        {
            if (_currentState == newStateName) return;

            _animator.Play(newStateName);
            _currentState = newStateName;
        }

        public IEnumerator PlayAndWaitAnimation(string currentAnim, Action oncomplete)
        {
            ChangeAnimationState(currentAnim);

            //Wait until we enter the current state
            while (!_animator.GetCurrentAnimatorStateInfo(0).IsName(currentAnim)) yield return null;

            //Now, Wait until the current state is done playing
            while (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime % 1 < 0.99f) yield return null;

            if (oncomplete != null)
                oncomplete();
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            if (!_playerDetector.PlayerDetected) ChangeAnimationState("Idle");
        }

        protected override void Attack()
        {
            base.Attack();
            StartCoroutine(PlayAndWaitAnimation("Attack", () => ChangeAnimationState("None")));

        }
        protected override void Move()
        {
            base.Move();
            ChangeAnimationState("Move");
        }
        protected override void Die(Character enemy)
        {
            base.Die(enemy);
            StartCoroutine(PlayAndWaitAnimation("Death", () => Destroy(gameObject)));
            Invoke(nameof(DestroySelf), 0.6f);

        }
        private void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}