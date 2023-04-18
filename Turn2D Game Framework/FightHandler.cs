using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Turn2D_Game_Framework;

namespace Turn2D_Game_Framework
{
    public class FightHandler
    {
        public static void Fight(Creature creature1, Creature creature2)
        {
            Console.WriteLine($"{creature1.Name} ({creature1.Health} HP) is fighting {creature2.Name} ({creature2.Health} HP)");

            while (!creature1.Dead && !creature2.Dead)
            {

                PotionCheck(creature1);
                PotionCheck(creature2);

                
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
                Console.WriteLine($"{creature1.Name} has been defeated!");
            }
            else
            {
                Console.WriteLine($"{creature2.Name} has been defeated!");
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
    }
   
}
