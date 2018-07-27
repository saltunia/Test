using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace WinForm
{
	public partial class Form6 : Form
	{
		string strlab;
		public Form6(string str)
		{
			InitializeComponent();
			strlab = str;
		}

		private void Form6_Load(object sender, EventArgs e)
		{
			ReportParameter rp = new ReportParameter("ss", strlab);
			reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("ReportParameter1", strlab));
			//label1.Text = strlab;
			this.reportViewer1.RefreshReport();
		}
	}
}
