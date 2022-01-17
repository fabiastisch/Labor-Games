using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Combat;

namespace Combat
{
    public enum DebuffTypes {

        DamageDebuff,
        ActionDebuff,
        StatsDebuff,
        DmgAndActionDebuff,
        StatsAndActionDebuff,
        DmgAndStatsDebuff,
        TrippleDebuff
    }

    public class DebuffHandler : MonoBehaviour
    {
        private Character character;
        private DebuffTypeSO debuff;

        private float timer = 0;

        private bool debuffedOnce = false;

        // Start is called before the first frame update
        void Start()
        {
            character = gameObject.GetComponent<Character>();
        }

        // Update is called once per frame
        void Update()
        {
            if (character.GetDebuff() == null)
            {
                debuffedOnce = false;
                return;
            }
            debuff = character.GetDebuff();
            timer += Time.deltaTime;
            
            //dmg per Second
            if (debuff.debufftype == DebuffTypes.DamageDebuff)
            {  
                if (timer >= 1)
                {
                    debuff.MakeDamage(character);
                    timer = 0;
                }
                return;
            }

            //Debuffing once
            if(debuff.debufftype == DebuffTypes.StatsDebuff)
            {
                if (!debuffedOnce)
                {
                    debuff.ChangeStats(character);
                    debuffedOnce = true;
                }
                return;
            }

        }
    }
}

