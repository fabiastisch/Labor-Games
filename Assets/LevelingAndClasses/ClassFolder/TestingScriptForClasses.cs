using UnityEngine;

namespace LevelingAndClasses.ClassFolder
{
   public class TestingScriptForClasses : MonoBehaviour
   {
      public static TestingScriptForClasses Instance { get; private set; }
      private ClassInventory inventory;
      private void Awake()
      {
         Instance = this;
         inventory = new ClassInventory();
      }
   }
}
