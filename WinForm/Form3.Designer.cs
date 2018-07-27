namespace WinForm
{
    partial class Form3
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
			this.BSAnsv = new System.Windows.Forms.BindingSource(this.components);
			this.sNTBDataSet = new WinForm.SNTBDataSet();
			this.answersTableAdapter = new WinForm.SNTBDataSetTableAdapters.answersTableAdapter();
			((System.ComponentModel.ISupportInitialize)(this.BSAnsv)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sNTBDataSet)).BeginInit();
			this.SuspendLayout();
			// 
			// BSAnsv
			// 
			this.BSAnsv.DataMember = "answers";
			this.BSAnsv.DataSource = this.sNTBDataSet;
			// 
			// sNTBDataSet
			// 
			this.sNTBDataSet.DataSetName = "SNTBDataSet";
			this.sNTBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// answersTableAdapter
			// 
			this.answersTableAdapter.ClearBeforeFill = true;
			// 
			// Form3
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Name = "Form3";
			this.Size = new System.Drawing.Size(985, 150);
			this.MouseEnter += new System.EventHandler(this.Form3_MouseEnter);
			this.MouseLeave += new System.EventHandler(this.Form3_MouseLeave);
			((System.ComponentModel.ISupportInitialize)(this.BSAnsv)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sNTBDataSet)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.BindingSource BSAnsv;
		private SNTBDataSet sNTBDataSet;
		private SNTBDataSetTableAdapters.answersTableAdapter answersTableAdapter;

	}
}