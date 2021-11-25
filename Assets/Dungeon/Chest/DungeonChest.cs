using System;
using UI.Scripts;
using UnityEngine;

namespace Dungeon.Chest
{
    public class DungeonChest : Interactable
    {
        [SerializeField] private Vector3 dropPosition;

        [SerializeField] private GameObject pItem;

        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _animator.Play("Idle");
        }

        public override void Interact()
        {
            // Can only be interacted once 
            isInteractable = false;
            SetUnInteractable();
            SetLayerInteractable(false);

            _animator.Play("Open");
            DropItems();
        }

        private void DropItems()
        {
            // TODO: Create Weapon or Item and drop it
            Debug.Log("Chest was opened...");
            Instantiate(pItem, transform.position + dropPosition, Quaternion.identity);
        }

        protected override void OnDrawGizmosSelected()
        {
            base.OnDrawGizmosSelected();
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position + dropPosition, 0.2f);
        }
    }
}