namespace NutApp
{
    public class Reporter
    {
        public static string CheckingExсeptions(ParameterErrors exceptions, string exсeptionsMessage)
        {
            if (exceptions == ParameterErrors.OutOfRangeDiametrOut)
            {
                exсeptionsMessage += "Внешний диаметр резьбы - выход за границы;\n";
            }

            if (exceptions == ParameterErrors.OutOfRangeHeight)
            {
                exсeptionsMessage += "Высота гайки - выход за границы;\n";
            }

            if (exceptions == ParameterErrors.OutOfRangeKeyParameter)
            {
                exсeptionsMessage += "Параметр \"под ключ\" - выход за границы;\n";
            }

            if (exceptions == ParameterErrors.OutOfRangeDiametrIn)
            {
                exсeptionsMessage += "Внутренний диаметр резьбы - выход за границы;\n";
            }

            if (exceptions == ParameterErrors.NegativeValueDiametrOut)
            {
                exсeptionsMessage += "Внешний диаметр резьбы - значение нуливое или отрицательное;\n";
            }

            if (exceptions == ParameterErrors.NegativeValueHeight)
            {
                exсeptionsMessage += "Высота гайки - значение нуливое или отрицательное;\n";
            }

            if (exceptions == ParameterErrors.NegativeValueKeyParameter)
            {
                exсeptionsMessage += "Параметр \"под ключ\" - значение нуливое или отрицательное;\n";
            }

            if (exceptions == ParameterErrors.NegativeValueDiametrIn)
            {
                exсeptionsMessage += "Внутренний диаметр резьбы - значение нуливое или отрицательное;\n";
            }

            return exсeptionsMessage;
        }
    }
}
