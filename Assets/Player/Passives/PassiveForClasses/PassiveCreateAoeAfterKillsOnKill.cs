using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenuAttribute(menuName = "ScriptableObject/Passive/KillPassiveAoeOnKill")]
public class PassiveCreateAoeAfterKillsOnKill : LevelPassive
{
    [SerializeField] private float killsNeeded = 10;
    [SerializeField] private float actualKills = 0;

    [SerializeField] private GameObject aoeObject;

    //[SerializeField] private List<GameObject> collection = new List<GameObject>();
    
    //Gets the dead player
    public override void Activation(GameObject parent)
    {
        actualKills++;
        if (actualKills >= killsNeeded)
        {
            actualKills = 0;
            SpawnObject(parent);
        }
    }

    public override void BeginCooldown(GameObject parent)
    {
        base.BeginCooldown(parent);
    }

    // public override void Removed(GameObject parent)
    // {
    //     if (!collection.Any())
    //     {
    //         return;
    //     }
    //
    //     for (int counter = collection.Count - 1; counter >= 0; counter--)
    //     {
    //         if (collection[counter] != null)
    //         {
    //             GameObject other = collection[counter].gameObject;
    //             Destroy(other.gameObject);
    //         }
    //     }
    //     collection.Clear();
    // }

    private void SpawnObject(GameObject dead)
    {
        GameObject aoe = Instantiate(aoeObject, dead.transform.position, Quaternion.identity);
        //collection.Add(aoe);
    }
}
