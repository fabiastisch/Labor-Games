using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Combat
{
    public class AIPlayerDetector : MonoBehaviour
    {
        public bool PlayerDetected { get; private set; }
        public Vector2 DirectionToTarget => target.transform.position - detectorOrigin.position;

        [Header("OverlapSphere Parameters")] [SerializeField]
        private Transform detectorOrigin;

        public float detectorSize = 5f;
        public Vector2 detectorOriginOffset = Vector2.zero;

        public float detectionDelay = 0.3f;

        public LayerMask detectorLayerMask;

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
                target = value;
                PlayerDetected = target != null;
            }
        }

        private void Start()
        {
            if (detectorOrigin == null) detectorOrigin = transform;
            StartCoroutine(DetectionCoroutine());
        }

        IEnumerator DetectionCoroutine()
        {
            yield return new WaitForSeconds(detectionDelay);
            PerformDetection();
            StartCoroutine(DetectionCoroutine());
        }

        private void PerformDetection()
        {
            /*Collider2D overLapCollider = Physics2D.OverlapBox((Vector2) detectorOrigin.position + detectorOriginOffset,
                detectorSize, 0, detectorLayerMask);*/
            Collider2D overLapCollider =
                Physics2D.OverlapCircle((Vector2) detectorOrigin.position + detectorOriginOffset, detectorSize, detectorLayerMask);

            if (overLapCollider != null)
            {
                if (!PlayerDetected) OnPlayerEnteredEvent?.Invoke();
                Target = overLapCollider.gameObject;
            }
            else
            {
                if (PlayerDetected) OnPlayerExitEvent?.Invoke();
                Target = null;
            }
        }

        private void OnDrawGizmos()
        {
            if (showGizmos && detectorOrigin != null)
            {
                Gizmos.color = PlayerDetected ? gizmoDetectedColor : gizmoIdleColor;
                //Gizmos.DrawCube((Vector2) detectorOrigin.position + detectorOriginOffset, detectorSize);

                Gizmos.DrawSphere(transform.position, detectorSize);
            }
        }
    }
}