using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn2D_Game_Framework.WorldItem.DecoratorPattern
{
    public class DefenceItemDecorator : WorldItemDecorator
    {
        private readonly int _reduceHitPoints;

        public DefenceItemDecorator(IWorldItem decoratedItem, int reduceHitPoints) : base(decoratedItem)
        {
            _reduceHitPoints = reduceHitPoints;
        }

        public override void AddToWorld()
        {
            base.AddToWorld();
            ((DefenceItem)_decoratedItem).ReduceHitPoints = _reduceHitPoints;
        }

        public override string ToString()
        {
            return $"DefenceItemDecorator: {((WorldObject)_decoratedItem).Name}, ReducesHitPointsBy: {_reduceHitPoints}";
        }
    }
}
