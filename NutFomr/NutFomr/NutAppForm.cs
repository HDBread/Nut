using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Kompas6API5;
using NutApp;

namespace NutForm
{
    public partial class NutAppForm : Form
    {
        /// <summary>
        /// Конструктор MainForm
        /// </summary>
        public NutAppForm()
        {
            InitializeComponent();
            SetNut();
        }

        private KompasObject _kompas;
        private KompasConnector _kompasConnector = new KompasConnector();


        /// <summary>
        /// Кнопка "Построить деталь"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            try
            {
                NutParameters nutParameters = new NutParameters(Convert.ToDouble(DoutTextBox.Text),
                    Convert.ToDouble(DinTextBox.Text), Convert.ToDouble(DnomComboBox.SelectedItem),
                    Convert.ToDouble(HeightTextBox.Text), Convert.ToDouble(KeyTextBox.Text),
                    Convert.ToInt32(AngleComboBox.SelectedItem));

                NutBuilder nutBuilder = new NutBuilder(_kompas,MarkerTextBox.Text);
                nutBuilder.BuildDetail(nutParameters);
            }
            catch (ParameterException exception)
            {
                string exсeptionsMessage = "Неправильно были введены следующие параметры:\n";

                foreach (var exceptionsList in exception.ParameterExceptionses)
                {
                    exсeptionsMessage = Reporter.CheckingExсeptions(exceptionsList, exсeptionsMessage);
                }

                MessageBox.Show(exсeptionsMessage, "Перечень ошибок",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Не все параметры имели верный формат ввода", "Ошибка формата данных",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message, "Ошибка ввода текста маркировки",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Кнопка меню закрытия формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Кнопка запуска КОМПАС'а
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartKompasButton_Click(object sender, EventArgs e)
        {
            if (_kompas == null)
            {
                _kompasConnector.Connect();
                _kompas = _kompasConnector.Kompas;
                StartKompasButton.Enabled = false;
                CloseKompasButton.Enabled = true;
                OKButton.Enabled = true;
            }
        }

        /// <summary>
        /// Кнопка закрытия КОМПАС'а
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseKompasButton_Click(object sender, EventArgs e)
        {
            if (_kompas != null)
            {
                _kompasConnector.Disconnect();
                _kompas = _kompasConnector.Kompas;
                StartKompasButton.Enabled = true;
                CloseKompasButton.Enabled = false;
                OKButton.Enabled = false;
            }
        }

        /// <summary>
        /// Событие на закрытие формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NutAppForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_kompas != null)
            {
                _kompasConnector.Disconnect();
            }
        }

        /// <summary>
        /// Событие на изменение значений параметров при изменении значения номинального диаметра 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DnomComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            NutParameters nutParameters = new NutParameters(Convert.ToDouble(DnomComboBox.SelectedItem.ToString()), Convert.ToInt32(AngleComboBox.SelectedItem.ToString()));
            
            DoutTextBox.Text = nutParameters.DiameterOut.ToString();
            DinTextBox.Text = nutParameters.DiameterIn.ToString();
            KeyTextBox.Text = nutParameters.KeyParam.ToString();
            HeightTextBox.Text = nutParameters.Height.ToString();
        }

        /// <summary>
        /// Метод установки стандартных значений параметров
        /// </summary>
        private void SetNut()
        {
            NutParameters nutParameters = new NutParameters();

            AngleComboBox.SelectedItem = nutParameters.Angle.ToString();
            DnomComboBox.SelectedItem = nutParameters.Dnom.ToString();

            DoutTextBox.Text = nutParameters.DiameterOut.ToString();
            DinTextBox.Text = nutParameters.DiameterIn.ToString();
            KeyTextBox.Text = nutParameters.KeyParam.ToString();
            HeightTextBox.Text = nutParameters.Height.ToString();
        }

        /// <summary>
        /// Событие кнопки меню "О программе"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Проврка парсинка параметров
        /// </summary>
        /// <param name="diameterOut">Внешний диаметр резьбы по ссылке</param>
        /// <param name="diameterIn">Внутренний диаметр резьбы по ссылке</param>
        /// <param name="height">Выстога по ссылке</param>
        /// <param name="keyParameter">Параметр "под ключ" по ссылке</param>
        private void CheckParsing(ref double diameterOut, ref double diameterIn, ref double height,
            ref double keyParameter)
        {
            //Проверка парсинга внешнего диаметра резьбы
            if ((!double.TryParse(DoutTextBox.Text, out diameterOut)))
            {
                errorProvider.SetError(DoutTextBox, "Ошибка парсинга внешнего диаметра резьбы");
                DoutTextBox.BackColor = Color.LightSalmon;
            }
            else
            {
                errorProvider.SetError(DoutTextBox, string.Empty);
                DoutTextBox.BackColor = Color.White;
            }

            //Проверка парсинга внутреннего параметра резьбы
            if ((!double.TryParse(DinTextBox.Text, out diameterIn)))
            {
                errorProvider.SetError(DinTextBox, "Ошибка парсинга внутреннего диаметра резьбы");
                DinTextBox.BackColor = Color.LightSalmon;
            }
            else
            {
                errorProvider.SetError(DinTextBox, string.Empty);
                DinTextBox.BackColor = Color.White;
            }

            //Проверка парсинга высоты гайки
            if ((!double.TryParse(HeightTextBox.Text, out height)))
            {
                errorProvider.SetError(HeightTextBox, "Ошибка парсинга высоты гайки");
                HeightTextBox.BackColor = Color.LightSalmon;
            }
            else
            {
                errorProvider.SetError(HeightTextBox, string.Empty);
                HeightTextBox.BackColor = Color.White;
            }

            //Проверка парсинга параметра "под ключ"
            if ((!double.TryParse(KeyTextBox.Text, out keyParameter)))
            {
                errorProvider.SetError(KeyTextBox, "Ошибка парсинга параметра \"под ключ\"");
                KeyTextBox.BackColor = Color.LightSalmon;
            }
            else
            {
                errorProvider.SetError(KeyTextBox, string.Empty);
                KeyTextBox.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Событие проверки изменения текста в текстовых полях
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            double diameterOut = 0;
            double diameterIn = 0;
            double height = 0;
            double keyParameter = 0;

           CheckParsing(ref diameterOut, ref diameterIn, ref height, ref keyParameter);
        }

        private void MarkerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MarkerTextBox.Enabled = (MarkerCheckBox.Checked);
            MarkerTextBox.Text = (MarkerCheckBox.Checked) ? MarkerTextBox.Text : String.Empty;
        }
    }
}
