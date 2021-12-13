using System;
using System.Collections;
using System.Collections.Generic;
using Unity.CodeEditor;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

public class PassiveListEntry : MonoBehaviour
{
   [SerializeField]
   private GameObject passiveSlotted;
   [SerializeField]
   private ListOf8Passives listofPassives;
   
   public Sprite passiveSlottedSprite;
   public Sprite nopassiveSlotted;


   private void Start()
   {
      listofPassives = ListOf8Passives.Instance;
      Change();
   }

   public void SetPassiveSlotted(GameObject toSlot)
   {
      passiveSlotted = toSlot;
      passiveSlottedSprite = toSlot.GetComponent<Requirements>().unlockedSprite;
      Change();
      transform.GetComponent<Button>().enabled = true;
   }
   
   public void RemoveSlot()
   {
      if (passiveSlotted != null)
      {
         GameObject buffer = passiveSlotted;
         passiveSlotted = null;
         listofPassives.RemoveItem(buffer);
      }
      Change();
   }
   
   public void RemoveSlotWithOutList()
   {
      if (passiveSlotted != null)
      {
         passiveSlotted = null;
         transform.GetComponent<Button>().enabled = false;
      }
      Change();
   }

   private void Change()
   {
      if (passiveSlotted != null)
      {
         transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = passiveSlottedSprite;
         transform.GetComponent<Button>().enabled = true;
         return;
      }
      transform.GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite = nopassiveSlotted;
      transform.GetComponent<Button>().enabled = false;
   }
      
}
