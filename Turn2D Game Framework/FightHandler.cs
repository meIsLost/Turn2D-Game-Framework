
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Turn2D_Game_Framework;
using Turn2D_Game_Framework.Logging;

namespace Turn2D_Game_Framework
{
    public class FightHandler
    {
        private static ILogger? _logger;

        public FightHandler(ILogger logger)
        {
            _logger = logger;
        }
        public static void Fight(Creature creature1, Creature creature2)
        {


            PotionCheck(creature1);
            PotionCheck(creature2);

            _logger?.Log(TraceEventType.Critical, ($"{creature1.Name} ({creature1.Health} HP) is fighting {creature2.Name} ({creature2.Health} HP)"));

            var distance = PositionCheck(creature1,creature2);
            if (distance <= 5)
            {
                while (!creature1.Dead && !creature2.Dead)
                {

                
                        // creature1 attacks creature2
                        if (!creature2.Dead)
                        {
                            var attackObject = creature1.AttackObjects.FirstOrDefault();
                            if (attackObject != null)
                            {
                                creature1.Hit(creature2, attackObject);
                            }
                        }

                        // creature2 attacks creature1
                        if (!creature1.Dead)
                        {
                            var attackObject = creature2.AttackObjects.FirstOrDefault();
                            if (attackObject != null)
                            {
                                creature2.Hit(creature1, attackObject);
                            }
                        }
                }

                    if (creature1.Dead)
                    {
                        World.RemoveCreature(creature1);
                        Console.WriteLine($"{creature1.Name} has been defeated! and has been removed from the world");
                    }
                    else
                    {
                        World.RemoveCreature(creature2);
                        Console.WriteLine($"{creature2.Name} has been defeated! and has been removed from the world");
                    }
            }
            else
            {
                Console.WriteLine("Cannot fight because enemy is too far");
                _logger?.Log(TraceEventType.Information, ($"Cannot fight because enemy is too far"));
            }
        }

        public static void PotionCheck(Creature creature)
        {

            var  inv = creature.Inventory;
            foreach ( var item in inv)
            {
              if (  item.Name == "potion")
              {
                    creature.Health += 10;
              }
            }
            



        }
        public static double PositionCheck(Creature creature,Creature target)
        {
            var distance = creature.position.DistanceTo(target);

            return distance;
        }
    }
   
}
