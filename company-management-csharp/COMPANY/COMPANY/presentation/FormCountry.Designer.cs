namespace COMPANY_A2.presentation
{
    partial class FormCountry
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
            lstCountries = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtId = new TextBox();
            txtName = new TextBox();
            numTaxBase = new NumericUpDown();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)numTaxBase).BeginInit();
            SuspendLayout();
            // 
            // lstCountries
            // 
            lstCountries.FormattingEnabled = true;
            lstCountries.Location = new Point(10, 28);
            lstCountries.Margin = new Padding(3, 2, 3, 2);
            lstCountries.Name = "lstCountries";
            lstCountries.Size = new Size(245, 289);
            lstCountries.TabIndex = 0;
            lstCountries.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(284, 36);
            label1.Name = "label1";
            label1.Size = new Size(20, 15);
            label1.TabIndex = 1;
            label1.Text = "Id:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(284, 64);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 2;
            label2.Text = "Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(284, 97);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 3;
            label3.Text = "Tax base:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(353, 28);
            txtId.Margin = new Padding(3, 2, 3, 2);
            txtId.Name = "txtId";
            txtId.Size = new Size(221, 23);
            txtId.TabIndex = 4;
            txtId.TextChanged += txtId_TextChanged;
            // 
            // txtName
            // 
            txtName.Location = new Point(353, 64);
            txtName.Margin = new Padding(3, 2, 3, 2);
            txtName.Name = "txtName";
            txtName.Size = new Size(222, 23);
            txtName.TabIndex = 5;
            // 
            // numTaxBase
            // 
            numTaxBase.DecimalPlaces = 2;
            numTaxBase.Location = new Point(353, 97);
            numTaxBase.Margin = new Padding(3, 2, 3, 2);
            numTaxBase.Name = "numTaxBase";
            numTaxBase.Size = new Size(221, 23);
            numTaxBase.TabIndex = 7;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(325, 161);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(82, 22);
            btnInsert.TabIndex = 8;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(492, 161);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(82, 22);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(325, 221);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(82, 22);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(492, 221);
            btnClear.Margin = new Padding(3, 2, 3, 2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(82, 22);
            btnClear.TabIndex = 11;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // FormCountry
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(numTaxBase);
            Controls.Add(txtName);
            Controls.Add(txtId);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lstCountries);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormCountry";
            Text = "FormCountry";
            Load += FormCountry_Load;
            ((System.ComponentModel.ISupportInitialize)numTaxBase).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstCountries;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtId;
        private TextBox txtName;
        private NumericUpDown numTaxBase;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        
    }
}