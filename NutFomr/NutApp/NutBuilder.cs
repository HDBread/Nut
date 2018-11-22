using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;

namespace NutApp
{
    public class NutBuilder
    {
        /// <summary>
        /// Экземпляр компаса
        /// </summary>
        private KompasObject _kompas;

        /// <summary>
        /// Конструкток класса NutBuilder
        /// </summary>
        /// <param name="kompasObj"></param>
        public NutBuilder(KompasObject kompasObj)
        {
            _kompas = kompasObj;
        }

        /// <summary>
        /// Метод построение детали(гайки)
        /// </summary>
        /// <param name="Param"></param>
        public void BuildDetail(NutParameters Param)
        {

        }
    }
}
