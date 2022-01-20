using System;
using UnityEngine;

namespace UI.TabMap
{
    public class TabMap : MonoBehaviour
    {
        [SerializeField] private GameObject canvas;
        [SerializeField] private GameObject cam;

        [SerializeField] private Transform target;

        // Start is called before the first frame update
        void Start()
        {
            canvas.SetActive(true);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                canvas.SetActive(!canvas.activeSelf);
            }
        }

        private void LateUpdate()
        {
            var newPos = target.position;
            newPos.z = cam.transform.position.z;
            cam.transform.position = newPos;
        }
    }
}