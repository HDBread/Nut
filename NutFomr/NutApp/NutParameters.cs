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
        private double _heigth;

        /// <summary>
        /// Поле размера под ключ
        /// </summary>
        private double _keyParam;

        /// <summary>
        /// Поле угла фаски головки
        /// </summary>
        private int _angle;
    #endregion

        /// <summary>
        /// Конструктор класса параметров гайки
        /// </summary>
        /// <param name="diamOut">Диаметр описанной окружности шестигранника</param>
        /// <param name="diamIn">Внутренный диаметр резьбы</param>
        /// <param name="dNom">Номинальный диаметр резьбы</param>
        /// <param name="heigth">Высота гайки</param>
        /// <param name="keyParam">Размер под ключ</param>
        /// <param name="angle">Угол фаски головки</param>
        public NutParameters(double diamOut, double diamIn, double dNom, double heigth, double keyParam, int angle)
        {
            this._diametrOut = diamOut;
            this._diametrIn = diamIn;
            this._dNom = dNom;
            this._heigth = heigth;
            this._keyParam = keyParam;
            this._angle = angle;
        }

        /// <summary>
        /// Метод валидации параметров гайки
        /// </summary>
        /// <returns></returns>
        public bool Validation()
        {
            return true;
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
            get => _heigth;
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
