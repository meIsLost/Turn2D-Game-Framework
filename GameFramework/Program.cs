// See https://aka.ms/new-console-template for more information
using System;
using System.Runtime.CompilerServices;
using Turn2D_Game_Framework;
using Turn2D_Game_Framework.ForCreature;
using Turn2D_Game_Framework.Logging;
using Turn2D_Game_Framework.Configuration;
using Turn2D_Game_Framework.WorldItem;
using Turn2D_Game_Framework.WorldItem.DecoratorPattern;

string path = "../../../../config.xml";
//Setup configuration
IConfig config = new Config();
ILogger logger = config.ConfigureFromFile(path);


World world = World.CreateNewWorld(100, 100, logger);

Position positionOfPotion = new Position(1, 2);
Position positionOfSword = new Position(1, 2);
Position positionOfShield= new Position(1, 3);


// create a basic world object
WorldObject myObject = new WorldObject(new Position(7, 8), "Stone");
myObject.AddToWorld();




// create a defence item decorator
DefenceItem myDefenceItem = new DefenceItem(new Position(0, 0), "My Defence Item", 5);
DefenceItemDecorator myDefenceItemDecorator = new DefenceItemDecorator(myDefenceItem, 2);

Console.WriteLine(myDefenceItemDecorator.ToString());   


WorldObject potion = new WorldObject(positionOfPotion, "potion");
potion.AddToWorld();

AttackItem attackItem = new AttackItem(positionOfSword, "sword", 15);
attackItem.AddToWorld();


AttackItemDecorator myAttackItemDecorator = new AttackItemDecorator(attackItem, 15);


DefenceItem defenceItem = new DefenceItem(positionOfShield, "shield", 10);
defenceItem.AddToWorld();

Creature creature = new CreatureFactory()
    .WithHealth(100)
    .WithName("Zoro")
    .WithPosition(new Position(1, 5))
    .WithAttackObject(attackItem)
    .WithDefenceObject(defenceItem)
    .WithLogger(logger)
    
    .Build();


potion.IsLootable= true;
potion.IsRemovable= true;
creature.Loot(potion);

Creature creature2 = new CreatureFactory()
    .WithHealth(100)
    .WithName("Mihawk")
    .WithPosition(new Position(1 , 6))
    .WithAttackObject(attackItem)
    .WithDefenceObject(defenceItem)
    .WithLogger(logger)
    .Build();



FightHandler.Fight(creature, creature2);

var list =  World.Objects.ToList();
foreach (var obj in list)
{
    Console.WriteLine($"Object: {obj.Name}, Position: ({obj.position.x}, {obj.position.y})");
}

var list2 = World.Creatures.ToList();

foreach (var obj in list2)
{
    Console.WriteLine($"Object: {obj.Name}, Position: ({obj.position.x}, {obj.position.y})");
}

