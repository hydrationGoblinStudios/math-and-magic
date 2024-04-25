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

    public virtual void EquacaoPar(PlayerBehavior player,EnemyBehavior enemy, int stacks)
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

    public class ManoplaPar : Item
    {
        public override string GiveName()
        {
            return "Manopla Par";
        }
        public override void EquacaoPar(PlayerBehavior player, EnemyBehavior enemy, int stacks)
        {
            enemy.health -= 2 + (2 * stacks);
        }
    }
}
