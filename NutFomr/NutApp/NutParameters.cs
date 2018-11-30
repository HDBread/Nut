using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            double defaultDiamOut = 0;
            double defaultHeight = 0;
            double defaultKeyParam = 0;
            switch (_dNom)
            {
                case 2:
                    defaultDiamOut = 4.2;
                    defaultHeight = 1.6;
                    defaultKeyParam = 4.0;
                    break;
                case 2.5:
                    defaultDiamOut = 5.3;
                    defaultHeight = 2.0;
                    defaultKeyParam = 5.0;
                    break;
                case 3:
                    defaultDiamOut = 5.9;
                    defaultHeight = 2.4;
                    defaultKeyParam = 5.5;
                    break;
            }
            
            if ((_diametrOut < defaultDiamOut - (defaultDiamOut / 10) || _diametrOut > defaultDiamOut + (defaultDiamOut / 10)) && _diametrOut > 0)
            {
                _exeptionsList.Add(ParameterExeptions.OutOfRangeDiametrOut);
            }

            if ((_height < defaultHeight - (defaultHeight / 10) || _height > defaultHeight + (defaultHeight / 10)) && _height > 0)
            {
                _exeptionsList.Add(ParameterExeptions.OutOfRangeHeight);
            }

            if ((_keyParam < defaultKeyParam - (defaultKeyParam / 10) || _keyParam > defaultKeyParam + (defaultKeyParam / 10)) && _keyParam > 0)
            {
                _exeptionsList.Add(ParameterExeptions.OutOfrangeKeyParameter);
            }

            if (_diametrOut <= 0)
            {
                _exeptionsList.Add(ParameterExeptions.NegativevalueDiametrOut);
            }

            if (_height <= 0)
            {
                _exeptionsList.Add(ParameterExeptions.NegativeValueHeight);
            }

            if (_keyParam <= 0)
            {
                _exeptionsList.Add(ParameterExeptions.NegativeValueKeyParameter);
            }
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
        public double Heigth
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
