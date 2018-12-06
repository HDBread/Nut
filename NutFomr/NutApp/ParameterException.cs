using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutApp
{
    /// <summary>
    /// Класс исключения при ошибки валидации параметров
    /// </summary>
    public class ParameterException : ApplicationException
    {
        public List<ParameterErrors> ParameterExceptionses { get; }

        /// <summary>
        /// Исключение при ошибки валидации параметров
        /// </summary>
        /// <param name="message">Сообщение ошибки</param>
        /// <param name="parameterExceptionses">Список ошибок</param>
        public ParameterException(string message, List<ParameterErrors> parameterExceptionses) : base(message)
        {
            ParameterExceptionses = parameterExceptionses;
        }
    }
}
