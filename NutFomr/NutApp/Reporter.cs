namespace NutApp
{
    public class Reporter
    {
        public static string CheckingExeptions(ParameterExeptions exeptions, string exeptionsMessage)
        {
            //Составление собщения ошибки при выходе за границы внутнего диаметра резьбы
            if (exeptions == ParameterExeptions.OutOfRangeDiametrOut)
            {
                exeptionsMessage += "Внешний диаметр резьбы - выход за границы;\n";
            }

            //Составление собщения ошибки при выходе за границы высоты гайки
            if (exeptions == ParameterExeptions.OutOfRangeHeight)
            {
                exeptionsMessage += "Высота гайки - выход за границы;\n";
            }

            //Составление собщения ошибки при выходе за границы параметра "под ключ"
            if (exeptions == ParameterExeptions.OutOfRangeKeyParameter)
            {
                exeptionsMessage += "Параметр \"под ключ\" - выход за границы;\n";
            }

            //Составление собщения ошибки при выходе за границы внутреннего диаметра резьбы
            if (exeptions == ParameterExeptions.OutOfRangeDiametrIn)
            {
                exeptionsMessage += "Внутренний диаметр резьбы - выход за границы;\n";
            }

            //Составление собщения ошибки при нулевом или отрицательном значении внушнего диаметра резьбы
            if (exeptions == ParameterExeptions.NegativeValueDiametrOut)
            {
                exeptionsMessage += "Внешний диаметр резьбы - значение нуливое или отрицательное;\n";
            }

            //Составление собщения ошибки при нулевом или отрицательном значении высоты гайки
            if (exeptions == ParameterExeptions.NegativeValueHeight)
            {
                exeptionsMessage += "Высота гайки - значение нуливое или отрицательное;\n";
            }

            //Составление собщения ошибки при нулевом или отрицательном значении параметра "под ключ"
            if (exeptions == ParameterExeptions.NegativeValueKeyParameter)
            {
                exeptionsMessage += "Параметр \"под ключ\" - значение нуливое или отрицательное;\n";
            }

            //Составление собщения ошибки при нулевом или отрицательном значении внутреннего диаметра резьбы
            if (exeptions == ParameterExeptions.NegativeValueDiametrIn)
            {
                exeptionsMessage += "Внутренний диаметр резьбы - значение нуливое или отрицательное;\n";
            }

            return exeptionsMessage;
        }
    }
}
