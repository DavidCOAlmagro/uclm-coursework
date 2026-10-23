namespace COMPANY_A2.presentation
{
    partial class FormEmployee
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
            lstEmployee = new ListBox();
            labelID = new Label();
            txtId = new TextBox();
            labelName = new Label();
            labelCountry = new Label();
            labelIban = new Label();
            txtName = new TextBox();
            txtIban = new TextBox();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            cmbCountry = new ComboBox();
            SuspendLayout();
            // 
            // lstEmployee
            // 
            lstEmployee.FormattingEnabled = true;
            lstEmployee.Location = new Point(12, 12);
            lstEmployee.Name = "lstEmployee";
            lstEmployee.Size = new Size(209, 394);
            lstEmployee.TabIndex = 0;
            lstEmployee.SelectedIndexChanged += lstEmployee_SelectedIndexChanged;
            // 
            // labelID
            // 
            labelID.AutoSize = true;
            labelID.Location = new Point(310, 38);
            labelID.Name = "labelID";
            labelID.Size = new Size(21, 15);
            labelID.TabIndex = 1;
            labelID.Tag = "";
            labelID.Text = "ID:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(391, 35);
            txtId.Name = "txtId";
            txtId.Size = new Size(156, 23);
            txtId.TabIndex = 2;
            txtId.TextChanged += txtId_TextChanged;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(310, 72);
            labelName.Name = "labelName";
            labelName.Size = new Size(42, 15);
            labelName.TabIndex = 3;
            labelName.Text = "Name:";
            // 
            // labelCountry
            // 
            labelCountry.AutoSize = true;
            labelCountry.Location = new Point(310, 107);
            labelCountry.Name = "labelCountry";
            labelCountry.Size = new Size(53, 15);
            labelCountry.TabIndex = 4;
            labelCountry.Text = "Country:";
            // 
            // labelIban
            // 
            labelIban.AutoSize = true;
            labelIban.Location = new Point(310, 144);
            labelIban.Name = "labelIban";
            labelIban.Size = new Size(37, 15);
            labelIban.TabIndex = 5;
            labelIban.Text = "IBAN:";
            // 
            // txtName
            // 
            txtName.Location = new Point(391, 72);
            txtName.Name = "txtName";
            txtName.Size = new Size(156, 23);
            txtName.TabIndex = 6;
            // 
            // txtIban
            // 
            txtIban.Location = new Point(391, 141);
            txtIban.Name = "txtIban";
            txtIban.Size = new Size(156, 23);
            txtIban.TabIndex = 8;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(328, 202);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(75, 23);
            btnInsert.TabIndex = 9;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(480, 202);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(328, 253);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(480, 253);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 12;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // cmbCountry
            // 
            cmbCountry.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCountry.FormattingEnabled = true;
            cmbCountry.Location = new Point(391, 104);
            cmbCountry.Name = "cmbCountry";
            cmbCountry.Size = new Size(156, 23);
            cmbCountry.TabIndex = 13;
            cmbCountry.SelectedIndexChanged += cmbCountry_SelectedIndexChanged;
            // 
            // FormEmployee
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbCountry);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(txtIban);
            Controls.Add(txtName);
            Controls.Add(labelIban);
            Controls.Add(labelCountry);
            Controls.Add(labelName);
            Controls.Add(txtId);
            Controls.Add(labelID);
            Controls.Add(lstEmployee);
            Name = "FormEmployee";
            Text = "FormEmployee";
            Load += FormEmployee_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstEmployee;
        private Label labelID;
        private TextBox txtId;
        private Label labelName;
        private Label labelCountry;
        private Label labelIban;
        private TextBox txtName;
        private TextBox txtIban;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private ComboBox cmbCountry;
    }
}