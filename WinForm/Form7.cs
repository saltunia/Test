using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForm
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.SelectedItem != "" && comboBox2.SelectedItem != "")
            {
                Globals.fio = textBox1.Text;
                Globals.dolj = comboBox2.Text;
                Globals.res = comboBox1.Text;
                //
                Form dd = new Form1();
                dd.Show();this.Visible=false;
            }
            else { MessageBox.Show("Ни все поля заполнены!!!"); }
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
