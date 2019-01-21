using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Kompas6API5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NutApp;
using NUnit.Framework;
using Environment = System.Environment;


namespace NutAppUnitTests
{
    [TestClass]
    public class StressTests
    {
        private KompasObject _kompas;
        private StreamWriter _writer;
        private PerformanceCounter _ramCounter;
        private PerformanceCounter _cpuCounter;

        [SetUp]
        public void Test()
        {
            _writer = new StreamWriter(@"C: \Users\NeshCroft\Desktop\ТУСУР\7 семестр\ОРСАПР\StressTest.txt");
        }

        [Test]
        public void Start()
        {
            StartKompas();
            var builder = new NutBuilder(_kompas, String.Empty);
            var parameters = new NutParameters(4.2,1.7,2,1.6,4,15);

            for (int i = 0; ; i++)
            {
                var processes = Process.GetProcessesByName("KOMPAS");
                var process = processes.First();

                if (i == 0)
                {
                    _ramCounter = new PerformanceCounter("Process", "Working Set", process.ProcessName);
                    _cpuCounter = new PerformanceCounter("Process", "% Processor Time", process.ProcessName);
                }

                _cpuCounter.NextValue();

                builder.BuildDetail(parameters);

                var ram = _ramCounter.NextValue();
                var cpu = _cpuCounter.NextValue();

                _writer.Write($"{i}. ");
                _writer.Write($"RAM: {Math.Round(ram / 1024 / 1024)} MB");
                _writer.Write($"\tCPU: {cpu} %");
                _writer.Write(Environment.NewLine);
                _writer.Flush();
            }
    }

        public void StartKompas()
        {
            if (_kompas == null)
            {
                var type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                _kompas = (KompasObject)Activator.CreateInstance(type);
                _kompas.Visible = true;
                _kompas.ActivateControllerAPI();
            }
        }
    }
}
