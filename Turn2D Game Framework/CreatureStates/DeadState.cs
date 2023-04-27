using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turn2D_Game_Framework.Logging;
using Turn2D_Game_Framework.WorldItem;

namespace Turn2D_Game_Framework.CreatureStates
{
    public class DeadState : ICreatureState
    {
        public DeadState(ILogger? logger)
        {
            Logger = logger;
        }

        public ILogger? Logger { get; }

        public void Hit(Creature creature, AttackItem attackItem)
        {
            // Do nothing as the creature is already dead
        }

        public void ReceiveHit(Creature creature, AttackItem attackObject)
        {
            // Do nothing as the creature is already dead
        }

        public void Loot(Creature creature, WorldObject worldObject)
        {
            // Do nothing as the creature is already dead
        }
    }
}
