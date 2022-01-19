using System;
using Utils;

namespace Dungeon
{
    public class Spawn : GenericSingleton<Spawn>
    {
        private void Start()
        {
            //Util.GetLocalPlayer().transform.position = transform.position;
        }

        protected override void InternalInit()
        {
        }
        protected override void InternalOnDestroy()
        {
        }
        private void OnDestroy()
        {
            //Debug.Log("Destroy Spawn");
        }
    }
}