using System.Collections.Generic;

namespace NutApp
{

    public class NutParameters
    {

    #region Описание полей
        /// <summary>
        /// Поле диаметра описанной окружности шестигранника
        /// </summary>
        private double _diametrOut;

        /// <summary>
        /// Поле внутреннего диаметра резьбы
        /// </summary>
        private double _diametrIn;

        /// <summary>
        /// Поле номинального диамемтра резьбы
        /// </summary>
        private double _dNom;

        /// <summary>
        /// Поле высоты гайки
        /// </summary>
        private double _height;

        /// <summary>
        /// Поле размера под ключ
        /// </summary>
        private double _keyParam;

        /// <summary>
        /// Поле угла фаски головки
        /// </summary>
        private int _angle;

        private List<ParameterExeptions> _exeptionsList = new List<ParameterExeptions>();

        public List<ParameterExeptions> ExeptionsList => _exeptionsList;
        #endregion

        /// <summary>
        /// Конструктор класса параметров гайки
        /// </summary>
        /// <param name="diamOut">Диаметр описанной окружности шестигранника</param>
        /// <param name="diamIn">Внутренный диаметр резьбы</param>
        /// <param name="dNom">Номинальный диаметр резьбы</param>
        /// <param name="height">Высота гайки</param>
        /// <param name="keyParam">Размер под ключ</param>
        /// <param name="angle">Угол фаски головки</param>
        public NutParameters(double diamOut, double diamIn, double dNom, double height, double keyParam, int angle)
        {
            this._diametrOut = diamOut;
            this._diametrIn = diamIn;
            this._dNom = dNom;
            this._height = height;
            this._keyParam = keyParam;
            this._angle = angle;
            Validation();
        }

        /// <summary>
        /// Метод валидации параметров гайки
        /// </summary>
        /// <returns></returns>
        private void Validation()
        {
            double defaultDiametrOut = 0;
            double defaultHeight = 0;
            double defaultKeyParam = 0;
            double defaultDiametrIn = _dNom * 0.85;
            switch (_dNom)
            {
                case 2:
                    defaultDiametrOut = 4.2;
                    defaultHeight = 1.6;
                    defaultKeyParam = 4.0;
                    break;
                case 2.5:
                    defaultDiametrOut = 5.3;
                    defaultHeight = 2.0;
                    defaultKeyParam = 5.0;
                    break;
                case 3:
                    defaultDiametrOut = 5.9;
                    defaultHeight = 2.4;
                    defaultKeyParam = 5.5;
                    break;
            }

            #region Проверка правильности ввода параметров

            //Проверка внешнего диаметра резтьы на выход из границ
            if ((_diametrOut < defaultDiametrOut - (defaultDiametrOut / 10) ||
                 _diametrOut > defaultDiametrOut + (defaultDiametrOut / 10)) && _diametrOut > 0)
            {
                _exeptionsList.Add(ParameterExeptions.OutOfRangeDiametrOut);
            }

            //Проверка высоты на выход из границ
            if ((_height < defaultHeight - (defaultHeight / 10) || _height > defaultHeight + (defaultHeight / 10)) &&
                _height > 0)
            {
                _exeptionsList.Add(ParameterExeptions.OutOfRangeHeight);
            }

            //Проверка параметра "под ключ" на выход из границ
            if ((_keyParam < defaultKeyParam - (defaultKeyParam / 10) ||
                 _keyParam > defaultKeyParam + (defaultKeyParam / 10)) && _keyParam > 0)
            {
                _exeptionsList.Add(ParameterExeptions.OutOfRangeKeyParameter);
            }

            //Проверка внутреннего диаметра резьбы на выход из границ
            if (((_diametrIn < defaultDiametrIn - (defaultDiametrIn / 10) ||
                  _diametrIn > defaultDiametrIn + (defaultDiametrIn / 10)) && _diametrIn > 0))
            {
                _exeptionsList.Add(ParameterExeptions.OutOfRangeDiametrIn);
            }

            //Проверка внешнего диаметра резьбы на нулевое или отрицательное значение
            if (_diametrOut <= 0)
            {
                _exeptionsList.Add(ParameterExeptions.NegativeValueDiametrOut);
            }

            //Проверка высоты на нулевое или отрицательное значение
            if (_height <= 0)
            {
                _exeptionsList.Add(ParameterExeptions.NegativeValueHeight);
            }

            //Проверка параметра "под ключ" на нулевое или отрицательное значение
            if (_keyParam <= 0)
            {
                _exeptionsList.Add(ParameterExeptions.NegativeValueKeyParameter);
            }

            //Проверка внутреннего диаметра резьбы на нулевое или отрицательное значение
            if (_diametrIn <= 0)
            {
                _exeptionsList.Add(ParameterExeptions.NegativeValueDiametrIn);
            }

            #endregion
        }

        #region Описание свойств
        /// <summary>
        /// Геттер описанной окружности шестигранника
        /// </summary>
        public double DiametrOut
        {
            get => _diametrOut;
        }

        /// <summary>
        /// Геттер внутреннего диаметра резьбы
        /// </summary>
        public double DiametrIn
        {
            get => _diametrIn;
        }

        /// <summary>
        /// Геттер номинального диаметра резьбы
        /// </summary>
        public double Dnom
        {
            get => _dNom;
        }

        /// <summary>
        /// Геттер высоты
        /// </summary>
        public double Height
        {
            get => _height;
        }

        /// <summary>
        /// Геттер рзмера под ключ
        /// </summary>
        public double KeyParam
        {
            get => _keyParam;
        }

        /// <summary>
        /// Геттер угла фаски головки
        /// </summary>
        public int Angle
        {
            get => _angle;
        }
        #endregion
    }
}
