using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using System.IO;

namespace WinForm
{


	public partial class Form4 : Form
	{
		int timeLeft, Ttest = 0;
		DateTime Time, startTest;
		string testName, strLog, fr;
		short testTime;
		public TimeSpan tt;
		Form3[] testNow = new Form3[100];
		int tttt;
		int prOtv;

		public Form4(int progId, string name, short time)
		{
			InitializeComponent();
			Ttest = progId;
			startTest = DateTime.Now;
			panel1.GotFocus += new EventHandler(panel1_Scroll);
			testName = name;
			testTime = time;
		}

		void panel1_Scroll(object sender, EventArgs e)
		{
			panel2.AutoScrollPosition = new Point(panel2.AutoScrollPosition.X, tttt);
		}

		private void Form4_Load_1(object sender, EventArgs e)
		{
			int k = 0;
			Time = DateTime.Now;
			timer1.Start();
			timeLeft = 1;
			label7.Text = testName;
			textBox2.Text = testTime.ToString();
			textBox3.Text = DateTime.Now.ToString().Substring(10);
			TimeSpan sp = TimeSpan.FromMinutes(testTime);
			DateTime pr = DateTime.Now;
			DateTime li = pr + sp;
            textBox1.Text = Globals.fio;
            textBox7.Text = Globals.dolj;
            textBox8.Text = Globals.res;
			textBox4.Text = li.ToString().Substring(10);
			textBox5.Text = DateTime.Now.ToString().Substring(10);
            
			textBox6.Text = testTime.ToString();

			this.Text = "Тестирование                                   " + DateTime.Now.ToString().Substring(0, 10);

			this.prog_test_docTableAdapter.Fill(sNTBDataSet.prog_test_doc, Ttest);
			BSProg.MoveFirst();
			for (int i = 0; i < BSProg.Count; ++i)
			{
				this.questionsTableAdapter.Fill(sNTBDataSet.questions, (int)((DataRowView)BSProg.Current).Row["doc_id"]);
				BSVopr.MoveFirst();
				for (int j = 0; j < Convert.ToInt32(((DataRowView)BSProg.Current).Row["vopr_count"]); j++)
				{
					MyWork(k);
					k++;
					BSVopr.MoveNext();
				}
				BSProg.MoveNext();
			}
		}
		private void MyWork(int nomI)
		{
			int nVopr = (int)((DataRowView)BSVopr.Current).Row["id"];
			string strVopr = "Вопрос № " + (nomI + 1) + ".  " + (string)((DataRowView)BSVopr.Current).Row["text"];

			testNow[nomI] = new Form3(nVopr, strVopr);
			int i = testNow[nomI].GetMySize();
			panel2.Size = new Size(800, panel2.Size.Height + i + 15);
			testNow[nomI].Location = new Point(0, panel2.Size.Height - i);
			panel2.Controls.Add(testNow[nomI]);
		}
		public string FormLog()
		{
			//rtb.Text = strLog + "\n" + "\n";
			//rtb.SelectAll();
			//rtb.SelectionColor = Color.Red;
			prOtv = 0;
			strLog = "";
            strLog = strLog + "Ф.И.О.: " + Globals.fio + "\n";
            strLog = strLog + "Предприятие: " + Globals.res + "\n";
            strLog = strLog + "Должность: " + Globals.dolj + "\n";
			strLog = strLog + "Название теста: " + testName + "\n";
			strLog = strLog + "Начало тестирования: " + DateTime.Now.ToString().Substring(0, 10) + " " + textBox3.Text + "\n";
			TimeSpan sp = TimeSpan.Parse(fr);
			TimeSpan pr = TimeSpan.Parse(textBox3.Text);
			TimeSpan li = pr + sp;
			strLog = strLog + "Окончание тестирования: " + DateTime.Now.ToString().Substring(0, 10) + " " + li + "\n";
			strLog = strLog + "Окончание тестирования: " + textBox4.Text + "\n";
			strLog = strLog + "Тест сдан за: " + textBox6.Text + "\n";
			strLog = strLog + "Вопросов в тесте: " + textBox2.Text + "\n";
			strLog = strLog + "За один правильно отвеченный вопрос: 1 балл." + "\n";
			strLog = strLog + "За один неправильно отвеченный вопрос: 0 баллов." + "\n";
			int t = panel2.Controls.Count;
			for (int i = 0; i < t; ++i)
			{
				prOtv = prOtv + testNow[i].AmTruth();
			}
			strLog = strLog + "Количество правильных ответов: " + prOtv.ToString() + "\n";
			strLog = strLog + "--------------------------------------------------------------------" + "\n";
			if (prOtv == 1)
			{
				strLog = strLog + "Результат: " + prOtv.ToString() + " балл" + "\n" + "\n" + "\n";
			}
			if (prOtv <= 4 & prOtv != 1)
			{
				strLog = strLog + "Результат: " + prOtv.ToString() + " баллa" + "\n" + "\n" + "\n";
			}
			if (prOtv > 4)
			{
				strLog = strLog + "Результат: " + prOtv.ToString() + " баллов" + "\n" + "\n" + "\n";
			}

			//BStest.MoveFirst();


			for (int i = 0; i < t; ++i)
			{
				strLog = strLog + testNow[i].GetMyAnsw();
			}
			//strLog = strLog + "\n" + "\n";
			//strLog = strLog + "Экзаменатор: " + "_________________________" + "\n" + "\n";
			//strLog = strLog + "Дата тестирования: " + DateTime.Now.ToString().Substring(0, 10) + "\n" + "\n";
			//strLog = strLog + "Подпись: " + "_________________________" + "\n" + "\n";
			return strLog;
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			int t = panel2.Controls.Count;
			for (int i = 0; i < t; ++i)
				prOtv = prOtv + testNow[i].AmTruth();
			timer1.Stop();
			fr = textBox5.Text;
			string s = FormLog();
			Form f = new Form6(s);
			MessageBox.Show("Спасибо! Вы протестировались." + "\n" + "Всего заданий в тесте: " + textBox2.Text + "\n" + "Из них правильно: " + prOtv.ToString() + "\n" + "-----------------------------------------" + "\n" + "Вы набрали:" + prOtv.ToString() + " балла" + "\n" + "\n");
			f.Show();
			this.Close();
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +"\\" +Globals.fio +".doc"))
            // если нет такого открываем новый
            {
                FileStream fs = File.Create(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + Globals.fio + ".doc");
                fs.Close();
            }
            StreamWriter logWrite = File.AppendText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + Globals.fio + ".doc");
            logWrite.WriteLine(s);
            logWrite.Dispose(); 
           // queriesTableAdapter1.Insertprotokol(Globals.fio, Globals.res, Globals.dolj, s);
			//Application.Exit();
		}
		public void timer1_Tick_1(object sender, EventArgs e)
		{
			int ff = 0;
			ff = Convert.ToInt16(testTime) * 60;
			if (timeLeft > 0 && timeLeft < ff)
			{
				tt = DateTime.Now - Time;
				textBox5.Text = tt.ToString().Substring(0, 8);
				++timeLeft;
			}
			else
			{
				timer1.Stop();
                //this.Close();
				MessageBox.Show("Время вышло!");
                int t = panel2.Controls.Count;
                for (int i = 0; i < t; ++i)
                    prOtv = prOtv + testNow[i].AmTruth();
                timer1.Stop();
                fr = textBox5.Text;
                textBox3.Text = textBox3.Text;

                string s = FormLog();
                Form f = new Form6(s);
                MessageBox.Show("Спасибо! Вы протестировались." + "\n" + "Всего заданий в тесте: " + textBox2.Text + "\n" + "Из них правильно: " + prOtv.ToString() + "\n" + "-----------------------------------------" + "\n" + "Вы набрали:" + prOtv.ToString() + " балла" + "\n" + "\n");
                f.Show();
                this.Close();
                if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + Globals.fio + ".doc"))
                // если нет такого открываем новый
                {
                    FileStream fs = File.Create(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + Globals.fio + ".doc");
                    fs.Close();
                }
                StreamWriter logWrite = File.AppendText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + Globals.fio + ".doc");
                logWrite.WriteLine(s);
                logWrite.Dispose(); 
				//Application.Exit();
			}
		}

		private void panel1_Scroll(object sender, ScrollEventArgs e)
		{
			tttt = e.OldValue;
		}

		//private void Form4_FormClosing(object sender, FormClosingEventArgs e)
		//{
		//    Application.Exit();
		//}
	}
}