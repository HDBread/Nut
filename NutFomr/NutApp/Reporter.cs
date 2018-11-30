using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutApp
{
    public class Reporter
    {
        public static string CheckingExeptions(ParameterExeptions exeptions, string exeptionsMessage)
        {
            if (exeptions == ParameterExeptions.OutOfRangeDiametrOut)
            {
                exeptionsMessage += "Внешный диаметр резьбы - выход за границы;\n";
            }

            if (exeptions == ParameterExeptions.OutOfRangeHeight)
            {
                exeptionsMessage += "Высота гайки - выход за границы;\n";
            }

            if (exeptions == ParameterExeptions.OutOfrangeKeyParameter)
            {
                exeptionsMessage += "Параметр \"под ключь\" - выход за границы;\n";
            }

            if (exeptions == ParameterExeptions.NegativevalueDiametrOut)
            {
                exeptionsMessage += "Внешный диаметр резьбы - значение нуливое или отрицательное;\n";
            }

            if (exeptions == ParameterExeptions.NegativeValueHeight)
            {
                exeptionsMessage += "Внешный диаметр резьбы - значение нуливое или отрицательное;\n";
            }

            if (exeptions == ParameterExeptions.NegativeValueKeyParameter)
            {
                exeptionsMessage += "Параметр \"под ключь\" - значение нуливое или отрицательное;\n";
            }

            return exeptionsMessage;
        }
    }
}
