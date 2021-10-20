using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
