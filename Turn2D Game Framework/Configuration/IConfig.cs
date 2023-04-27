
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turn2D_Game_Framework.Logging;

namespace Turn2D_Game_Framework.Configuration
{
    public interface IConfig
    {
        public ILogger ConfigureFromFile(string filePath);
    }
}
