using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using NutApp;

namespace NutAppUnitTests
{

    /// <summary>
    /// Тестирование класса составления сообщение ошибок Reporter
    /// </summary>
    [TestFixture]
    public class ReporterTests
    {
        /// <summary>
        /// Позитивный тест проверки сообщение при ошибке OutOfRangeDiameterOut
        /// </summary>
        /// <param name="expectedMessage">Ожидаемое сообщение ошибки</param>
        /// <param name="message"></param>
        [TestCase("Внешний диаметр резьбы - выход за границы;\n",
            "Выполняется, если составляется правилное сообщение ошибки выхода за границы внешнего диаметра резьбы",
            TestName = "Позитивный тест провверки правильности сообщения ошибки OutOfRangeDiameterOut")]
        public void TestReporterOutOfRangeDiameterOut_CorrectMessage(string expectedMessage, string message)
        {
            string actualMessage = Reporter.CheckingExсeptions(ParameterErrors.OutOfRangeDiameterOut, String.Empty);
            Assert.AreEqual(expectedMessage,actualMessage,"При ошибке \"OutOfRangeDiameterOut\" составляется не правильное сообщение");
        }

        [TestCase("Высота гайки - значение нуливое или отрицательное;\n",
            "Выполняется, если составляется правилное сообщение ошибки отрицательного/улевого значения высоты гайки",
            TestName = "Позитивный тест провверки правильности сообщения ошибки OutOfRangeDiameterOut")]
        public void TestReporterNegativeValueHeight_CorrectMessage(string expectedMessage, string message)
        {
            string actualMessage = Reporter.CheckingExсeptions(ParameterErrors.NegativeValueHeight, String.Empty);
            Assert.AreEqual(expectedMessage, actualMessage, "При ошибке \"NegativeValueHeight\" составляется не правильное сообщение");
        }

        
        [TestCase("Внутренний диаметр резьбы - выход за границы;\n",
            "Выполняется, если составляется правилное сообщение ошибки выхода за границы внутреннего диаметра резьбы",
            TestName = "Позитивный тест провверки правильности сообщения ошибки OutOfRangeDiameterIn")]
        public void TestReporterOutOfRangeDiameterInt_CorrectMessage(string expectedMessage, string message)
        {
            string actualMessage = Reporter.CheckingExсeptions(ParameterErrors.OutOfRangeDiameterIn, String.Empty);
            Assert.AreEqual(expectedMessage, actualMessage, "При ошибке \"OutOfRangeDiameterIn\" составляется не правильное сообщение");
        }

        [TestCase("Внешний диаметр резьбы - значение нуливое или отрицательное;\n",
            "Выполняется, если составляется правилное сообщение ошибки отрицательного/улевого значения внешнего диаметра резьбы",
            TestName = "Позитивный тест провверки правильности сообщения ошибки NegativeValueDiameterOut")]
        public void TestReporterNegativeValueDiameterOut_CorrectMessage(string expectedMessage, string message)
        {
            string actualMessage = Reporter.CheckingExсeptions(ParameterErrors.NegativeValueDiameterOut, String.Empty);
            Assert.AreEqual(expectedMessage, actualMessage, "При ошибке \"NegativeValueDiameterOut\" составляется не правильное сообщение");
        }

        [TestCase("Высота  -  нуливое и не несет в себе смылса",
            "Выполняется, если составляется не правильное сообщение ошибки выхода за границы параметра \"под ключ\"",
            TestName = "Негативный тест провверки правильности сообщения ошибки OutOfRangeKeyParameter")]
        public void TestReporterOutOfRangeKeyParameter_IncorrectMessage(string expectedMessage, string message)
        {
            string actualMessage = Reporter.CheckingExсeptions(ParameterErrors.OutOfRangeKeyParameter, String.Empty);
            Assert.AreNotEqual(expectedMessage, actualMessage, "При ошибке \"NegativeValueHeight\" составляется не правильное сообщение");
        }
    }
}
