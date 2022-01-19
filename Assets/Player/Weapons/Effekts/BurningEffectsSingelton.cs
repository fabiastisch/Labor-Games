using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons.Effects
{
    public class BurningEffectsSingelton : Effect
    {
        public HpBurning debuff;
        // Start is called before the first frame update

        public virtual void DebuffEnemy(Combat.Character enemy)
        {
            debuff.damageType = elementTyp;
            enemy.SetDebuff(debuff);
        }
    }
}
