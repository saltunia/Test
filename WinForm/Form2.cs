using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.IO;

namespace WinForm
{
    public partial class Form2 : Form
    {
        private int count = 0, v_count = 0, vopr = 0;
        private short kolTruth = 0;
        SqlCeDataAdapter ad1;
        DataTable dtProg = new DataTable();
        DataTable dtAns;
        List<DataTable> dtVopr = new List<DataTable>();
        List<int> kolVopr = new List<int>();
        List<byte> trueAn = new List<byte>();

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(int prog_id)
        {
            InitializeComponent();
            try
            {
                SqlCeConnection con = new SqlCeConnection(@"Data Source = C:\Documents and Settings\elnurae\My Documents\SNTB.sdf; Password = 123.qwe/*");
                con.Open();
                ad1 = new SqlCeDataAdapter(@"select doc_id, vopr_count from prog 
                inner join prog_test on prog.prog_id=prog_test.prog_id
                inner join prog_test_doc on prog_test.test_id=prog_test_doc.test_id
                where prog.prog_id=" + prog_id, con);
                ad1.Fill(dtProg);
                con.Close();
            }
            catch (Exception ex)
            {
                StreamWriter writer = new StreamWriter(@"C:\logForm.txt", true);
                writer.WriteLine(System.DateTime.Now.ToString());
                writer.WriteLine(ex.ToString());
                writer.WriteLine();
                writer.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button1.Text = "Старт";
            button1.Visible = true;
            button1.Enabled = true;
            button2.Visible = false;
            button3.Visible = false;
            label2.Visible = false;
            label1.Text = "Удачи вам!";
            chLB.Visible = false;

            for (int i = 0; i < dtProg.Rows.Count; i++)
            {
                dtVopr.Add(GetVopr((int)dtProg.Rows[i]["doc_id"]));
                kolVopr.Add(Convert.ToInt32(dtProg.Rows[i]["vopr_count"]));

            }   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            chLB.Visible = true;
            button1.Visible = true;
            button1.Enabled = false;
            button2.Visible = true;
            button2.Enabled = false;
            button3.Visible = true;
            button3.Enabled = true;
            button1.Text = "Далее";

             //if (button1.Text == "Далее")
             //{
             //    for(int i=0; i<chLB.Items.Count;i++)
             //    {
             //        if (chLB.GetItemChecked(i))
             //            return;
             //    }
             //}
             //else
                 

            if (count < dtVopr.Count)
            {
                if (v_count < kolVopr[count])
                {
                    kolTruth = GetKolTruth((int)dtVopr[count].Rows[v_count]["id"]);
                    dtAns = GetAnsw((int)dtVopr[count].Rows[v_count]["id"]);
                    print(dtAns, kolTruth, (string)dtVopr[count].Rows[v_count]["text"]);
                    v_count++;
                    vopr++;
                    if (v_count == (kolVopr[count]))
                    {
                        count++; 
                        v_count = 0;
                    }
                }
            }
            else 
            {
                v_count = 0; count = 0;
                button1.Enabled = false;
                button3.Enabled = false;
                button2.Enabled = true;
                label2.Visible = false;
                if (trueAn.Count == 1)
                    label1.Text = "Было задано " + vopr + " вопросов, из них Вы правильно ответили на " + trueAn.Count + " вопрос!";
                else if (trueAn.Count > 1 && trueAn.Count < 5)
                    label1.Text = "Было задано " + vopr + " вопросов, из них Вы правильно ответили на " + trueAn.Count + " вопроса!";
                else
                    label1.Text = "Было задано " + vopr + " вопросов, из них Вы правильно ответили на " + trueAn.Count + " вопросов!";
                chLB.Visible = false;
                vopr = 0;
            }
        }
        private void print(DataTable dtAns, short kolTr, string text)
        {
            this.kolTruth = kolTr;
            label1.Text = text;
            string[] otv = new string[dtAns.Rows.Count];

            if (kolTruth == 1)
            {
                label2.Text = "Выберите " + kolTruth.ToString() + " правильный ответ:";
            }
            else if (kolTruth > 1 && kolTruth < 5)
                label2.Text = "Выберите " + kolTruth.ToString() + " правильных ответa:";
            else
                label2.Text = "Выберите " + kolTruth.ToString() + " правильных ответов:";

            for (int k = 0; k < dtAns.Rows.Count;)
            {
                chLB.Items.Clear();
                otv[k] = ((string)dtAns.Rows[k]["text"]);
                k++;
                if (k == dtAns.Rows.Count)
                {
                    chLB.Items.AddRange(otv);
                    break;
                }
            }
        }
        private DataTable GetVopr(int id)
        {
            DataTable dt2 = new DataTable();
            try
            {
                SqlCeConnection con = new SqlCeConnection(@"Data Source = C:\Documents and Settings\elnurae\My Documents\SNTB.sdf; Password=123.qwe/*");
                con.Open();
                SqlCeDataAdapter ad2 = new SqlCeDataAdapter(@"SELECT id, text FROM questions where doc_id=" + id + " order by NEWID()", con);
                ad2.Fill(dt2);
                con.Close();
            }
            catch (Exception ex)
            {
                StreamWriter writer = new StreamWriter(@"C:\logForm.txt", true);
                writer.WriteLine(System.DateTime.Now.ToString());
                writer.WriteLine(ex.ToString());
                writer.WriteLine();
                writer.Close();
            }
            return dt2;
        }
        private DataTable GetAnsw(int id)
        {
            DataTable dt3 = new DataTable();
            try
            {
                SqlCeConnection con = new SqlCeConnection(@"Data Source = C:\Documents and Settings\elnurae\My Documents\SNTB.sdf; Password=123.qwe/*");
                con.Open();
                SqlCeDataAdapter ad3 = new SqlCeDataAdapter("select text, truth from answers where vopr_id = " + id + " order by NEWID()", con);
                ad3.Fill(dt3);
                con.Close();
            }
            catch (Exception ex)
            {
                StreamWriter writer = new StreamWriter(@"C:\logForm.txt", true);
                writer.WriteLine(System.DateTime.Now.ToString());
                writer.WriteLine(ex.ToString());
                writer.WriteLine();
            }
            return dt3;
        }
        private short GetKolTruth(int id)
        {
            short kolTr = 0;
            try
            {
                SqlCeConnection con = new SqlCeConnection(@"Data Source = C:\Documents and Settings\elnurae\My Documents\SNTB.sdf; Password=123.qwe/*");
                con.Open();
                SqlCeCommand com = new SqlCeCommand("select count(truth) as kolTr from answers where vopr_id = " + id + " and truth=1", con);
                kolTr = Convert.ToInt16(com.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                StreamWriter writer = new StreamWriter(@"C:\logForm.txt", true);
                writer.WriteLine(System.DateTime.Now.ToString());
                writer.WriteLine(ex.ToString());
                writer.WriteLine();
            }
            return kolTr;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            for(int i = 0; i < chLB.Items.Count; i++)
            {
                if(chLB.GetItemChecked(i))
                    if((Convert.ToByte(dtAns.Rows[i]["truth"])==1))
                        trueAn.Add(1);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int k = 0;
            button3.Text = "Подтвердить";
            
            for (int i = 0; i < chLB.Items.Count; i++)
            {
                if (chLB.GetItemChecked(i))
                    k++;
            }
            if (k != kolTruth)
            {
                MessageBox.Show("Количество выбранных ответов не верное!");
                return;
            }
            button3.Enabled = false;
            button1.Visible = true;
            button2.Visible = true;
            button1.Enabled = true;
            button1.Enabled = false;
            button1.Enabled = true;

            for (int j = 0; j < chLB.Items.Count; j++)
            {
                if (chLB.GetItemChecked(j))
                    if ((Convert.ToByte(dtAns.Rows[j]["truth"]) == 1))
                        trueAn.Add(1);
            }
        }
    }
}