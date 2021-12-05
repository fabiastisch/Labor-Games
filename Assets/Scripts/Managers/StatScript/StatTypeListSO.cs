using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Manager/StatTypeList")]
public class StatTypeListSO : ScriptableObject
{
    public List<StatTypeSO> list;
}
