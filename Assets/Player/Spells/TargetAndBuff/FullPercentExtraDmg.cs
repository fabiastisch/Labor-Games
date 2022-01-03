using Combat;
using Player;
using UnityEngine;
using Utils;

public class FullPercentExtraDmg : MonoBehaviour
{
    [SerializeField] private float percentage = 0.15f;
    [SerializeField] private float movementDmg = 7.5f;

    private bool CheckHP(GameObject enemyGameObject)
    {
        if(enemyGameObject.GetComponent<Enemy>().GetPercentageHpSmall() > 0.99f)
            return true;
        return false;
    }

    public void DoDmgIfFullLive(GameObject enemyGameObject)
    {
        StatTypeListSO statTypeList = Resources.Load<StatTypeListSO>(typeof(StatTypeListSO).Name);
        StatTypeSO statType = statTypeList.list[5]; //CritChance
        if (CheckHP(enemyGameObject))
        { 
           float hpDmg = enemyGameObject.GetComponent<Enemy>().GetMaxHealth() * percentage;
           enemyGameObject.GetComponent<Enemy>().TakeDamage(hpDmg, Util.GetLocalPlayer().GetComponent<PlayerTank>(),
               DamageType.Physical, Util.GetChanceBool(StatManager.Instance.GetStat(statType)));
        }
    }
    
    public void DoDmgIfMoved(GameObject enemyGameObject)
    {
        if (CheckHP(enemyGameObject))
        {
            enemyGameObject.GetComponent<Enemy>().TakeDamage(movementDmg, Util.GetLocalPlayer().GetComponent<PlayerTank>(),
                DamageType.Physical, false);
        }
    }
    
}
