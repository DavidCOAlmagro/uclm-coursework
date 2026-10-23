namespace COMPANY_A2.presentation
{
    partial class FormPosition
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
        private ListBox lstPosition;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnInsert;
        private TextBox txtName;
        private TextBox txtId;
        private Label labelName;
        private Label labelID;
        private ComboBox cmbEmployee;
        private Label labelEmployee;
        private ComboBox cmbOffice;
        private Label labelOffice;
        private NumericUpDown numYearSalary;
        private Label labelYearSalary;
        private DateTimePicker dtpStartDate;
        private Label labelStartDate;
        private DateTimePicker dtpEndDate;
        private Label labelEndDate;
        private Label labelHint;
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lstPosition = new ListBox();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnInsert = new Button();
            txtName = new TextBox();
            labelName = new Label();
            txtId = new TextBox();
            labelID = new Label();
            cmbEmployee = new ComboBox();
            labelEmployee = new Label();
            cmbOffice = new ComboBox();
            labelOffice = new Label();
            numYearSalary = new NumericUpDown();
            labelYearSalary = new Label();
            dtpStartDate = new DateTimePicker();
            labelStartDate = new Label();
            dtpEndDate = new DateTimePicker();
            labelEndDate = new Label();
            labelHint = new Label();
            ((System.ComponentModel.ISupportInitialize)numYearSalary).BeginInit();
            SuspendLayout();
            // 
            // lstPosition
            // 
            lstPosition.FormattingEnabled = true;
            lstPosition.Location = new Point(16, 19);
            lstPosition.Margin = new Padding(2);
            lstPosition.Name = "lstPosition";
            lstPosition.Size = new Size(376, 524);
            lstPosition.TabIndex = 0;
            lstPosition.SelectedIndexChanged += lstPosition_SelectedIndexChanged;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(827, 416);
            btnClear.Margin = new Padding(2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(91, 27);
            btnClear.TabIndex = 13;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(698, 416);
            btnDelete.Margin = new Padding(2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(91, 27);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(588, 416);
            btnUpdate.Margin = new Padding(2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(91, 27);
            btnUpdate.TabIndex = 11;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(472, 416);
            btnInsert.Margin = new Padding(2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(91, 27);
            btnInsert.TabIndex = 10;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(514, 159);
            txtName.Margin = new Padding(3, 4, 3, 4);
            txtName.Name = "txtName";
            txtName.Size = new Size(178, 27);
            txtName.TabIndex = 6;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(421, 159);
            labelName.Name = "labelName";
            labelName.Size = new Size(52, 20);
            labelName.TabIndex = 5;
            labelName.Text = "Name:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(514, 55);
            txtId.Margin = new Padding(3, 4, 3, 4);
            txtId.Name = "txtId";
            txtId.Size = new Size(178, 27);
            txtId.TabIndex = 2;
            // 
            // labelID
            // 
            labelID.AutoSize = true;
            labelID.Location = new Point(421, 59);
            labelID.Name = "labelID";
            labelID.Size = new Size(27, 20);
            labelID.TabIndex = 1;
            labelID.Tag = "";
            labelID.Text = "ID:";
            // 
            // cmbEmployee
            // 
            cmbEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmployee.FormattingEnabled = true;
            cmbEmployee.Location = new Point(514, 106);
            cmbEmployee.Margin = new Padding(3, 4, 3, 4);
            cmbEmployee.Name = "cmbEmployee";
            cmbEmployee.Size = new Size(178, 28);
            cmbEmployee.TabIndex = 4;
            cmbEmployee.SelectedIndexChanged += cmbEmployee_SelectedIndexChanged;
            // 
            // labelEmployee
            // 
            labelEmployee.AutoSize = true;
            labelEmployee.Location = new Point(421, 110);
            labelEmployee.Name = "labelEmployee";
            labelEmployee.Size = new Size(78, 20);
            labelEmployee.TabIndex = 3;
            labelEmployee.Text = "Employee:";
            // 
            // cmbOffice
            // 
            cmbOffice.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOffice.FormattingEnabled = true;
            cmbOffice.Location = new Point(514, 208);
            cmbOffice.Margin = new Padding(3, 4, 3, 4);
            cmbOffice.Name = "cmbOffice";
            cmbOffice.Size = new Size(178, 28);
            cmbOffice.TabIndex = 8;
            // 
            // labelOffice
            // 
            labelOffice.AutoSize = true;
            labelOffice.Location = new Point(421, 212);
            labelOffice.Name = "labelOffice";
            labelOffice.Size = new Size(52, 20);
            labelOffice.TabIndex = 7;
            labelOffice.Text = "Office:";
            // 
            // numYearSalary
            // 
            numYearSalary.DecimalPlaces = 2;
            numYearSalary.Location = new Point(514, 257);
            numYearSalary.Margin = new Padding(2);
            numYearSalary.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numYearSalary.Name = "numYearSalary";
            numYearSalary.Size = new Size(177, 27);
            numYearSalary.TabIndex = 15;
            // 
            // labelYearSalary
            // 
            labelYearSalary.AutoSize = true;
            labelYearSalary.Location = new Point(421, 258);
            labelYearSalary.Name = "labelYearSalary";
            labelYearSalary.Size = new Size(82, 20);
            labelYearSalary.TabIndex = 14;
            labelYearSalary.Text = "Year salary:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(514, 306);
            dtpStartDate.Margin = new Padding(2);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(178, 27);
            dtpStartDate.TabIndex = 17;
            // 
            // labelStartDate
            // 
            labelStartDate.AutoSize = true;
            labelStartDate.Location = new Point(421, 310);
            labelStartDate.Name = "labelStartDate";
            labelStartDate.Size = new Size(77, 20);
            labelStartDate.TabIndex = 16;
            labelStartDate.Text = "Start date:";
            // 
            // dtpEndDate
            // 
            dtpEndDate.Checked = false;
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(514, 355);
            dtpEndDate.Margin = new Padding(2);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.ShowCheckBox = true;
            dtpEndDate.Size = new Size(178, 27);
            dtpEndDate.TabIndex = 19;
            dtpEndDate.ValueChanged += dtpEndDate_ValueChanged;
            // 
            // labelEndDate
            // 
            labelEndDate.AutoSize = true;
            labelEndDate.Location = new Point(421, 359);
            labelEndDate.Name = "labelEndDate";
            labelEndDate.Size = new Size(71, 20);
            labelEndDate.TabIndex = 18;
            labelEndDate.Text = "End date:";
            // 
            // labelHint
            // 
            labelHint.AutoSize = true;
            labelHint.Location = new Point(421, 19);
            labelHint.Name = "labelHint";
            labelHint.Size = new Size(258, 20);
            labelHint.TabIndex = 20;
            labelHint.Text = "Select an employee to view positions.";
            // 
            // FormPosition
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1028, 624);
            Controls.Add(dtpEndDate);
            Controls.Add(labelEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(labelStartDate);
            Controls.Add(numYearSalary);
            Controls.Add(labelYearSalary);
            Controls.Add(cmbOffice);
            Controls.Add(labelOffice);
            Controls.Add(txtName);
            Controls.Add(labelName);
            Controls.Add(cmbEmployee);
            Controls.Add(labelEmployee);
            Controls.Add(txtId);
            Controls.Add(labelID);
            Controls.Add(labelHint);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(lstPosition);
            Margin = new Padding(2);
            Name = "FormPosition";
            Text = "FormPosition";
            Load += FormPosition_Load;
            ((System.ComponentModel.ISupportInitialize)numYearSalary).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


    }
}