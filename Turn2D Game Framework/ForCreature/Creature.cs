
using System.Diagnostics;
using Turn2D_Game_Framework.CreatureStates;
using Turn2D_Game_Framework.Logging;
using Turn2D_Game_Framework.WorldItem;
using static System.Net.Mime.MediaTypeNames;

namespace Turn2D_Game_Framework
{
    public class Creature
    {
        private static ILogger? _logger;
        public static int DefaultHealth { get; set; } = 100;
        public static int DefaultDamage { get; set; } = 100;
        public int Health { get; set; }
        public string Name { get; set; }
        public Position position { get; set; }
        public List<AttackItem> AttackObjects { get; set; }
        public List<DefenceItem> DefenceObjects { get; set; }
        public  List<WorldObject> Inventory { get; set; }
        public ICreatureState State { get; set; }


        public Creature(int health, ILogger logger, string name, List<AttackItem> attackObjects, List<DefenceItem> defenceObjects, Position position)
        {
            Health = health;
            _logger = logger;
            Name = name;
            AttackObjects = attackObjects;
            DefenceObjects = defenceObjects;
           Inventory= new List<WorldObject>();
            this.position = position;
        }

       
        
        public bool Dead
        {
            get { return Health <= 0; }
        }

        public static void SetDefaultValues(int defaultDamage, int defaultHeath)
        {
            DefaultDamage = defaultDamage;
            DefaultHealth = defaultHeath;
            _logger?.Log(TraceEventType.Information, $"Default values for creature are set. Default damage: {defaultDamage}, default health: {defaultHeath}");
        }


        public void Hit(Creature target, AttackItem attackItem)
        {
            //var distance = PositionCheck(target);
            //if (distance <= 5)
            //{


                // Calculate damage based on the attack object's hit points and the target's defence objects
                int damage = attackItem.HitPoints;

                foreach (var defenceItem in target.DefenceObjects)
                {
                    damage -= defenceItem.ReduceHitPoints;
                }
                if (damage < 0)
                {
                    damage = 0;
                }

                // Inflict damage on the target creature

                target.ReceiveHit(attackItem);

                // Output the damage dealt
                _logger?.Log(TraceEventType.Warning, ($"{Name} dealt {damage} damage to {target.Name}"));
            //}
            //else
            //{
            //    Console.WriteLine("Cannot fight because enemy is too far");
            //    _logger?.Log(TraceEventType.Information, ($"Cannot fight because enemy is too far"));
            //}
        }

        public void ReceiveHit(AttackItem attackObject)
        {
            // for swords
            attackObject.IsInRange = true;
            // Check if the attack object is in range to hit this creature
            if (attackObject.IsInRange)
            {
                // Calculate the damage based on the attack object's hit points and the creature's defence objects
                int damage = attackObject.HitPoints;
                foreach (var defenceObject in DefenceObjects)
                {
                    damage -= defenceObject.ReduceHitPoints;
                }
                if (damage < 0)
                {
                    damage = 0;
                }

                // Apply the damage to this creature
                Health -= damage;

                // Output the damage received
                _logger?.Log(TraceEventType.Warning, ($"{Name} received {damage} damage from an {attackObject.Name}"));

                // Check if the creature's health is below 50, and if so, set the state to "hurt" if it's not already in that state
                if (Health < 50 && !(State is HurtState))
                {
                    State = new HurtState(_logger);
                    _logger?.Log(TraceEventType.Critical, $"{Name}'s state has been changed to hurt state limiting some actions");
                }

            }
            else
            {
                // Output a message indicating that the attack missed due to being out of range
                _logger?.Log(TraceEventType.Warning, ($"{attackObject.GetType().Name} missed {GetType().Name} due to being out of range"));
            }
        }


        public void Loot(WorldObject worldObject)
        {
            // Check if the world object is lootable
            if (worldObject.IsLootable)
            {
                // Check if the world object is removable
                if (worldObject.IsRemovable)
                {
                    // Remove the world object from the game world
                    Inventory.Add(worldObject);
                    World.Objects?.Remove(worldObject);
                    
                }

                // Output a message indicating what was looted
                _logger?.Log(TraceEventType.Warning, ($"{Name} looted {worldObject.Name} and added to their inventory"));


            }
            else
            {
                // Output a message indicating that the world object is not lootable
                _logger?.Log(TraceEventType.Warning,($"{worldObject.Name} is not lootable"));
            }
        }



        //public double PositionCheck(Creature target)
        //{
        //   var distance= position.DistanceTo(target);

        //    return distance;

        //}


    }


}