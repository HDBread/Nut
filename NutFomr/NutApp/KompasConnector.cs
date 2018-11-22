using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;

namespace NutApp
{
    public class KompasConnector
    {
        /// <summary>
        /// Экземпляр компаса
        /// </summary>
        private KompasObject _kompas;

        /// <summary>
        /// Свойство эклемпляра компаса
        /// </summary>
        public KompasObject Kompas
        {
            get => _kompas;
            set { _kompas = value; }
        }

        /// <summary>
        /// Метод подключения к компасу
        /// </summary>
        public void Connect()
        {

        }

        /// <summary>
        /// Метод отключения от компаса
        /// </summary>
        public void Disconnect()
        {

        }
    }
}
