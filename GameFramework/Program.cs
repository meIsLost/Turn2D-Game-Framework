// See https://aka.ms/new-console-template for more information
using System;
using System.Runtime.CompilerServices;
using Turn2D_Game_Framework;

using Turn2D_Game_Framework.ForCreature;

World world = new World(100, 100);

Position positionOfPotion = new Position(1, 2);
Position positionOfSword = new Position(1, 2);
Position positionOfShield= new Position(1, 3);


WorldObject potion = new WorldObject(positionOfPotion, "potion");
potion.AddToWorld();

AttackItem attackItem = new AttackItem(positionOfSword, "sword", 15);
attackItem.AddToWorld();

DefenceItem defenceItem = new DefenceItem(positionOfShield, "shield", 10);
defenceItem.AddToWorld();

Creature creature = new CreatureFactory()
    .WithHealth(100)
    .WithName("Zoro")
    .WithPosition(new Position(1, 5))
    .WithAttackObject(attackItem)
    .WithDefenceObject(defenceItem)
    
    .Build();


potion.IsLootable= true;
potion.IsRemovable= true;
creature.Loot(potion);

Creature creature2 = new CreatureFactory()
    .WithHealth(100)
    .WithName("Mihawk")
    .WithPosition(new Position(1, 6))
    .WithAttackObject(attackItem)
    .WithDefenceObject(defenceItem)
    
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

