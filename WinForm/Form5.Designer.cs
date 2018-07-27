namespace WinForm
{
	partial class Form5
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.textDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.questionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.sNTBDataSet = new WinForm.SNTBDataSet();
			this.answersBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.bsqa = new System.Windows.Forms.BindingSource(this.components);
			this.quesansTableAdapter = new WinForm.SNTBDataSetTableAdapters.quesansTableAdapter();
			this.answersTableAdapter = new WinForm.SNTBDataSetTableAdapters.answersTableAdapter();
			this.questionsTableAdapter = new WinForm.SNTBDataSetTableAdapters.questionsTableAdapter();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.vopridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.textDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.truthDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.questionsBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sNTBDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.answersBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bsqa)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeight = 30;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.textDataGridViewTextBoxColumn1});
			this.dataGridView1.DataSource = this.questionsBindingSource;
			this.dataGridView1.Location = new System.Drawing.Point(12, 79);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridView1.RowTemplate.Height = 30;
			this.dataGridView1.Size = new System.Drawing.Size(902, 256);
			this.dataGridView1.TabIndex = 3;
			this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
			// 
			// idDataGridViewTextBoxColumn
			// 
			this.idDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.idDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
			this.idDataGridViewTextBoxColumn.HeaderText = "id";
			this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
			this.idDataGridViewTextBoxColumn.ReadOnly = true;
			this.idDataGridViewTextBoxColumn.Visible = false;
			// 
			// textDataGridViewTextBoxColumn1
			// 
			this.textDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.textDataGridViewTextBoxColumn1.DataPropertyName = "text";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkSeaGreen;
			this.textDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
			this.textDataGridViewTextBoxColumn1.HeaderText = " Вопросы";
			this.textDataGridViewTextBoxColumn1.Name = "textDataGridViewTextBoxColumn1";
			this.textDataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// questionsBindingSource
			// 
			this.questionsBindingSource.DataMember = "questions";
			this.questionsBindingSource.DataSource = this.sNTBDataSet;
			// 
			// sNTBDataSet
			// 
			this.sNTBDataSet.DataSetName = "SNTBDataSet";
			this.sNTBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// answersBindingSource
			// 
			this.answersBindingSource.DataMember = "answers";
			this.answersBindingSource.DataSource = this.sNTBDataSet;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "ПТБ",
            "ПТЭ",
            "ППБ"});
			this.comboBox1.Location = new System.Drawing.Point(6, 21);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(156, 21);
			this.comboBox1.TabIndex = 5;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// bsqa
			// 
			this.bsqa.DataMember = "quesans";
			this.bsqa.DataSource = this.sNTBDataSet;
			// 
			// quesansTableAdapter
			// 
			this.quesansTableAdapter.ClearBeforeFill = true;
			// 
			// answersTableAdapter
			// 
			this.answersTableAdapter.ClearBeforeFill = true;
			// 
			// questionsTableAdapter
			// 
			this.questionsTableAdapter.ClearBeforeFill = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.comboBox1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(173, 61);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Выберите тему";
			// 
			// dataGridView2
			// 
			this.dataGridView2.AllowUserToAddRows = false;
			this.dataGridView2.AllowUserToDeleteRows = false;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView2.AutoGenerateColumns = false;
			this.dataGridView2.ColumnHeadersHeight = 30;
			this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.vopridDataGridViewTextBoxColumn,
            this.textDataGridViewTextBoxColumn,
            this.truthDataGridViewTextBoxColumn1});
			this.dataGridView2.DataSource = this.answersBindingSource;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle6;
			this.dataGridView2.Location = new System.Drawing.Point(12, 341);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.ReadOnly = true;
			this.dataGridView2.RowTemplate.Height = 30;
			this.dataGridView2.Size = new System.Drawing.Size(902, 234);
			this.dataGridView2.TabIndex = 2;
			// 
			// vopridDataGridViewTextBoxColumn
			// 
			this.vopridDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.vopridDataGridViewTextBoxColumn.DataPropertyName = "vopr_id";
			this.vopridDataGridViewTextBoxColumn.FillWeight = 200F;
			this.vopridDataGridViewTextBoxColumn.HeaderText = "vopr_id";
			this.vopridDataGridViewTextBoxColumn.Name = "vopridDataGridViewTextBoxColumn";
			this.vopridDataGridViewTextBoxColumn.ReadOnly = true;
			this.vopridDataGridViewTextBoxColumn.Visible = false;
			this.vopridDataGridViewTextBoxColumn.Width = 67;
			// 
			// textDataGridViewTextBoxColumn
			// 
			this.textDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.textDataGridViewTextBoxColumn.DataPropertyName = "text";
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkSeaGreen;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.textDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
			this.textDataGridViewTextBoxColumn.FillWeight = 200F;
			this.textDataGridViewTextBoxColumn.HeaderText = "Варианты ответов";
			this.textDataGridViewTextBoxColumn.Name = "textDataGridViewTextBoxColumn";
			this.textDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// truthDataGridViewTextBoxColumn1
			// 
			this.truthDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			this.truthDataGridViewTextBoxColumn1.DataPropertyName = "truth";
			this.truthDataGridViewTextBoxColumn1.HeaderText = "Правильно";
			this.truthDataGridViewTextBoxColumn1.Name = "truthDataGridViewTextBoxColumn1";
			this.truthDataGridViewTextBoxColumn1.ReadOnly = true;
			this.truthDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.truthDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.truthDataGridViewTextBoxColumn1.Width = 88;
			// 
			// Form5
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(926, 587);
			this.Controls.Add(this.dataGridView2);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form5";
			this.Text = "Вопросы и ответы";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Form5_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.questionsBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sNTBDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.answersBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bsqa)).EndInit();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.BindingSource bsqa;
		private SNTBDataSet sNTBDataSet;
        private SNTBDataSetTableAdapters.quesansTableAdapter quesansTableAdapter;
        private System.Windows.Forms.BindingSource answersBindingSource;
        private SNTBDataSetTableAdapters.answersTableAdapter answersTableAdapter;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource questionsBindingSource;
        private SNTBDataSetTableAdapters.questionsTableAdapter questionsTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn vopridDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn textDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn truthDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn textDataGridViewTextBoxColumn1;

	}
}