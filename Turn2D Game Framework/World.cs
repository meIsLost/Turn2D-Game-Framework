namespace Turn2D_Game_Framework
{
    public  class World
        {
        public int MaxX { get; set; }
        public int MaxY { get; set; }


        public Creature creature { get; set; }

        public static List<Creature>? Creatures { get; set; }
        public static List<WorldObject>? Objects { get; set; }

        public World(int MaxX, int MaxY) 
        { 
            Creatures= new List<Creature>();
            Objects = new List<WorldObject>();
            this.MaxX = MaxX;
            this.MaxY = MaxY;
          
        }
        
        public static void AddCreature(Creature creature)
        {
            Creatures.Add(creature);
        }


        
    }
}