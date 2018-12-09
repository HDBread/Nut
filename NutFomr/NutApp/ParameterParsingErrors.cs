namespace NutApp
{
    public enum ParameterParsingErrors
    {
        /// <summary>
        /// Ошибка парсинга внешнего диаметра резьбы
        /// </summary>
        ParsingDiameterOut,
        /// <summary>
        /// Ошибка парсинга внутреннего диаметра резьбы
        /// </summary>
        ParsingDiameterIn,
        /// <summary>
        /// Ошибка парсинга высоты
        /// </summary>
        ParsingHeight,
        /// <summary>
        /// Ошибка парсинга параметра "под ключ"
        /// </summary>
        ParsingKeyParameter
    }
}
