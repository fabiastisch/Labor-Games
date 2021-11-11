using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ClassAbillitySelection : MonoBehaviour
{

    private int selectedClassIndex;
    
    [Header("List of Classes")] [SerializeField]
    private List<ClassAbillitySelectionObject> classList = new List<ClassAbillitySelectionObject>();
    
    //read the Passive slots out
    [Header("Ui References")] 
    [SerializeField] private Text className;
    [SerializeField] private GameObject classAbillitySlot1;
    [SerializeField] private GameObject classAbillitySlot2;
    [SerializeField] private GameObject classAbillitySlot3;
    [SerializeField] private GameObject classAbillitySlot4;
    [SerializeField] private GameObject classAbillitySlot5;
    
    [SerializeField] private GameObject classAbillity1;
    [SerializeField] private GameObject classAbillity2;
    [SerializeField] private GameObject classAbillity3;
    [SerializeField] private GameObject classAbillity4;
    [SerializeField] private GameObject classAbillity5;
    
    [SerializeField] private GameObject classPassiveSlot1;
    [SerializeField] private GameObject classPassiveSlot2;
    [SerializeField] private GameObject classPassiveSlot3;
    [SerializeField] private GameObject classPassiveSlot4;
    [SerializeField] private GameObject classPassiveSlot5;
    [SerializeField] private GameObject classPassiveSlot6;
    
    //Objects that Hold the Sprite, Color and Passive
    [SerializeField] private GameObject classPassive1;
    [SerializeField] private GameObject classPassive2;
    [SerializeField] private GameObject classPassive3;
    [SerializeField] private GameObject classPassive4;
    [SerializeField] private GameObject classPassive5;
    [SerializeField] private GameObject classPassive6;

    private void Start()
    {
        UpdateClassSelection();
    }

    public void LeftButton()
    {
        selectedClassIndex--;
        if (selectedClassIndex < 0)
            selectedClassIndex = classList.Count - 1;

        UpdateClassSelection();
    }
    
    public void RightButton()
    {
        selectedClassIndex++;
        if (selectedClassIndex == classList.Count)
            selectedClassIndex = 0;
        
        
        UpdateClassSelection();
    }


    //Todo Color Alpha auf max stellen
    private void UpdateClassSelection()
    {
        classAbillity1.GetComponent<PassiveSlot>().passive = classList[selectedClassIndex].classAbillity1;
        classAbillity1.GetComponent<Image>().sprite = classList[selectedClassIndex].classAbillity1.passiveImage;
        classAbillity1.GetComponent<Image>().color = classList[selectedClassIndex].classAbillity1.color;

        classAbillity2.GetComponent<PassiveSlot>().passive  = classList[selectedClassIndex].classAbillity2;
        classAbillity2.GetComponent<Image>().sprite = classList[selectedClassIndex].classAbillity2.passiveImage;

        classAbillity3.GetComponent<PassiveSlot>().passive  = classList[selectedClassIndex].classAbillity3;
        classAbillity3.GetComponent<Image>().sprite = classList[selectedClassIndex].classAbillity3.passiveImage;
        //classAbillity3.GetComponent<Image>().color = classList[selectedClassIndex].classAbillity3.color;
        
        classAbillity4.GetComponent<PassiveSlot>().passive  = classList[selectedClassIndex].classAbillity4;
        classAbillity4.GetComponent<Image>().sprite = classList[selectedClassIndex].classAbillity4.passiveImage;
        //classAbillity4.GetComponent<Image>().color = classList[selectedClassIndex].classAbillity4.color;
        
        classAbillity5.GetComponent<PassiveSlot>().passive  = classList[selectedClassIndex].classAbillity5;
        classAbillity5.GetComponent<Image>().sprite = classList[selectedClassIndex].classAbillity5.passiveImage;
        //classAbillity5.GetComponent<Image>().color = classList[selectedClassIndex].classAbillity5.color;
        
        
        classPassive1.GetComponent<PassiveSlot>().passive  = classList[selectedClassIndex].classPassive1;
        classPassive1.GetComponent<Image>().sprite = classList[selectedClassIndex].classPassive1.passiveImage;
        //classPassive1.GetComponent<Image>().color = classList[selectedClassIndex].classPassive1.color;
        
        classPassive2.GetComponent<PassiveSlot>().passive  = classList[selectedClassIndex].classPassive2;
        classPassive2.GetComponent<Image>().sprite = classList[selectedClassIndex].classPassive2.passiveImage;
        //classPassive2.GetComponent<Image>().color = classList[selectedClassIndex].classPassive2.color;
        
        classPassive3.GetComponent<PassiveSlot>().passive  = classList[selectedClassIndex].classPassive3;
        classPassive3.GetComponent<Image>().sprite = classList[selectedClassIndex].classPassive3.passiveImage;
        //classPassive3.GetComponent<Image>().color = classList[selectedClassIndex].classPassive3.color;
        
        classPassive4.GetComponent<PassiveSlot>().passive  = classList[selectedClassIndex].classPassive4;
        classPassive4.GetComponent<Image>().sprite = classList[selectedClassIndex].classPassive4.passiveImage;
        //classPassive4.GetComponent<Image>().color = classList[selectedClassIndex].classPassive4.color;
        
        classPassive5.GetComponent<PassiveSlot>().passive  = classList[selectedClassIndex].classPassive5;
        classPassive5.GetComponent<Image>().sprite = classList[selectedClassIndex].classPassive5.passiveImage;
        //classPassive5.GetComponent<Image>().color = classList[selectedClassIndex].classPassive5.color;
        
        classPassive6.GetComponent<PassiveSlot>().passive  = classList[selectedClassIndex].classPassive6;
        classPassive6.GetComponent<Image>().sprite = classList[selectedClassIndex].classPassive6.passiveImage;
        //classPassive6.GetComponent<Image>().color = classList[selectedClassIndex].classPassive6.color;

        className.text = classList[selectedClassIndex].className;
    }
    
    //Todo Make it to a ScriptableObject
    [System.Serializable]
    public class ClassAbillitySelectionObject
    {
        public string className;
        public Passive classAbillity1;
        public Passive classAbillity2;
        public Passive classAbillity3;
        public Passive classAbillity4;
        public Passive classAbillity5;
            
        public Passive classPassive1;
        public Passive classPassive2;
        public Passive classPassive3;
        public Passive classPassive4;
        public Passive classPassive5;
        public Passive classPassive6;
    }
    
}
