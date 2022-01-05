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
    [SerializeField] private GameObject szeneStats;

    public void ChangeToSingle()
    {
        szeneKlass.SetActive(false);
        szene8PassiveBackground.SetActive(true);
        szeneSinglePassive.SetActive(true);
        szeneDuoPassive.SetActive(false);
        szeneTripplePassive.SetActive(false);
        szenePentaPassive.SetActive(false);
        szeneStats.SetActive(false);
    }
    
    public void ChangeToDuo()
    {
        szeneKlass.SetActive(false);
        szene8PassiveBackground.SetActive(true);
        szeneSinglePassive.SetActive(false);
        szeneDuoPassive.SetActive(true);
        szeneTripplePassive.SetActive(false);
        szenePentaPassive.SetActive(false);
        szeneStats.SetActive(false);
    }
    public void ChangeToTripple()
    {
        szeneKlass.SetActive(false);
        szene8PassiveBackground.SetActive(true);
        szeneSinglePassive.SetActive(false);
        szeneDuoPassive.SetActive(false);
        szeneTripplePassive.SetActive(true);
        szenePentaPassive.SetActive(false);
        szeneStats.SetActive(false);
    }
    
    public void ChangeToPenta()
    {
        szeneKlass.SetActive(false);
        szene8PassiveBackground.SetActive(true);
        szeneSinglePassive.SetActive(false);
        szeneDuoPassive.SetActive(false);
        szeneTripplePassive.SetActive(false);
        szenePentaPassive.SetActive(true);
        szeneStats.SetActive(false);
    }
    
    public void ChangeToClass()
    {
        szeneKlass.SetActive(true);
        szene8PassiveBackground.SetActive(false);
        szeneSinglePassive.SetActive(false);
        szeneDuoPassive.SetActive(false);
        szeneTripplePassive.SetActive(false);
        szenePentaPassive.SetActive(false);
        szeneStats.SetActive(false);
    }
    
    public void ChangeToStats()
    {
        szeneStats.SetActive(true);
        szeneKlass.SetActive(false);
        szene8PassiveBackground.SetActive(false);
        szeneSinglePassive.SetActive(false);
        szeneDuoPassive.SetActive(false);
        szeneTripplePassive.SetActive(false);
        szenePentaPassive.SetActive(false);
        ActualStatsThatGetUsed.Instance.StatChanged();
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
