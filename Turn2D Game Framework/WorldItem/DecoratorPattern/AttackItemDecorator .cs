using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn2D_Game_Framework.WorldItem.DecoratorPattern
{
    public class AttackItemDecorator : WorldItemDecorator
    {
        private readonly int _hitPoints;

        public AttackItemDecorator(IWorldItem decoratedItem, int hitPoints) : base(decoratedItem)
        {
            _hitPoints = hitPoints;
        }

        public override void AddToWorld()
        {
            base.AddToWorld();
            ((AttackItem)_decoratedItem).HitPoints = _hitPoints;
        }
        public override string ToString()
        {
            return $"AttackItemDecorator: {((WorldObject)_decoratedItem).Name}, ReducesHitPointsBy: {_hitPoints}";
        }
    }
}
