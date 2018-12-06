namespace NutApp
{
    /// <summary>
    /// Список возможных ошибок
    /// </summary>
    public enum ParameterErrors
    {
        /// <summary>
        /// Выход за границы внешнего диаметра резьбы
        /// </summary>
        OutOfRangeDiametrOut = 1,
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
        OutOfRangeDiametrIn,
        /// <summary>
        /// Нулевое или отрицательное значение внешнего диаметра резьбы
        /// </summary>
        NegativeValueDiametrOut,
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
        NegativeValueDiametrIn
    }
}
