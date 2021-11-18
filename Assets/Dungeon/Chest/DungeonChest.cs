using UI.Scripts;
using UnityEngine;

namespace Dungeon.Chest
{
    public class DungeonChest : Interactable
    {
        [SerializeField] public Vector3 dropPosition;

        public override void Interact()
        {
            // Can only be interacted once 
            isInteractable = false;

            DropItems();
        }

        private void DropItems()
        {
            // TODO: Create Weapon or Item and drop it
            Debug.Log("Chest was opened...");
        }

        protected override void OnDrawGizmosSelected()
        {
            base.OnDrawGizmosSelected();
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position + dropPosition, 0.2f);
        }
    }
}