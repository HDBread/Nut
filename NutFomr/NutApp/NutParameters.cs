using System;
using System.Collections.Generic;

namespace NutApp
{

    public class NutParameters
    {

    #region Описание полей
        /// <summary>
        /// Поле диаметра описанной окружности шестигранника
        /// </summary>
        private double _diameterOut;

        /// <summary>
        /// Поле внутреннего диаметра резьбы
        /// </summary>
        private double _diameterIn;

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

        /// <summary>
        /// Список ошибок при валидации
        /// </summary>
        private List<ParameterErrors> _exceptionsList = new List<ParameterErrors>();

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
            this._diameterOut = diamOut;
            this._diameterIn = diamIn;
            this._dNom = dNom;
            this._height = height;
            this._keyParam = keyParam;
            this._angle = angle;
            Validation();
        }

        /// <summary>
        /// Конструктор без параметров для задания дефолтных значений
        /// </summary>
        public NutParameters() :this (4.2, 1.7, 2, 1.6, 4.0, 15) { }

        /// <summary>
        /// Конструктор для изменения дефолтных значений при изменении номинального диаметра
        /// </summary>
        /// <param name="dNom">Номинальный диаметр резьбы</param>
        /// <param name="angle">Угол фаски головки</param>
        public NutParameters(double dNom, int angle)
        {
            InitDefaults(dNom);
            this._angle = angle;
            //TODO:Задаются дефолтные(априоре правильные) значения. Так зачем тут валидация?
            //Validation();
        }

        /// <summary>
        /// Метод валидации параметров гайки
        /// </summary>
        /// <returns></returns>
        private void Validation()
        {
            double defaultDiameterOut = 0;
            double defaultHeight = 0;
            double defaultKeyParam = 0;
            double defaultDiameterIn = _dNom * 0.85;
            SettingParameters(_dNom, ref defaultDiameterOut, ref defaultHeight, ref defaultKeyParam);

            CheckParameters(defaultDiameterOut,defaultHeight,defaultKeyParam,defaultDiameterIn);

            if (_exceptionsList.Count != 0)
            {
                throw new ParameterException("Введены неверные значения параметров", _exceptionsList);
            }
        }

        public void InitDefaults(double dNom)
        {
            _dNom = dNom;
            _diameterIn = _dNom * 0.85;
            SettingParameters(_dNom, ref _diameterOut, ref _height, ref _keyParam);
        }

        #region Описание свойств
        /// <summary>
        /// Геттер описанной окружности шестигранника
        /// </summary>
        public double DiametrOut => _diameterOut;

        /// <summary>
        /// Геттер внутреннего диаметра резьбы
        /// </summary>
        public double DiametrIn => _diameterIn;

        /// <summary>
        /// Геттер номинального диаметра резьбы
        /// </summary>
        public double Dnom => _dNom;

        /// <summary>
        /// Геттер высоты
        /// </summary>
        public double Height => _height;

        /// <summary>
        /// Геттер рзмера под ключ
        /// </summary>
        public double KeyParam => _keyParam;

        /// <summary>
        /// Геттер угла фаски головки
        /// </summary>
        public int Angle => _angle;

        #endregion

        /// <summary>
        /// Метод проверки параметров гайки
        /// </summary>
        /// <param name="defaultDiameterOut">ГОСТ значение внешнего диаметра резьбы</param>
        /// <param name="defaultHeight">ГОСТ значение высоты</param>
        /// <param name="defaultKeyParam">ГОСТ значение параметра "под ключ"</param>
        /// <param name="defaultDiameterIn">ГОСТ значение внутреннего диаметра резьбы</param>
        private void CheckParameters(double defaultDiameterOut, double defaultHeight, double defaultKeyParam, double defaultDiameterIn)
        {
            //Проверка внешнего диаметра резтьы на выход из границ
            if ((_diameterOut < defaultDiameterOut - (defaultDiameterOut / 10) ||
                 _diameterOut > defaultDiameterOut + (defaultDiameterOut / 10)) && _diameterOut > 0)
            {
                _exceptionsList.Add(ParameterErrors.OutOfRangeDiametrOut);
            }

            //Проверка высоты на выход из границ
            if ((_height < defaultHeight - (defaultHeight / 10) || _height > defaultHeight + (defaultHeight / 10)) &&
                _height > 0)
            {
                _exceptionsList.Add(ParameterErrors.OutOfRangeHeight);
            }

            //Проверка параметра "под ключ" на выход из границ
            if ((_keyParam < defaultKeyParam - (defaultKeyParam / 10) ||
                 _keyParam > defaultKeyParam + (defaultKeyParam / 10)) && _keyParam > 0)
            {
                _exceptionsList.Add(ParameterErrors.OutOfRangeKeyParameter);
            }

            //Проверка внутреннего диаметра резьбы на выход из границ
            if (((_diameterIn < defaultDiameterIn - (defaultDiameterIn / 10) ||
                  _diameterIn > defaultDiameterIn + (defaultDiameterIn / 10)) && _diameterIn > 0))
            {
                _exceptionsList.Add(ParameterErrors.OutOfRangeDiametrIn);
            }

            //Проверка внешнего диаметра резьбы на нулевое или отрицательное значение
            if (_diameterOut <= 0)
            {
                _exceptionsList.Add(ParameterErrors.NegativeValueDiametrOut);
            }

            //Проверка высоты на нулевое или отрицательное значение
            if (_height <= 0)
            {
                _exceptionsList.Add(ParameterErrors.NegativeValueHeight);
            }

            //Проверка параметра "под ключ" на нулевое или отрицательное значение
            if (_keyParam <= 0)
            {
                _exceptionsList.Add(ParameterErrors.NegativeValueKeyParameter);
            }

            //Проверка внутреннего диаметра резьбы на нулевое или отрицательное значение
            if (_diameterIn <= 0)
            {
                _exceptionsList.Add(ParameterErrors.NegativeValueDiametrIn);
            }
        }

        /// <summary>
        /// Установка значений параметров при различном номинальном диаметре
        /// </summary>
        /// <param name="dOut">Внешний диаметр по ссылке</param>
        /// <param name="height">Высота по ссылке</param>
        /// <param name="keyParam">параметр "под ключ" по ссылке</param>
        /// <param name="dNom">Номинальный диаметр по значению</param>
        private void SettingParameters(double dNom, ref double diameterOut, ref double height, ref double keyParam)
        {
            switch (dNom)
            {
                case 2:
                    diameterOut = 4.2;
                    height = 1.6;
                    keyParam = 4.0;
                    break;
                case 2.5:
                    diameterOut = 5.3;
                    height = 2.0;
                    keyParam = 5.0;
                    break;
                case 3:
                    diameterOut = 5.9;
                    height = 2.4;
                    keyParam = 5.5;
                    break;
            }
        }
    }
}
