using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSzeneController : MonoBehaviour
{

    [SerializeField] private GameObject szeneKlass;
    [SerializeField] private GameObject szene8PassiveBackground;
    [SerializeField] private GameObject szeneSinglePassive;
    [SerializeField] private GameObject szeneDuoPassive;
    [SerializeField] private GameObject szeneTripplePassive;
    [SerializeField] private GameObject szenePentaPassive;
    [SerializeField] private GameObject UI;

    public void ChangeToSingle()
    {
        szeneKlass.SetActive(false);
        szene8PassiveBackground.SetActive(true);
        szeneSinglePassive.SetActive(true);
        szeneDuoPassive.SetActive(false);
        szeneTripplePassive.SetActive(false);
        szenePentaPassive.SetActive(false);
    }
    
    public void ChangeToDuo()
    {
        szeneKlass.SetActive(false);
        szene8PassiveBackground.SetActive(true);
        szeneSinglePassive.SetActive(false);
        szeneDuoPassive.SetActive(true);
        szeneTripplePassive.SetActive(false);
        szenePentaPassive.SetActive(false);
    }
    public void ChangeToTripple()
    {
        szeneKlass.SetActive(false);
        szene8PassiveBackground.SetActive(true);
        szeneSinglePassive.SetActive(false);
        szeneDuoPassive.SetActive(false);
        szeneTripplePassive.SetActive(true);
        szenePentaPassive.SetActive(false);
    }
    
    public void ChangeToPenta()
    {
        szeneKlass.SetActive(false);
        szene8PassiveBackground.SetActive(true);
        szeneSinglePassive.SetActive(false);
        szeneDuoPassive.SetActive(false);
        szeneTripplePassive.SetActive(false);
        szenePentaPassive.SetActive(true);
    }
    
    public void ChangeToClass()
    {
        szeneKlass.SetActive(true);
        szene8PassiveBackground.SetActive(false);
        szeneSinglePassive.SetActive(false);
        szeneDuoPassive.SetActive(false);
        szeneTripplePassive.SetActive(false);
        szenePentaPassive.SetActive(false);
    }
    
    public void Escape()
    {
        UI.SetActive(false);
        szeneKlass.SetActive(true);
        szene8PassiveBackground.SetActive(false);
        szeneSinglePassive.SetActive(false);
        szeneDuoPassive.SetActive(false);
        szeneTripplePassive.SetActive(false);
        szenePentaPassive.SetActive(false);
    }
    
    public void OpenUI()
    {
        UI.SetActive(true);
        szeneKlass.SetActive(true);
        szene8PassiveBackground.SetActive(false);
        szeneSinglePassive.SetActive(false);
        szeneDuoPassive.SetActive(false);
        szeneTripplePassive.SetActive(false);
        szenePentaPassive.SetActive(false);
    }
}
