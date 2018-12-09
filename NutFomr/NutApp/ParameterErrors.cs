namespace NutApp
{
    /// <summary>
    /// Список числовых ошибок параметров
    /// </summary>
    public enum ParameterErrors
    {
        /// <summary>
        /// Выход за границы внешнего диаметра резьбы
        /// </summary>
        OutOfRangeDiameterOut = 1,
        /// <summary>
        /// Выход за границы высоты
        /// </summary>
        OutOfRangeHeight,
        /// <summary>
        /// Выход за границы параметра "под ключ"
        /// </summary>
        OutOfRangeKeyParameter,
        /// <summary>
        /// Выход за границы внутреннего диаметра резьбы
        /// </summary>
        OutOfRangeDiameterIn,
        /// <summary>
        /// Нулевое или отрицательное значение внешнего диаметра резьбы
        /// </summary>
        NegativeValueDiameterOut,
        /// <summary>
        /// Нулевое или отрицательное значение высоты
        /// </summary>
        NegativeValueHeight,
        /// <summary>
        /// Нулевое или отрицательное значение параметра "под ключ"
        /// </summary>
        NegativeValueKeyParameter,
        /// <summary>
        /// Нулевое или отрицательное значение внутреннего диаметра резьбы
        /// </summary>
        NegativeValueDiameterIn,
        /// <summary>
        /// Ошибка парсинга внешнего диаметра резьбы
        /// </summary>
        ParsingDiameterOut,
    }
}
