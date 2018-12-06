using System;
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

                NutBuilder nutBuilder = new NutBuilder(_kompas);
                nutBuilder.BuildDetail(nutParameters);
            }
            catch (ParameterException exception)
            {
                string exсeptionsMessage = "Неправильно были введены следующие параметры:\n";
                foreach (var exeptionsList in exception.ParameterExceptionses)
                {
                    exсeptionsMessage = Reporter.CheckingExсeptions(exeptionsList, exсeptionsMessage);
                }

                MessageBox.Show(exсeptionsMessage, "Перечень ошибок",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //TODO: Валидация парсинга
            catch (FormatException)
            {
                MessageBox.Show("Введены некоректрные символы", "Перечень ошибок",
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
            _kompasConnector.Connect();
            _kompas = _kompasConnector.Kompas;
            StartKompasButton.Enabled = false;
            CloseKompasButton.Enabled = true;
            OKButton.Enabled = true;
        }

        /// <summary>
        /// Кнопка закрытия КОМПАС'а
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseKompasButton_Click(object sender, EventArgs e)
        {
            _kompasConnector.Disconnect();
            _kompas = _kompasConnector.Kompas;
            StartKompasButton.Enabled = true;
            CloseKompasButton.Enabled = false;
            OKButton.Enabled = false;
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
            
            DoutTextBox.Text = nutParameters.DiametrOut.ToString();
            DinTextBox.Text = nutParameters.DiametrIn.ToString();
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

            DoutTextBox.Text = nutParameters.DiametrOut.ToString();
            DinTextBox.Text = nutParameters.DiametrIn.ToString();
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
    }
}
