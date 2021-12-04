using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResourceManager : MonoBehaviour
{
    private Dictionary<ResourceTypeSO, float> resourceAmountDictionary;

    //Initialisations without external dependancy on Awake / with external dependancy on Start
    private void Awake()
    {
        //holds Type and Value of Resource
        resourceAmountDictionary = new Dictionary<ResourceTypeSO, float>();

        ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);

        //each resource starts with Amount 0;
        foreach (ResourceTypeSO resourceType in resourceTypeList.list)
        {
            resourceAmountDictionary[resourceType] = 0;
        }
    }

    //Shows Values of each Type
    private void TestLogResourceAmountDictionary()
    {
        foreach (ResourceTypeSO resourceType in resourceAmountDictionary.Keys)
        {
            Debug.Log(resourceType.nameString + ": " + resourceAmountDictionary[resourceType]);
        }
    }

    //Adds Resource of a Type with a Amount
    public void AddResource(ResourceTypeSO resourceType, float amount)
    {
        resourceAmountDictionary[resourceType] += amount;
    }
    
    //Adds Resource of a Type with a Amount
    public void RemoveResource(ResourceTypeSO resourceType, float amount)
    {
        resourceAmountDictionary[resourceType] -= amount;
    }
}
