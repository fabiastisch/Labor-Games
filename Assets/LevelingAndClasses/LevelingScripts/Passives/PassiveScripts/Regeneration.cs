using UnityEngine;

[CreateAssetMenuAttribute(fileName = "Regeneration", menuName = "Passives/ShieldAfterSeconds")]
public class Regeneration : Passive
{
    public float healthperTime = 3;
    public override void Activation(GameObject parent)
    {
        PassiveTestPlayer player =  parent.GetComponent<PassiveTestPlayer>();

        if (player.MaxHp > player.ActualHP)
        {
            float hp = player.ActualHP;
            hp += healthperTime;
            if (hp > player.MaxHp)
            {
                hp = player.MaxHp;
            }

            player.ActualHP = hp;

        }
        
        player.GetStats();

    }

    public override void BeginCooldown(GameObject parent)
    {
    }
}
