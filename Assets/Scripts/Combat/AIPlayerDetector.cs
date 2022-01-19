using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Combat
{
    public class AIPlayerDetector : MonoBehaviour
    {
        public bool PlayerDetected { get; private set; }
        public Vector2? DirectionToTarget => target? target.transform.position - detectorOrigin.position: (Vector2?) null;

        [Header("OverlapSphere Parameters")] [SerializeField]
        private Transform detectorOrigin;

        public float detectorSize = 5f;
        public Vector2 detectorOriginOffset = Vector2.zero;

        public float detectionDelay = 0.3f;

        public LayerMask detectorLayerMask = 128;

        [Header("LeaveDistance Parameters")]
        public float leaveDistanceSize = 7f;

        [SerializeField] private bool enableLeaveDistance = true;
        [SerializeField] private Color leaveGizmosColor = Color.gray;

        [Header("Gizmo Parameters")] public Color gizmoIdleColor = Color.green;
        public Color gizmoDetectedColor = Color.red;
        public bool showGizmos = true;

        private GameObject target;

        public UnityEvent OnPlayerEnteredEvent, OnPlayerExitEvent;

        public GameObject Target
        {
            get => target;
            private set
            {
                if (target)
                {
                    Character curr = target.GetComponent<Character>();
                    if (curr)
                    {
                        curr.OnDeath -= OnTargetDeath;
                    }
                }

                target = value;
                PlayerDetected = target != null;

                if (value)
                {
                    Character next = target.GetComponent<Character>();
                    if (next)
                    {
                        next.OnDeath += OnTargetDeath;
                    }
                }
            }
        }
        private void OnTargetDeath(Character obj)
        {
            target = null;
        }

        private void Start()
        {
            if (detectorOrigin == null) detectorOrigin = transform;
            StartCoroutine(DetectionCoroutine());
        }

        IEnumerator DetectionCoroutine()
        {
            yield return new WaitForSeconds(detectionDelay);
            if (enableLeaveDistance) PerformDetectionWithLeaveSize();
            PerformDetection();
            StartCoroutine(DetectionCoroutine());
        }

        private void PerformDetectionWithLeaveSize()
        {
            if (PlayerDetected)
            {
                Collider2D overLapColliderLeave =
                    Physics2D.OverlapCircle((Vector2) detectorOrigin.position + detectorOriginOffset, leaveDistanceSize,
                        detectorLayerMask);
                if (overLapColliderLeave == null)
                {
                    Target = null;
                }
            }
            else
            {
                PerformDetection();
            }
        }

        private void PerformDetection()
        {
            /*Collider2D overLapCollider = Physics2D.OverlapBox((Vector2) detectorOrigin.position + detectorOriginOffset,
                detectorSize, 0, detectorLayerMask);*/
            Collider2D overLapCollider =
                Physics2D.OverlapCircle((Vector2) detectorOrigin.position + detectorOriginOffset, detectorSize,
                    detectorLayerMask);

            if (overLapCollider != null)
            {
                if (!PlayerDetected) OnPlayerEnteredEvent?.Invoke();
                Target = overLapCollider.gameObject;
            }
            else
            {
                if (enableLeaveDistance) return;
                if (PlayerDetected) OnPlayerExitEvent?.Invoke();
                Target = null;
            }
        }

        private void OnDrawGizmos()
        {
            if (showGizmos && detectorOrigin != null)
            {
                if (enableLeaveDistance)
                {
                    Gizmos.color = leaveGizmosColor;
                    Gizmos.DrawSphere(transform.position, leaveDistanceSize);
                }

                Gizmos.color = PlayerDetected ? gizmoDetectedColor : gizmoIdleColor;
                //Gizmos.DrawCube((Vector2) detectorOrigin.position + detectorOriginOffset, detectorSize);

                Gizmos.DrawSphere(transform.position, detectorSize);
            }
        }
    }
}