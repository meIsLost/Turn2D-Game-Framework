namespace Turn2D_Game_Framework
{
    public class WorldObject
    {

        public bool IsRemovable { get; set; }
        public  string Name { get; set; }
        public bool IsLootable { get; set; }

        public Position position { get; set; }


        public WorldObject(Position position, string name ) 
        {
            this.position = position;
            Name = name;
             
        }
        public void AddToWorld()
        {
            World.Objects?.Add(this);
        }

    }   
}