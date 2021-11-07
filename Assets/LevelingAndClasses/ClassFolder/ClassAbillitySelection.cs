using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

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


    private void UpdateClassSelection()
    {
        classAbillity1 = classList[selectedClassIndex].classAbillity1;
        classAbillity2 = classList[selectedClassIndex].classAbillity2;
        classAbillity3 = classList[selectedClassIndex].classAbillity3;
        classAbillity4 = classList[selectedClassIndex].classAbillity4;
        classAbillity5 = classList[selectedClassIndex].classAbillity5;
        
        classPassive1 = classList[selectedClassIndex].classPassive1;
        classPassive2 = classList[selectedClassIndex].classPassive2;
        classPassive3 = classList[selectedClassIndex].classPassive3;
        classPassive4 = classList[selectedClassIndex].classPassive4;
        classPassive5 = classList[selectedClassIndex].classPassive5;
        classPassive6 = classList[selectedClassIndex].classPassive6;

        className.text = classList[selectedClassIndex].className;
    }

    //Todo change it to Passives instead of Gameobjects and add sprites to passives
    [System.Serializable]
    public class ClassAbillitySelectionObject
    {
        public string className;
        public GameObject classAbillity1;
        public GameObject classAbillity2;
        public GameObject classAbillity3;
        public GameObject classAbillity4;
        public GameObject classAbillity5;
            
        public GameObject classPassive1;
        public GameObject classPassive2;
        public GameObject classPassive3;
        public GameObject classPassive4;
        public GameObject classPassive5;
        public GameObject classPassive6;
    }
    
}
