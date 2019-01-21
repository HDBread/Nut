using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using NutApp;

namespace NutAppUnitTests
{
    /// <summary>
    /// Summary description for NutParametersTests
    /// </summary>
    [TestFixture]
    public class NutParametersTests
    {
        private NutParameters _nutParameters;
        private double _diameterOut;
        private double _diameterIn;
        private double _height;
        private double _keyParameter;
        private double _dNom;
        private int _angle;

        [SetUp]
        public void InitNutParameters()
        {
             _diameterOut = 4.2;
             _diameterIn = 1.7;
             _height = 1.6;
             _keyParameter = 4.0;
             _dNom = 2;
             _angle = 15;
        }

        #region Позитивные тесты Геттеров

        /// <summary>
        /// Позитивный тест Get DiameterOut
        /// </summary>
        /// <param name="expected">Ожидаемое значение внешнего диаметра резьбы</param>
        /// <param name="message">The author of test</param>
        [TestCase(4.2, "Выполняется, если внешний диаметр резьбы удачно присваевается",
            TestName = "Позитивный тест внешнего диаметра резьбы dOut")]
        public void TestDout_CorrectValue(double expected, string message)
        {
            _nutParameters = new NutParameters(expected,_diameterIn,_dNom,_height,_keyParameter,_angle);
            var actual = _nutParameters.DiameterOut;
            Assert.AreEqual(expected,actual,"Геттер внешнего диаметра резьбы возвращает неправильное значение");
        }

        /// <summary>
        /// Позитивный тест Get DiameterIn
        /// </summary>
        /// <param name="expected">Ожидаемое значение внутреннего диаметра резьбы</param>
        /// <param name="message"></param>
        [TestCase(1.7, "Вополняется, если внутренний диаметер резьбы удачно присваевается",
            TestName = "Позитивний тест внутреннего диаметра резьбы")]
        public void TestDin_CorrectValue(double expected, string message)
        {
            _nutParameters = new NutParameters(_diameterOut, expected, _dNom, _height, _keyParameter, _angle);
            var actual = _nutParameters.DiameterIn;
            Assert.AreEqual(expected, actual, "Геттер внутреннего диаметра резьбы возвращает неправильное значение");
        }

        /// <summary>
        /// Позитивный тест Get Height
        /// </summary>
        /// <param name="expected">Ожидаемое значение высоты гайки</param>
        /// <param name="message"></param>
        [TestCase(1.6, "Вополняется, если высота гайки удачно присваевается",
            TestName = "Позитивний тест высоты гайки")]
        public void TestHeight_CorrectValue(double expected, string message)
        {
            _nutParameters = new NutParameters(_diameterOut, _diameterIn, _dNom, expected, _keyParameter, _angle);
            var actual = _nutParameters.Height;
            Assert.AreEqual(expected, actual, "Геттер высоты гайки возвращает неправильное значение");
        }

        /// <summary>
        /// Позитивный тест Get KeyParameter
        /// </summary>
        /// <param name="expected">Ожидаемое значение параметра "под ключ"</param>
        /// <param name="message"></param>
        [TestCase(4.0, "Вополняется, если параметер \"под ключ\" удачно присваевается",
            TestName = "Позитивний тест параметера \"под ключ\"")]
        public void TestKeyParameter_CorrectValue(double expected, string message)
        {
            _nutParameters = new NutParameters(_diameterOut, _diameterIn, _dNom, _height, expected, _angle);
            var actual = _nutParameters.KeyParam;
            Assert.AreEqual(expected, actual, "Геттер параметера \"под ключ\" возвращает неправильное значение");
        }

        /// <summary>
        /// Позитивный тест Get Dnom
        /// </summary>
        /// <param name="expected">Ожидаемое значение номинального диаметра гайки</param>
        /// <param name="message"></param>
        [TestCase(2.0, "Вополняется, если номинальный диметер удачно присваевается",
            TestName = "Позитивний тест номинального диаметра")]
        public void TestDnom_CorrectValue(double expected, string message)
        {
            _nutParameters = new NutParameters(_diameterOut, _diameterIn, expected, _height, _keyParameter, _angle);
            var actual = _nutParameters.Dnom;
            Assert.AreEqual(expected, actual, "Геттер номинального диаметра возвращает неправильное значение");
        }

        /// <summary>
        /// Позитивный тест Get Angle
        /// </summary>
        /// <param name="expected">Ожидаемое значение угла фаски головки</param>
        /// <param name="message"></param>
        [TestCase(15, "Вополняется, если угол фаски головки удачно присваевается",
            TestName = "Позитивний тест угола фаски головки")]
        public void TestAngle_CorrectValue(int expected, string message)
        {
            _nutParameters = new NutParameters(_diameterOut, _diameterIn, _dNom, _height, _keyParameter, expected);
            var actual = _nutParameters.Angle;
            Assert.AreEqual(expected, actual, "Геттер угола фаски головки возвращает неправильное значение");
        }

        #endregion

        #region Негативные тесты Геттеров

        /// <summary>
        /// Негативный тест внешнего диаметра резьбы на ParameterException
        /// </summary>
        /// <param name="wrongDiameterOut">Неправильное значение внешнего диаметра резьбы</param>
        /// <param name="expectedException">Ожидаемое исключение</param>
        /// <param name="message"></param>
        [TestCase(50, typeof(ParameterException),
            "Должно возникать исключение, если внешний диаметер резьбы больше/меньше 10% от ГОСТ'го значения",
            TestName = "Присвоение неправильного значения внешнего диаметра резьбы")]
        [TestCase(0, typeof(ParameterException),
            "Должно возникать исключение, если внешний диаметер резьбы равен нулю",
            TestName = "Присвоение нулевого значения внешнего диаметра резьбы")]
        [TestCase(-5, typeof(ParameterException),
            "Должно возникать исключение, если внешний диаметер резьбы мельше нуля",
            TestName = "Присвоение отрицательного значения внешнего диаметра резьбы")]
        public void TestDiameterOut_ParameterException(double wrongDiameterOut, Type expectedException, string message)
        {
            Assert.Throws(expectedException, () =>
            {
                _nutParameters = new NutParameters(wrongDiameterOut, _diameterIn, _dNom, _height, _keyParameter,_angle);
            }, message);
        }

        /// <summary>
        /// Негативный тест внутреннего диаметра резьбы на ParameterException
        /// </summary>
        /// <param name="wrongDiameterIn">Неправильное значение внутреннего диаметра резьбы</param>
        /// <param name="expectedException">Ожидаемое исключение</param>
        /// <param name="message"></param>
        [TestCase(50, typeof(ParameterException),
            "Должно возникать исключение, если внутренний диаметер резьбы больше/меньше 10% от ГОСТ'го значения",
            TestName = "Присвоение неправильного значения внутреннего диаметра резьбы")]
        [TestCase(0, typeof(ParameterException),
            "Должно возникать исключение, если внутренний диаметер резьбы равен нулю",
            TestName = "Присвоение нулевого значения внутреннего диаметра резьбы")]
        [TestCase(-5, typeof(ParameterException),
            "Должно возникать исключение, если внутренний диаметер резьбы меньше нуля",
            TestName = "Присвоение отрицательного значения внутреннего диаметра резьбы")]
        public void TestDiameterIn_ParameterException(double wrongDiameterIn, Type expectedException, string message)
        {
            Assert.Throws(expectedException, () =>
            {
                _nutParameters = new NutParameters(_diameterOut, wrongDiameterIn, _dNom, _height, _keyParameter, _angle);
            }, message);
        }

        /// <summary>
        /// Негативный тест высоты гайки на ParameterException
        /// </summary>
        /// <param name="wrongHeight">Неправильное значение высоты гайки</param>
        /// <param name="expectedException">Ожидаемое исключение</param>
        /// <param name="message"></param>
        [TestCase(50, typeof(ParameterException),
            "Должно возникать исключение, если высота гайки больше/меньше 10% от ГОСТ'го значения",
            TestName = "Присвоение неправильного значения высоты гайки")]
        [TestCase(0, typeof(ParameterException),
            "Должно возникать исключение, если высота гайки равен нулю",
            TestName = "Присвоение нулевого значения высоты гайки")]
        [TestCase(-5, typeof(ParameterException),
            "Должно возникать исключение, если высота гайки меньше нуля",
            TestName = "Присвоение отрицательного значения высоты гайки")]
        public void TestHeight_ParameterException(double wrongHeight, Type expectedException, string message)
        {
            Assert.Throws(expectedException, () =>
            {
                _nutParameters = new NutParameters(_diameterOut, _diameterIn, _dNom, wrongHeight, _keyParameter, _angle);
            }, message);
        }

        /// <summary>
        /// Негативный тест параметра "под колюч" на ParameterException
        /// </summary>
        /// <param name="wrongKeyParameter">Неправильное значение параметра "под ключ"</param>
        /// <param name="expectedException">Ожидаемое исключение</param>
        /// <param name="message"></param>
        [TestCase(50, typeof(ParameterException),
            "Должно возникать исключение, если параметер \"под ключ\" больше/меньше 10% от ГОСТ'го значения",
            TestName = "Присвоение неправильного параметера \"под ключ\"")]
        [TestCase(0, typeof(ParameterException),
            "Должно возникать исключение, если параметер \"под ключ\" равен нулю",
            TestName = "Присвоение нулевого параметера \"под ключ\"")]
        [TestCase(-5, typeof(ParameterException),
            "Должно возникать исключение, если параметер \"под ключ\" меньше нуля",
            TestName = "Присвоение отрицательного параметера \"под ключ\"")]
        public void TestKeyParameter_ParameterException(double wrongKeyParameter, Type expectedException, string message)
        {
            Assert.Throws(expectedException, () =>
            {
                _nutParameters = new NutParameters(_diameterOut, _diameterIn, _dNom, _height, wrongKeyParameter, _angle);
            }, message);
        }

        /// <summary>
        /// Негативный тест номинального диаметра резьбы на ParameterException
        /// </summary>
        /// <param name="wrongDnom">Неправильное значение номинального диаметра резьбы</param>
        /// <param name="expectedException">Ожидаемое исключение</param>
        /// <param name="message"></param>
        [TestCase(50, typeof(ParameterException),
            "Должно возникать исключение, если номинальный диаметер резьбы больше/меньше 10% от ГОСТ'го значения",
            TestName = "Присвоение неправильного значения номинального диаметра резьбы")]
        [TestCase(0, typeof(ParameterException),
            "Должно возникать исключение, если номинальный диаметер резьбы равен нулю",
            TestName = "Присвоение нулевого значения номинального диаметра резьбы")]
        [TestCase(-5, typeof(ParameterException),
            "Должно возникать исключение, если номинальный диаметер резьбы меньше нуля",
            TestName = "Присвоение отрицательного значения номинального диаметра резьбы")]
        public void TestDnom_ParameterException(double wrongDnom, Type expectedException, string message)
        {
            Assert.Throws(expectedException, () =>
            {
                _nutParameters = new NutParameters(_diameterOut, _diameterIn, wrongDnom, _keyParameter, _keyParameter, _angle);
            }, message);
        }

        /// <summary>
        /// Негативный тест угла фаски головки на ParameterException
        /// </summary>
        /// <param name="wrongAngle">Неправильное значение угла фаски головки</param>
        /// <param name="expectedException">Ожидаемое исключение</param>
        /// <param name="message"></param>
        [TestCase(50, typeof(ParameterException),
            "Должно возникать исключение, если угол фаски головки больше/меньше 10% от ГОСТ'го значения",
            TestName = "Присвоение неправильного значения угола фаски головки")]
        [TestCase(0, typeof(ParameterException),
            "Должно возникать исключение, если угол фаски головки равен нулю",
            TestName = "Присвоение нулевого значения угола фаски головки")]
        [TestCase(-5, typeof(ParameterException),
            "Должно возникать исключение, если угол фаски головки меньше нуля",
            TestName = "Присвоение отрицательного значения угола фаски головки")]
        public void TestAngle_ParameterException(int wrongAngle, Type expectedException, string message)
        {
            Assert.Throws(expectedException, () =>
            {
                _nutParameters = new NutParameters(_diameterOut, _diameterIn, _dNom, _keyParameter, _keyParameter, wrongAngle);
            }, message);
        }
        #endregion

        #region Тестирование методов

        /// <summary>
        /// Позитивные тесты установки ГОСТ'овских значений при определенном номинальном диаметре резьбы
        /// </summary>
        /// <param name="transmittedDnom">Передаваемое значение номинального диаметра резьбы в метод SettingParameters</param>
        /// <param name="message"></param>
        [TestCase(2, "Выполняется, если метод SettingParameters отработал верно",
            TestName = "Проверка метода SettingParameters")]
        public void TestSettingParameters_CorrectValue(double transmittedDnom, string message)
        {
            _nutParameters = new NutParameters(transmittedDnom,_angle);

            Assert.AreEqual(_diameterOut,_nutParameters.DiameterOut,"Ошибка метода SettingParameters, задается неправильное значение внешнего диаметра резьбы");
            Assert.AreEqual(_height,_nutParameters.Height, "Ошибка метода SettingParameters, задается неправильное значение высоты гайки");
            Assert.AreEqual(_keyParameter,_nutParameters.KeyParam, "Ошибка метода SettingParameters, задается неправильное значение параметра \"под ключ\"");
        }

        [TestCase(3,"Выполняется, если метод CheckParameters передает правильные типы ошибок",
            TestName = "Проверка метода CheckParmeter")]
        public void TestCheckParameters_CorrectExcceptions(int expectedCount, string message)
        {
            double wrongDiameterOut = 50;
            double wrongKeyParameter = 0;
            double wrongHeight = -5;
            try
            {
                _nutParameters = new NutParameters(wrongDiameterOut, _diameterIn, _dNom, wrongHeight, wrongKeyParameter,
                    _angle);
            }
            catch (ParameterException exception)
            {
                Assert.AreEqual(expectedCount, exception.ParameterExceptionses.Count,
                    "Задается неправильное кол-во ошибок");

                //Проверки на нахождение ошибок в списке
                Assert.IsTrue(exception.ParameterExceptionses.Contains(ParameterErrors.OutOfRangeDiameterOut),
                    "Список не содержит ошибку типа \"OutOfRangeDiameterOut\"");
                Assert.IsTrue(exception.ParameterExceptionses.Contains(ParameterErrors.NegativeValueKeyParameter),
                    "Список не содержит ошибку тепа \"NegativevalueKeyParameter");
                Assert.IsTrue(exception.ParameterExceptionses.Contains(ParameterErrors.NegativeValueHeight),
                    "Список не содержит ошибку типа \"NegativeValueHeight\"");

                //Проверки на отсутствие ошибок в списке
                Assert.IsFalse(exception.ParameterExceptionses.Contains(ParameterErrors.OutOfRangeDiameterIn),
                    "Тип ошибки \"OutOfRangeDiameterIn\" присудствует в списке, но не должен был");
                Assert.IsFalse(exception.ParameterExceptionses.Contains(ParameterErrors.OutOfRangeKeyParameter),
                    "Тип ошибки \"OutOfRangeKeyParameter\" присудствует в списке, но не должен был");
                Assert.IsFalse(exception.ParameterExceptionses.Contains(ParameterErrors.NegativeValueDiameterOut),
                    "Тип ошибки \"NegativeValueDiameterOut\" присудствует в списке, но не должен был");
                Assert.IsFalse(exception.ParameterExceptionses.Contains(ParameterErrors.ParsingDiameterOut),
                    "Тип ошибки \"ParsingDiameterOut\" присудствует в списке, но не должен был");
            }
        }

        #endregion
    }
}
