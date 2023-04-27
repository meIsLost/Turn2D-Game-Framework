using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turn2D_Game_Framework.WorldItem;

namespace Turn2D_Game_Framework.CreatureStates
{


    public interface ICreatureState
        {
            void Hit(Creature creature, AttackItem attackItem);
            void ReceiveHit(Creature creature, AttackItem attackObject);
            void Loot(Creature creature, WorldObject worldObject);
        }
    
   
}
