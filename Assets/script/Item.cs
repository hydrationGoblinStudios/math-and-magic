using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Item
{
    public abstract string GiveName();
    public virtual void Update(PlayerBehavior player, int stacks)
    {

    }



    public class AmuletoCurativo : Item
    {
        public override string GiveName()
        {
            return "Amuleto Curativo";
        }
        public override void Update(PlayerBehavior player, int stacks)
        {
            player.health += 1 + (1 * stacks);
        }
    }
}
