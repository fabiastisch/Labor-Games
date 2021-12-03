using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Manager/RecourceList")]
public class ResourceTypeListSO : ScriptableObject
{
   public List<ResourceTypeSO> list;
}
