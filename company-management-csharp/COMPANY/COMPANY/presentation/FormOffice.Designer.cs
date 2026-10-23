namespace COMPANY_A2.presentation
{
    partial class FormOffice
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
            lstOffice = new ListBox();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnInsert = new Button();
            numThreeYearBonus = new NumericUpDown();
            cmbCountry = new ComboBox();
            txtId = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtAddress = new TextBox();
            txtCity = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numThreeYearBonus).BeginInit();
            SuspendLayout();
            // 
            // lstOffice
            // 
            lstOffice.FormattingEnabled = true;
            lstOffice.Location = new Point(12, 21);
            lstOffice.Margin = new Padding(3, 2, 3, 2);
            lstOffice.Name = "lstOffice";
            lstOffice.Size = new Size(245, 334);
            lstOffice.TabIndex = 1;
            lstOffice.SelectedIndexChanged += lstCountries_SelectedIndexChanged;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(587, 320);
            btnClear.Margin = new Padding(3, 2, 3, 2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(82, 22);
            btnClear.TabIndex = 21;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(420, 320);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(82, 22);
            btnDelete.TabIndex = 20;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(587, 260);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(82, 22);
            btnUpdate.TabIndex = 19;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(420, 260);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(82, 22);
            btnInsert.TabIndex = 18;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // numThreeYearBonus
            // 
            numThreeYearBonus.DecimalPlaces = 2;
            numThreeYearBonus.Location = new Point(448, 189);
            numThreeYearBonus.Margin = new Padding(3, 2, 3, 2);
            numThreeYearBonus.Name = "numThreeYearBonus";
            numThreeYearBonus.Size = new Size(221, 23);
            numThreeYearBonus.TabIndex = 17;
            numThreeYearBonus.ValueChanged += numThreeYearBonus_ValueChanged;
            // 
            // cmbCountry
            // 
            cmbCountry.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCountry.FormattingEnabled = true;
            cmbCountry.Location = new Point(448, 78);
            cmbCountry.Margin = new Padding(3, 2, 3, 2);
            cmbCountry.Name = "cmbCountry";
            cmbCountry.Size = new Size(221, 23);
            cmbCountry.TabIndex = 16;
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(448, 42);
            txtId.Margin = new Padding(3, 2, 3, 2);
            txtId.Name = "txtId";
            txtId.Size = new Size(221, 23);
            txtId.TabIndex = 15;
            txtId.TextChanged += txtId_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(350, 191);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 14;
            label3.Text = "3 year bonus:";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(353, 81);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 13;
            label2.Text = "Country (id):";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(353, 50);
            label1.Name = "label1";
            label1.Size = new Size(20, 15);
            label1.TabIndex = 12;
            label1.Text = "Id:";
            label1.Click += label1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(353, 116);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 22;
            label4.Text = "City:";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(353, 152);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 23;
            label5.Text = "Address:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(448, 149);
            txtAddress.Margin = new Padding(3, 2, 3, 2);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(221, 23);
            txtAddress.TabIndex = 24;
            txtAddress.TextChanged += txtAddress_TextChanged;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(448, 113);
            txtCity.Margin = new Padding(3, 2, 3, 2);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(221, 23);
            txtCity.TabIndex = 25;
            txtCity.TextChanged += txtCity_TextChanged;
            // 
            // FormOffice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1098, 714);
            Controls.Add(txtCity);
            Controls.Add(txtAddress);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(numThreeYearBonus);
            Controls.Add(cmbCountry);
            Controls.Add(txtId);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lstOffice);
            Name = "FormOffice";
            Text = "FormOffice";
            Load += FormOffice_Load;
            ((System.ComponentModel.ISupportInitialize)numThreeYearBonus).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstOffice;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnInsert;
        private NumericUpDown numThreeYearBonus;
        private ComboBox cmbCountry;
        private TextBox txtId;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label5;
        private TextBox txtAddress;
        private TextBox txtCity;
    }
}