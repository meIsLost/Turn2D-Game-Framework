namespace Turn2D_Game_Framework
{
    public class DefenceItem: WorldObject
    {

        public int ReduceHitPoints { get; set; }
        public DefenceItem(Position position, string name, int ReduceHitPoints) : base(position, name)
        {
            this.ReduceHitPoints = ReduceHitPoints;
            this.position = position;
            this.Name= name;
        }
 
    }
}