using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.IO;

namespace WinForm
{
    public partial class Reg : Form
    {
        private ManagementObject mo = new ManagementObject("Win32_LogicalDisk.DeviceID=\"C:\"");
        private int kol;
        
        public Reg()
        {
            InitializeComponent();

			string strF = Environment.GetEnvironmentVariable("ALLUSERSPROFILE") + "\\SNTB.sdf";
			if (!File.Exists(strF))
			{
				byte[] bytF = Properties.Resources.SNTB;
				File.WriteAllBytes(strF, bytF);
			}
        }
        private Dictionary<char, int> hexdecval = new Dictionary<char, int>{
        {'0', 0},
        {'1', 1},
        {'2', 2},
        {'3', 3},
        {'4', 4},
        {'5', 5},
        {'6', 6},
        {'7', 7},
        {'8', 8},
        {'9', 9},
        {'a', 10},
        {'b', 11},
        {'c', 12},
        {'d', 13},
        {'e', 14},
        {'f', 15},};
        private decimal HexToDec(string hex)
        {
            decimal result = 0;
            hex = hex.ToLower();

            for (int i = 0; i < hex.Length; i++)
            {
                char valAt = hex[hex.Length - 1 - i];
                result += hexdecval[valAt] * (uint)Math.Pow(16, i);
            }
            return result;
        }
        private void Reg_Load(object sender, EventArgs e)
        {
			// TODO: данная строка кода позволяет загрузить данные в таблицу "sNTBDataSet.registr". При необходимости она может быть перемещена или удалена.
			this.registrTableAdapter.Fill(this.sNTBDataSet.registr);
            kol = (int) registrTableAdapter.ScalarQuery();
            if (kol != 0)
            {
                bsReg.MoveFirst();
                Glob.end = (DateTime)((DataRowView)bsReg.Current).Row["endDt"];
            }
            
            if (kol == 0)
            {
                label1.Text = "Для получения доступа передайте \nнижеследующий код на номер:\n0 312 97 66 88 доп. 62 03";
                mo.Get();
                textBox1.Text = mo["VolumeSerialNumber"].ToString() + "*" + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
                label3.Text = "Введите полученный от \nадминистратора номер:";
                textBox2.Focus();
            }
            else
            {
                Glob.ost = Glob.end.Subtract(DateTime.Now);
                label1.Text = "Вы уже зарегистрированы.";
                textBox1.Visible = false;
                textBox2.Visible = false;
                label2.Visible = false;
                label4.Visible = false;
                label3.Text = "Желаем ответить на все \n   вопросы правильно!";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (kol==0) { 
                string kod = "", nomer="",den="";
                if (textBox2.Text == "")
                {
                    MessageBox.Show("  Вы не ввели \nрегистрационный номер!", "Внимание!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Focus();
                }
                else
                {
					nomer = textBox2.Text.ToString();
					try
					{
						for (int i = nomer.Length - 1; i > nomer.Length - 4; i--)
						{
							den += nomer[i];
						}
						for (int j = nomer.Length - 4; j >= 0; j--)
						{
							kod += nomer[j];
						}
						nomer = "";
						foreach (char ch in textBox1.Text)
						{
							if (ch == '*')
								break;
							else
								nomer += ch;
						}
					}
					catch (Exception ex) 
					{ 
						MessageBox.Show("Неправильный номер!"); 
						textBox2.Text = ""; 
						textBox2.Focus();
						ex.ToString(); 
						return;  
					}
					nomer = (HexToDec(nomer)).ToString();
					if (kod == nomer)
					{
						double kolDn = Convert.ToDouble(den);
						Glob.end = DateTime.Now.AddDays(kolDn);
						Glob.globDen = (int)kolDn;
						registrTableAdapter.InsertQuery((int)kolDn, DateTime.Now, Glob.end);
						Glob.start = 1;
						MessageBox.Show("Вы зарегистрированы, \nжелаем ответить на все вопросы правильно \nУдачи Вам!");
						Form ff = new Form7();
						ff.Show();
						this.Visible = false;
					}
					else
					{
						MessageBox.Show("Регистрация не удалась!");
						Application.Exit();
					}
				}
            }
            else
            {
                DateTime dt = DateTime.Now;
                bsReg.MoveLast();
                if ((dt > (DateTime)((DataRowView)bsReg.Current).Row["startDt"]) && (dt < Glob.end))
                {
                    registrTableAdapter.InsertQuery(Glob.globDen, DateTime.Now, Glob.end);
                    Form f = new Form7();
                    f.Show();
                    this.Visible = false;
                }
                else
                {
                    label1.Text = "";
                    label3.Text = "";
                    MessageBox.Show("Время вышло! Обратитесь к администратору."); 
                    Application.Exit();
                }
            }
        }
    }
    class Glob
    {
        public static DateTime end;
        public static int globDen;
        public static int start;
        public static TimeSpan ost;
    }
}
