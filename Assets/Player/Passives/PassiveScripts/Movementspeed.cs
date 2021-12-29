using UnityEngine;

[CreateAssetMenuAttribute(menuName = "Passives/Movementspeed")]
public class Movementspeed : Passive
{
    public float movementspeed = 1f;
    private StatTypeListSO statTypeList;
     private void Awake()
        { 
            statTypeList = Resources.Load<StatTypeListSO>(typeof(StatTypeListSO).Name);
        }
    public override void Activation(GameObject parent)
    {
        Debug.Log("Movementspeed Perk Activation");
        // PassiveTestPlayer player =  parent.GetComponent<PassiveTestPlayer>();
        //
        // player.movementspeed += movementspeed;
        //
        // player.GetStats();
        StatManager.Instance.AddStat(statTypeList.list[9], movementspeed);
        

    }

    public override void BeginCooldown(GameObject parent)
    {
        Debug.Log("Movementspeed deactivated");
        // PassiveTestPlayer player =  parent.GetComponent<PassiveTestPlayer>();
        //
        // player.movementspeed -= movementspeed;
        //
        // player.GetStats();
        StatManager.Instance.RemoveStat(statTypeList.list[9], movementspeed);
    }
}