using System;
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
            var type = Type.GetTypeFromProgID("KOMPAS.Application.5");
            _kompas = (KompasObject)Activator.CreateInstance(type);
            _kompas.Visible = true;
        }

        /// <summary>
        /// Метод отключения от компаса
        /// </summary>
        public void Disconnect()
        {
            _kompas.Quit();
            _kompas = null;
        }
    }
}
