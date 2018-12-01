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

        #region Конструкторы
        private KompasObject _kompas;
        private KompasConnector _kompasConnector = new KompasConnector();
        #endregion

        /// <summary>
        /// Кнопка "Построить деталь"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            NutParameters nutParameters = new NutParameters(Convert.ToDouble(DoutTextBox.Text), Convert.ToDouble(DinTextBox.Text),
                    Convert.ToDouble(DnomComboBox.SelectedItem), Convert.ToDouble(HeightTextBox.Text),
                    Convert.ToDouble(KeyTextBox.Text), Convert.ToInt32(AngleComboBox.SelectedItem));
            //Проверка валидности параметров
            if (nutParameters.ExeptionsList.Count != 0)
            {
                string exeptionsMessage = "Неправильны были введены следующие параметры:\n";
                foreach (var exeptionsList in nutParameters.ExeptionsList)
                {
                    exeptionsMessage = Reporter.CheckingExeptions(exeptionsList,exeptionsMessage);
                }
                MessageBox.Show(exeptionsMessage, "Печерень ошибок",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                NutBuilder nutBuilder = new NutBuilder(_kompas);
                nutBuilder.BuildDetail(nutParameters);
            }
        }

        /// <summary>
        /// Кнопка меню "О программе"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Кнопка меню закрытия формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
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
        /// Событие на изменение значений параметров в TextBox при изменении значения Dnom 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DnomComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DnomComboBox.SelectedIndex)
            {
                case 0:
                    DoutTextBox.Text = "4,2";
                    DinTextBox.Text = (Convert.ToDouble(DnomComboBox.SelectedItem) * 0.85).ToString();
                    KeyTextBox.Text = "4,0";
                    HeightTextBox.Text = "1,6";
                    break;
                case 1:
                    DoutTextBox.Text = "5,3";
                    DinTextBox.Text = (Convert.ToDouble(DnomComboBox.SelectedItem) * 0.85).ToString();
                    KeyTextBox.Text = "5,0";
                    HeightTextBox.Text = "2,0";
                    break;
                case 2:
                    DoutTextBox.Text = "5,9";
                    DinTextBox.Text = (Convert.ToDouble(DnomComboBox.SelectedItem) * 0.85).ToString();
                    KeyTextBox.Text = "5,5";
                    HeightTextBox.Text = "2,4";
                    break;
            }
        }

        /// <summary>
        /// Метод установки стандартных значений параметров
        /// </summary>
        private void SetNut()
        {
            DnomComboBox.SelectedItem = "2";
            DoutTextBox.Text = "4,2";
            DinTextBox.Text = (Convert.ToDouble(DnomComboBox.SelectedItem) * 0.85).ToString();
            KeyTextBox.Text = "4,0";
            HeightTextBox.Text = "1,6";
            AngleComboBox.SelectedItem = "15";
        }
    }
}
