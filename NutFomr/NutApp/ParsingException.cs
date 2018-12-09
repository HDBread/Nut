using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutApp
{
    public class ParsingException: ApplicationException
    {
        public List<ParameterParsingErrors> ParsingExceptiones { get; }

        /// <summary>
        /// Исключение при ошибки парсинге параметров
        /// </summary>
        /// <param name="message">Сообщение ошибки</param>
        /// <param name="parsingExceptionses">Список ошибок</param>
        public ParsingException(string message, List<ParameterParsingErrors> parsingExceptionses) : base(message)
        {
            ParsingExceptiones = parsingExceptionses;
        }
    }
}
