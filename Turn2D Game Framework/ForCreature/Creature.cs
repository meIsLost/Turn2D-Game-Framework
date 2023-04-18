namespace Turn2D_Game_Framework
{
    public class Creature
    {
        public int Health { get; set; }
        public string Name { get; set; }
        public Position position { get; set; }
        public List<AttackItem> AttackObjects { get; set; }
        public List<DefenceItem> DefenceObjects { get; set; }
        public  List<WorldObject> Inventory { get; set; }



        public Creature(int health, string name, List<AttackItem> attackObjects, List<DefenceItem> defenceObjects, Position position)
        {
            Health = health;
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


        public void Hit(Creature target, AttackItem attackItem)
        {
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
            Console.WriteLine($"{Name} dealt {damage} damage to {target.Name}");
        }

        public void ReceiveHit(AttackItem attackObject)
        {
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
                Console.WriteLine($"{Name} received {damage} damage from an {attackObject.Name}");
            }
            else
            {
                // Output a message indicating that the attack missed due to being out of range
                Console.WriteLine($"{attackObject.GetType().Name} missed {GetType().Name} due to being out of range");
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
                Console.WriteLine($"{Name} looted {worldObject.Name} and added to their inventory");


            }
            else
            {
                // Output a message indicating that the world object is not lootable
                Console.WriteLine($"{worldObject.Name} is not lootable");
            }
        }






    }


}