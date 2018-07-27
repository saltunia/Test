using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.Collections;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Data.SqlServerCe;
using System.IO;

namespace WinForm
{
    public partial class Form1 : Form
    {
        private int progId;
        private string name;
        private short testTime;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
			// TODO: данная строка кода позволяет загрузить данные в таблицу "sNTBDataSet.prog". При необходимости она может быть перемещена или удалена.
			this.progTableAdapter.Fill(this.sNTBDataSet.prog);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progId = (int)((DataRowView)progBindingSource.Current).Row["prog_id"];
            name = (string)((DataRowView)progBindingSource.Current).Row["name"];
            testTime = (short)((DataRowView)progBindingSource.Current).Row["test_time"];
            
            Form f = new Form4(progId, name, testTime);
            f.Show();
            this.Visible = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form d = new Form5();
            d.Show();
        }

		
    }
}
