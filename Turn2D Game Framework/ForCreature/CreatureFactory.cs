using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Turn2D_Game_Framework.ForCreature
{
    public  class CreatureFactory
    {
        
            private int health;
            private string name;
            private Position position;
            private List<AttackItem> attackObjects = new List<AttackItem>();
            private List<DefenceItem> defenceObjects = new List<DefenceItem>();
            

            public CreatureFactory WithHealth(int health)
            {
                this.health = health;
                return this;
            }

            public CreatureFactory WithName(string name)
            {
                this.name = name;
                return this;
            }

            public CreatureFactory WithPosition(Position position)
            {
                this.position = position;
                return this;
            }

            public CreatureFactory WithAttackObject(AttackItem attackObject)
            {
                this.attackObjects.Add(attackObject);
                return this;
            }

            public CreatureFactory WithDefenceObject(DefenceItem defenceObject)
            {
                this.defenceObjects.Add(defenceObject);
                return this;
            }

           

            public Creature Build()
            {
                Creature creature = new Creature(health, name, attackObjects, defenceObjects, position);
                World.AddCreature(creature);
                return creature;
                
            }
    }

    
}
