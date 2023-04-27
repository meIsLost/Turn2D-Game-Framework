namespace Turn2D_Game_Framework.WorldItem
{
    public class WorldObject : IWorldItem
    {

        public bool IsRemovable { get; set; }
        public string Name { get; set; }
        public bool IsLootable { get; set; }

        public Position position { get; set; }


        public WorldObject(Position position, string name)
        {
            this.position = position;
            Name = name;

        }
        public  void AddToWorld()
        {
            World.Objects?.Add(this);
        }

        public void RemoveFromWorld()
        {
            World.Objects?.Remove(this);
        }
    }
}