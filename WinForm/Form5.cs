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
	public partial class Form5 : Form
	{
		
		public Form5()
		{
			InitializeComponent();
			
		}

		private void Form5_Load(object sender, EventArgs e)
		{
			
		}

		
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //questionsTableAdapter.
            if (comboBox1.Text == "ПТБ")
            {
                //dataGridView1.Visible = false;
                questionsTableAdapter.FillBy(sNTBDataSet.questions, 5173, 5176, 5177, 5178, 5185);
                //dataGridView1.DataSource = bsqa;
                // dataGridView1.Visible = true;
            }
            if (comboBox1.Text == "ППБ")
            {
                //dataGridView1.Visible = false;
                questionsTableAdapter.FillBy(sNTBDataSet.questions, 5166, 3911, 5175, 0, 0);
                //dataGridView1.DataSource = bsqa;
                // dataGridView1.Visible = true;
            }
            if (comboBox1.Text == "ПТЭ")
            {
                //dataGridView1.Visible = false;
                questionsTableAdapter.FillBy(sNTBDataSet.questions, 2626, 0, 0, 0, 0);
                // dataGridView1.DataSource = bsqa;
                // dataGridView1.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (questionsBindingSource.Count > 0)
            {
                int id_vopr;
                id_vopr = (int)((DataRowView)questionsBindingSource.Current).Row["id"];
                this.answersTableAdapter.Fill(sNTBDataSet.answers, id_vopr);
                dataGridView2.Update();
            }
           
        }
	}
}
