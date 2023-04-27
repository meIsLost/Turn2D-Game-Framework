using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turn2D_Game_Framework.Logging;
using Turn2D_Game_Framework.WorldItem;

namespace Turn2D_Game_Framework.CreatureStates
{
    public class HurtState : ICreatureState
    {
        
            private readonly ILogger _logger;

            public HurtState(ILogger logger)
            {
                _logger = logger;
            }

            public void Hit(Creature creature, AttackItem attackItem)
            {
                // Calculate damage based on the attack object's hit points and the creature's defence objects
                int damage = attackItem.HitPoints;
                foreach (var defenceItem in creature.DefenceObjects)
                {
                    damage -= defenceItem.ReduceHitPoints;
                }
                if (damage < 0)
                {
                    damage = 0;
                }

                // Inflict damage on the target creature
                creature.ReceiveHit(attackItem);

                // Output the damage dealt
                _logger?.Log(TraceEventType.Warning, ($"{creature.Name} dealt {damage} damage to {creature.Name}"));
            }

            public void ReceiveHit(Creature creature, AttackItem attackObject)
            {
                // Calculate the damage based on the attack object's hit points and the creature's defence objects
                int damage = attackObject.HitPoints;
                foreach (var defenceObject in creature.DefenceObjects)
                {
                    damage -= defenceObject.ReduceHitPoints;
                }
                if (damage < 0)
                {
                    damage = 0;
                }

                // Apply the damage to this creature
                creature.Health -= damage;

                // Output the damage received
                _logger?.Log(TraceEventType.Warning, ($"{creature.Name} received {damage} damage from an {attackObject.Name}"));

                // Check if the creature is dead
                if (creature.Health <= 0)
                {
                    creature.State = new DeadState(_logger);
                }
            }

            public void Loot(Creature creature, WorldObject worldObject)
            {
                // Output a message indicating that the creature cannot loot while in the injured state
                _logger?.Log(TraceEventType.Information, $"{creature.Name} cannot loot while in the injured state");
            }
        }

    }
