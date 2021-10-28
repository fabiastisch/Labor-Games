using UnityEngine;

namespace LevelingAndClasses.ClassFolder
{
    // Not used
    // Class to define the UI of the Character, this will have a connection to the Actual Character
    public class UI_CharacterSkillAndPassive: MonoBehaviour
    {
        private ClassSlot classPassive1;
        private ClassSlot classPassive2;
        private ClassSlot classPassive3;
        private ClassSlot classPassive4;
    
        private ClassSlot classAbillity1;
        private ClassSlot classAbillity2;
        private ClassSlot classAbillity3;
        private ClassSlot classAbillity4;
    
        private ClassSlot HiddenPassive1;
        private ClassSlot HiddenPassive2;
        private ClassSlot HiddenPassive3;

        private ClassSlot HiddenAbillity1;
        private ClassSlot HiddenAbillity2;

        private ClassSlot Passive1;
        private ClassSlot Passive2;
        private ClassSlot Passive3;
        private ClassSlot Passive4;
        private ClassSlot Passive5;
        private ClassSlot Passive6;
        private ClassSlot Passive7;
        private ClassSlot Passive8;

        private void Awake()
        {
            classAbillity1 = transform.Find("ClassAbillitySlot1").GetComponent<ClassSlot>();
            classAbillity2 = transform.Find("ClassAbillitySlot2").GetComponent<ClassSlot>();
            classAbillity3 = transform.Find("ClassAbillitySlot3").GetComponent<ClassSlot>();
            classAbillity4 = transform.Find("ClassAbillitySlot4").GetComponent<ClassSlot>();

            Debug.Log("Awake - " + classAbillity1.name);
            classAbillity1.OnItemDropped += ClassAbillitySlot1_OnItemDropped;
            classAbillity2.OnItemDropped += ClassAbillitySlot2_OnItemDropped;
        }

        private void ClassAbillitySlot1_OnItemDropped(object sender, ClassSlot.OnItemDroppedEventArgs e)
        {
            Debug.Log("ClassAbillitySlot1_OnItemDropped");
            //Item dropped on first Abillity;
            Debug.Log("Dropped item" + e.skillsAndPassives);
            if(e.skillsAndPassives == SkillsAndPassivesType.ClassActive)
            {
                e.returnData.pointerDrag.GetComponent<DragDrop>().droppedOnSlot = true;
                e.returnData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = classAbillity1.GetComponent<RectTransform>().anchoredPosition;
           
            }
        }private void ClassAbillitySlot2_OnItemDropped(object sender, ClassSlot.OnItemDroppedEventArgs e)
        {
            Debug.Log("ClassAbillitySlot1_OnItemDropped");
            //Item dropped on first Abillity;
            Debug.Log("Dropped item" + e.skillsAndPassives.GetType());
            if(e.skillsAndPassives == SkillsAndPassivesType.ClassActive)
            {
                e.returnData.pointerDrag.GetComponent<DragDrop>().droppedOnSlot = true;
                e.returnData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = classAbillity2.GetComponent<RectTransform>().anchoredPosition;
           
            }
        }

    }
}
