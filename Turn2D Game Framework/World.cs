using System.Diagnostics;
using Turn2D_Game_Framework.Logging;
using Turn2D_Game_Framework.WorldItem;

namespace Turn2D_Game_Framework
{
    public  class World
        {
        public static World? _instance;
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        private static ILogger? _logger;
    

        public World(int maxX, int maxY, ILogger logger)
        {
            MaxX = maxX;
            MaxY = maxY;
            _logger = logger;
            Creatures = new List<Creature>();
            Objects = new List<WorldObject>();
        }

        public static int DefaultX { get; set; } = 100;
        public static int DefaultY { get; set; } = 100;
        public Creature creature { get; set; }

        public static List<Creature>? Creatures { get; set; }
        public static List<WorldObject>? Objects { get; set; }

        public static World CreateNewWorld(int maxX, int maxY,  ILogger logger)
        {
            if (_instance == null)
            {
                _instance = new World(maxX, maxY, logger );
                _logger?.Log(TraceEventType.Information, "World is created");
            }
            else
            {
                throw new InvalidOperationException("Object instance is already created");
            }
            return _instance;
        }

            public static void SetDefaultValues(int X, int Y)
            {
                ILogger _logger = Logger.GetInstance();
                DefaultX = X;
                DefaultY = Y;
                _logger.Log(TraceEventType.Information, $"Default values for world are set. MaxX: {X}, MaxY: {Y}");
            }

        public static void AddCreature(Creature creature)
        {
            Creatures.Add(creature);
        }

        public static void RemoveCreature(Creature creature)
        {
            Creatures.Remove(creature);
        }



    }
}