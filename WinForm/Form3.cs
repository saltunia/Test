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
    public partial class Form3 : UserControl
    {
        Label lbVopr = new Label();
        Label lbVopr1 = new Label();
        TextBox[] th = new TextBox[15];
        CheckBox[] ch = new CheckBox[15];
        byte[] truth = new byte[15];


        public Form3() : this(0, "") { }

        public Form3(int idV, string textVopr)
        {

            InitializeComponent();
            this.answersTableAdapter.Fill(sNTBDataSet.answers, idV);
            int tru = (int)answersTableAdapter.ScalarQuery(idV);
            if (BSAnsv == null)
                return;

            lbVopr.AutoSize = true;
            lbVopr.MaximumSize = new Size(750, 0);
            lbVopr.Font = new Font("Times New Roman", 12, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            lbVopr.ForeColor = System.Drawing.Color.Blue;
            lbVopr.Location = new Point(6, 7);
            lbVopr.Text = textVopr;

            lbVopr.Show();
            this.Controls.Add(lbVopr);
            lbVopr1.AutoSize = true;
            lbVopr1.MaximumSize = new Size(750, 0);
            //lbVopr1.Font = new Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            lbVopr1.Location = new Point(6, lbVopr.Size.Height + 10);
            lbVopr1.ForeColor = System.Drawing.Color.Crimson;
            if (tru.ToString() == "1")
            {
                lbVopr1.Text = "Выберите " + tru.ToString() + " правильный вариант ответа";
                lbVopr1.Show();
            }
            else
            {
                lbVopr1.Text = "Выберите " + tru.ToString() + " правильных вариантов ответа";
                lbVopr1.Show();
            }
            this.Controls.Add(lbVopr1);
            int colI = BSAnsv.Count;
            int visot = 74;
            int vistotext = 60;
            lbVopr1.MouseEnter += new EventHandler(Form3_MouseEnter);
            lbVopr.MouseEnter += new EventHandler(Form3_MouseEnter);
            lbVopr.MouseLeave += new EventHandler(Form3_MouseLeave);
            lbVopr1.MouseLeave += new EventHandler(Form3_MouseLeave);
            //this.SuspendLayout();
            this.Size = new System.Drawing.Size(750, 20 + lbVopr.Size.Height + lbVopr1.Size.Height);
            for (int i = 0; i < colI; ++i)
            {
                this.Size = new Size(750, this.Size.Height + 40);
                ch[i] = new CheckBox();
                ch[i].Tag = i as object;
                ch[i].MouseDown += new MouseEventHandler(ch_MouseDown);
                ch[i].MouseUp += new MouseEventHandler(ch_MouseUp);
                ch[i].MouseEnter += new EventHandler(Form3_MouseEnter);
                ch[i].MouseLeave += new EventHandler(Form3_MouseLeave);
                th[i] = new TextBox();
                th[i].MouseEnter += new EventHandler(Form3_MouseEnter);
                th[i].MouseLeave += new EventHandler(Form3_MouseLeave);
                truth[i] = (byte)((DataRowView)BSAnsv.Current).Row["truth"];
                this.Controls.Add(ch[i]);
                this.Controls.Add(th[i]);
                th[i].Location = new Point(42,
                this.Size.Height - 38);
                vistotext = vistotext + 10;
                th[i].Size = new Size(700, 40);
                th[i].Multiline = true;
                th[i].Text = (string)((DataRowView)BSAnsv.Current).Row["text"].ToString();
                th[i].BackColor = System.Drawing.SystemColors.Control;
                ch[i].BackColor = System.Drawing.SystemColors.Control;

                th[i].ReadOnly = true;
                th[i].BorderStyle = BorderStyle.None;
                ch[i].Location = new Point(21, this.Size.Height - 40);
                ch[i].Size = new Size(15, 20);
                visot = visot + 50;
                ch[i].Text = "";// (string)((DataRowView)BSAnsv.Current).Row["text"].ToString();
                ch[i].Show();
                this.Refresh();
                BSAnsv.MoveNext();
            }
            //int t = 0;
            //PerformLayout();
        }

        public int GetMySize()
        {
            int colI = BSAnsv.Count;
            return this.Size.Height; // +(30 * colI);
        }


        public string GetMyAnsw()
        {
            string strI = "";
            strI = lbVopr.Text + "\n";
            strI = strI + lbVopr1.Text + "\n";
            for (int i = 0; i < 15; ++i)
            {
                //if (th[i].Text.Length > 0)
                if (th[i] != null)
                {
                    if (ch[i].Checked == true)
                    {
                        strI = strI + "Выбрано          ";
                    }
                    else { strI = strI + "Не выбрано     "; }
                    if (truth[i] == 1)
                    {
                        strI = strI + "**Верно**     ";
                    }
                    else
                    {
                        strI = strI + "Не верно     ";
                    }
                    strI = strI + th[i].Text + "\n";
                }

            }

            //strI = strI + "\n";
            //strI = strI + AmTruth() + "\n";
            if (AmTruth() == 0)
            {

                strI = strI + "-------------------------------------------------" + "\n";
                strI = strI + "Результат: на вопрос отвечено неверно" + "\n";
                strI = strI + "\n" + "\n";
            }
            if (AmTruth() == 1)
            {

                strI = strI + "-------------------------------------------------" + "\n";
                strI = strI + "Ррезультат: на вопрос отвечено верно" + "\n";
                strI = strI + "\n" + "\n";
            }

            return strI;
        }

        public int AmTruth()
        {
            //int tt = 1;
            for (int i = 0; i < 15 && th[i] != null; ++i)
            {
                if (ch[i].Checked != true)
                {
                    if (truth[i] == 1)
                    {
                        //tt = 0;
                        return 0;
                    }
                }
                if (ch[i].Checked == true)
                {
                    if (truth[i] != 1)
                    {
                        //tt = 0;
                        return 0;
                    }
                }
            }
            return 1;
        }

        private void Form3_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.SystemColors.Info;
            foreach (Control cn in this.Controls)
            {
                if (cn is TextBox)
                {
                    TextBox t = cn as TextBox;
                    t.BackColor = System.Drawing.SystemColors.Info;
                }
                if (cn is CheckBox)
                {
                    CheckBox t = cn as CheckBox;
                    t.BackColor = System.Drawing.SystemColors.Info;
                }
            }
        }

        private void Form3_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.SystemColors.Control;
            foreach (Control cn in this.Controls)
            {
                if (cn is TextBox)
                {
                    TextBox t = cn as TextBox;
                    t.BackColor = System.Drawing.SystemColors.Control;
                }
                if (cn is CheckBox)
                {
                    CheckBox t = cn as CheckBox;
                    t.BackColor = System.Drawing.SystemColors.Control;
                }
            }
        }

        private void ch_MouseDown(object sender, MouseEventArgs e)
        {
            if ((sender is CheckBox) == true && e.Button == MouseButtons.Middle)
            {
                CheckBox ch = sender as CheckBox;
                int i = (int)ch.Tag;
               /* if (truth[i] == 1)
                   ch.Cursor = System.Windows.Forms.Cursors.AppStarting;*/
            }
        }

        private void ch_MouseUp(object sender, MouseEventArgs e)
        {
          /*  if ((sender is CheckBox) == true) // && e.Button == MouseButtons.Middle)
            {
                CheckBox ch = sender as CheckBox;
                ch.Cursor = System.Windows.Forms.Cursors.Arrow;
            }*/
        }
    }
}
