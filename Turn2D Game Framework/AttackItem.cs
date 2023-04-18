namespace Turn2D_Game_Framework
{
    public class AttackItem: WorldObject
    {

        public int HitPoints { get; set; }
        public bool IsInRange { get; set; }

        public AttackItem(Position position, string name, int hitpoints) : base(position, name)
        {
            this.position = position;
            Name= name;
            HitPoints = hitpoints;
        }


       
     


    }
}