namespace Turn2D_Game_Framework.WorldItem
{
    public class AttackItem : WorldObject
    {

        public int HitPoints { get; set; }
        public bool IsInRange { get; set; }

        public AttackItem(Position position, string name, int hitpoints) : base(position, name)
        {
           
            HitPoints = hitpoints;
        }
     






    }
}