namespace NutApp
{
    public class Reporter
    {
        public static string CheckingExсeptions(ParameterErrors exceptions, string exсeptionsMessage)
        {
            if (exceptions == ParameterErrors.OutOfRangeDiameterOut)
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

            if (exceptions == ParameterErrors.OutOfRangeDiameterIn)
            {
                exсeptionsMessage += "Внутренний диаметр резьбы - выход за границы;\n";
            }

            if (exceptions == ParameterErrors.NegativeValueDiameterOut)
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

            if (exceptions == ParameterErrors.NegativeValueDiameterIn)
            {
                exсeptionsMessage += "Внутренний диаметр резьбы - значение нуливое или отрицательное;\n";
            }

            return exсeptionsMessage;
        }

    }
}
