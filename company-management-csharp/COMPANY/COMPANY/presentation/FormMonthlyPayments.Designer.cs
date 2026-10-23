namespace COMPANY_A2.presentation
{
    partial class FormMonthlyPayments
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
            lstYearMonth = new ListBox();
            numYear = new NumericUpDown();
            numMonth = new NumericUpDown();
            btnGenerate = new Button();
            btnDelete = new Button();
            labelYear = new Label();
            labelMonth = new Label();
            labelPaymentsGenerated = new Label();
            dataGridView = new DataGridView();
            ColumnId = new DataGridViewTextBoxColumn();
            ColumnEmployee = new DataGridViewTextBoxColumn();
            ColumnSalaryGross = new DataGridViewTextBoxColumn();
            ColumnSalaryNet = new DataGridViewTextBoxColumn();
            ColumnBonnusApplied = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)numYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMonth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // lstYearMonth
            // 
            lstYearMonth.FormattingEnabled = true;
            lstYearMonth.Location = new Point(22, 67);
            lstYearMonth.Name = "lstYearMonth";
            lstYearMonth.Size = new Size(128, 319);
            lstYearMonth.TabIndex = 0;
            lstYearMonth.SelectedIndexChanged += lstYearMonth_SelectedIndexChanged;
            // 
            // numYear
            // 
            numYear.Location = new Point(241, 77);
            numYear.Maximum = new decimal(new int[] { 2026, 0, 0, 0 });
            numYear.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            numYear.Name = "numYear";
            numYear.Size = new Size(120, 23);
            numYear.TabIndex = 1;
            numYear.Tag = "";
            numYear.Value = new decimal(new int[] { 2000, 0, 0, 0 });
            numYear.ValueChanged += numYear_ValueChanged;
            // 
            // numMonth
            // 
            numMonth.Location = new Point(241, 143);
            numMonth.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            numMonth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMonth.Name = "numMonth";
            numMonth.Size = new Size(120, 23);
            numMonth.TabIndex = 2;
            numMonth.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(241, 223);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(75, 23);
            btnGenerate.TabIndex = 3;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(241, 277);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // labelYear
            // 
            labelYear.AutoSize = true;
            labelYear.Location = new Point(184, 83);
            labelYear.Name = "labelYear";
            labelYear.Size = new Size(32, 15);
            labelYear.TabIndex = 5;
            labelYear.Text = "Year:";
            // 
            // labelMonth
            // 
            labelMonth.AutoSize = true;
            labelMonth.Location = new Point(184, 145);
            labelMonth.Name = "labelMonth";
            labelMonth.Size = new Size(46, 15);
            labelMonth.TabIndex = 6;
            labelMonth.Text = "Month:";
            // 
            // labelPaymentsGenerated
            // 
            labelPaymentsGenerated.AutoSize = true;
            labelPaymentsGenerated.Location = new Point(22, 33);
            labelPaymentsGenerated.Name = "labelPaymentsGenerated";
            labelPaymentsGenerated.Size = new Size(115, 15);
            labelPaymentsGenerated.TabIndex = 7;
            labelPaymentsGenerated.Text = "Payments generated";
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ColumnId, ColumnEmployee, ColumnSalaryGross, ColumnSalaryNet, ColumnBonnusApplied });
            dataGridView.Location = new Point(389, 67);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(630, 160);
            dataGridView.TabIndex = 8;
            dataGridView.CellContentClick += dataGridView_CellContentClick;
            // 
            // ColumnId
            // 
            ColumnId.HeaderText = "Id";
            ColumnId.Name = "ColumnId";
            ColumnId.Width = 25;
            // 
            // ColumnEmployee
            // 
            ColumnEmployee.HeaderText = "Employee";
            ColumnEmployee.Name = "ColumnEmployee";
            ColumnEmployee.Width = 70;
            // 
            // ColumnSalaryGross
            // 
            ColumnSalaryGross.HeaderText = "Gross Salary";
            ColumnSalaryGross.Name = "ColumnSalaryGross";
            ColumnSalaryGross.Width = 80;
            // 
            // ColumnSalaryNet
            // 
            ColumnSalaryNet.HeaderText = "Net Salary";
            ColumnSalaryNet.Name = "ColumnSalaryNet";
            ColumnSalaryNet.Width = 90;
            // 
            // ColumnBonnusApplied
            // 
            ColumnBonnusApplied.HeaderText = "Bonnus Applied";
            ColumnBonnusApplied.Name = "ColumnBonnusApplied";
            ColumnBonnusApplied.Width = 70;
            // 
            // FormMonthlyPayments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 608);
            Controls.Add(dataGridView);
            Controls.Add(labelPaymentsGenerated);
            Controls.Add(labelMonth);
            Controls.Add(labelYear);
            Controls.Add(btnDelete);
            Controls.Add(btnGenerate);
            Controls.Add(numMonth);
            Controls.Add(numYear);
            Controls.Add(lstYearMonth);
            Name = "FormMonthlyPayments";
            Text = "FormMonthlyPayments";
            Load += FormMonthlyPayments_Load;
            ((System.ComponentModel.ISupportInitialize)numYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMonth).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstYearMonth;
        private NumericUpDown numYear;
        private NumericUpDown numMonth;
        private Button btnGenerate;
        private Button btnDelete;
        private Label labelYear;
        private Label labelMonth;
        private Label labelPaymentsGenerated;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn ColumnId;
        private DataGridViewTextBoxColumn ColumnEmployee;
        private DataGridViewTextBoxColumn ColumnSalaryGross;
        private DataGridViewTextBoxColumn ColumnSalaryNet;
        private DataGridViewTextBoxColumn ColumnBonnusApplied;
    }
}