using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Manager/DebuffList")]
public class DebuffTypeListSO : ScriptableObject
{
    public List<DebuffTypeSO> list;
}
