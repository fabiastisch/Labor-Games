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
    [Header("Ui References")] [SerializeField]
    private Text className;

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
        ClassAbillitySelectionObject newClass = classList[selectedClassIndex];

        classAbillity1.GetComponent<PassiveAndActiveSlot>()
            .ChangeParameter(newClass.classType, newClass.classAbillity1, null);
        classAbillity2.GetComponent<PassiveAndActiveSlot>()
            .ChangeParameter(newClass.classType, newClass.classAbillity2, null);
        classAbillity3.GetComponent<PassiveAndActiveSlot>()
            .ChangeParameter(newClass.classType, newClass.classAbillity3, null);
        classAbillity4.GetComponent<PassiveAndActiveSlot>()
            .ChangeParameter(newClass.classType, newClass.classAbillity4, null);
        classAbillity5.GetComponent<PassiveAndActiveSlot>()
            .ChangeParameter(newClass.classType, newClass.classAbillity5, null);


        classPassive1.GetComponent<PassiveAndActiveSlot>()
            .ChangeParameter(newClass.classType, null, newClass.classPassive1);
        classPassive2.GetComponent<PassiveAndActiveSlot>()
            .ChangeParameter(newClass.classType, null, newClass.classPassive2);
        classPassive3.GetComponent<PassiveAndActiveSlot>()
            .ChangeParameter(newClass.classType, null, newClass.classPassive3);
        classPassive4.GetComponent<PassiveAndActiveSlot>()
            .ChangeParameter(newClass.classType, null, newClass.classPassive4);
        classPassive5.GetComponent<PassiveAndActiveSlot>()
            .ChangeParameter(newClass.classType, null, newClass.classPassive5);
        classPassive6.GetComponent<PassiveAndActiveSlot>()
            .ChangeParameter(newClass.classType, null, newClass.classPassive6);

        className.text = classList[selectedClassIndex].className;
    }

    //Todo Make it to a ScriptableObject
    [System.Serializable]
    public class ClassAbillitySelectionObject
    {
        public string className;
        public ClassEnum.Classes classType = ClassEnum.Classes.None;
        public Spell classAbillity1;
        public Spell classAbillity2;
        public Spell classAbillity3;
        public Spell classAbillity4;
        public Spell classAbillity5;

        public LevelPassive classPassive1;
        public LevelPassive classPassive2;
        public LevelPassive classPassive3;
        public LevelPassive classPassive4;
        public LevelPassive classPassive5;
        public LevelPassive classPassive6;
    }
}