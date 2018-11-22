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

namespace NutForm
{
    public partial class NutAppForm : Form
    {
        public NutAppForm()
        {
            InitializeComponent();
        }

        private KompasObject _kompas;

        private void OKButton_Click(object sender, EventArgs e)
        {

        }

        private void GOSTComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StartKompasButton_Click(object sender, EventArgs e)
        {
            var type = Type.GetTypeFromProgID("KOMPAS.Application.5");
            _kompas = (KompasObject) Activator.CreateInstance(type);
            _kompas.Visible = true;
        }

        private void CloseKompasButton_Click(object sender, EventArgs e)
        {
            _kompas.Quit();
        }

        private void NutAppForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_kompas != null)
            {
                _kompas.Quit();
            }
        }

        private void DnomComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
