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

        // Start is called before the first frame update
        void Start()
        {
            character = gameObject.GetComponent<Character>();
        }

        // Update is called once per frame
        void Update()
        {
            if (character.GetDebuff() == null) return;
            debuff = character.GetDebuff();
            timer += Time.deltaTime;
            
            if (debuff.debufftype == DebuffTypes.DamageDebuff)
            {  
                if (timer >= 1)
                {
                    debuff.MakeDamage(character);
                    timer = 0;
                }
            }

        }
    }
}

