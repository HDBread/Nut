using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Kompas6API5;
using NutApp;

namespace NutForm
{
    public partial class NutAppForm : Form
    {
        public NutAppForm()
        {
            InitializeComponent();
            SetNut();
        }

        #region Конструкторы
        private KompasObject _kompas;
        private KompasConnector _kompasConnector = new KompasConnector();
        private NutParameters _nutParam;
        private NutBuilder _nutBuilder;
        #endregion

        private void OKButton_Click(object sender, EventArgs e)
        {
            try
            {
                _nutParam = new NutParameters(Convert.ToDouble(DoutTextBox.Text), Convert.ToDouble(DinTextBox.Text),
                    Convert.ToDouble(DnomComboBox.Text), Convert.ToDouble(HeigthTextBox.Text),
                    Convert.ToDouble(KeyTextBox.Text), Convert.ToInt32(AngleComboBox.Text));
            }
            catch(ArgumentException)
            {

            }

            _nutBuilder = new NutBuilder(_kompas);
            _nutBuilder.BuildDetail(_nutParam);

        }

        private void GOSTComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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
            _kompas = _kompasConnector.Connect();
            _kompas.Visible = true;
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
            _kompas = null;
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

        private void DnomComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SetNut()
        {
            DoutTextBox.Text = "4,2";
            DinTextBox.Text = (Convert.ToInt32(DnomComboBox.Text) * 0.85).ToString();
            DnomComboBox.Text = "2,0";
            KeyTextBox.Text = "4,0";
            HeigthTextBox.Text = "1,6";
            AngleComboBox.Text = "15";
        }
    }
}
