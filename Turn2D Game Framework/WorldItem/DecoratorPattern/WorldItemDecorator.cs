using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn2D_Game_Framework.WorldItem.DecoratorPattern
{
    public abstract class WorldItemDecorator : IWorldItem
    {
        protected IWorldItem _decoratedItem;

        public WorldItemDecorator(IWorldItem decoratedItem)
        {
            _decoratedItem = decoratedItem;
        }

        public virtual void AddToWorld()
        {
            _decoratedItem.AddToWorld();
        }

        public virtual void RemoveFromWorld()
        {
            _decoratedItem.RemoveFromWorld();
        }
    }

}
