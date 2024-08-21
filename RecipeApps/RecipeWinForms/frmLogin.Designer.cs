namespace RecipeWinForms
{
    partial class frmLogin
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
            tblMain = new TableLayoutPanel();
            txtUserName = new TextBox();
            txtPassword = new TextBox();
            lblUserName = new Label();
            lblPassword = new Label();
            tblButtons = new TableLayoutPanel();
            btnCancel = new Button();
            btnLogin = new Button();
            tblMain.SuspendLayout();
            tblButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.Controls.Add(txtUserName, 1, 0);
            tblMain.Controls.Add(txtPassword, 1, 1);
            tblMain.Controls.Add(lblUserName, 0, 0);
            tblMain.Controls.Add(lblPassword, 0, 1);
            tblMain.Controls.Add(tblButtons, 1, 2);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 4;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.Size = new Size(698, 194);
            tblMain.TabIndex = 2;
            // 
            // txtUserName
            // 
            txtUserName.Dock = DockStyle.Fill;
            txtUserName.Location = new Point(141, 3);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(554, 39);
            txtUserName.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Dock = DockStyle.Fill;
            txtPassword.Location = new Point(141, 48);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(554, 39);
            txtPassword.TabIndex = 1;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(3, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(132, 32);
            lblUserName.TabIndex = 2;
            lblUserName.Text = "User Name";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(3, 45);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(111, 32);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password";
            // 
            // tblButtons
            // 
            tblButtons.ColumnCount = 2;
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblButtons.Controls.Add(btnCancel, 0, 0);
            tblButtons.Controls.Add(btnLogin, 1, 0);
            tblButtons.Dock = DockStyle.Fill;
            tblButtons.Location = new Point(141, 93);
            tblButtons.Name = "tblButtons";
            tblButtons.RowCount = 1;
            tblButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblButtons.Size = new Size(554, 50);
            tblButtons.TabIndex = 6;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.Dock = DockStyle.Fill;
            btnCancel.Location = new Point(3, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(271, 44);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            btnLogin.AutoSize = true;
            btnLogin.Dock = DockStyle.Fill;
            btnLogin.Location = new Point(280, 3);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(271, 44);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(698, 194);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "frmLogin";
            Text = "Login";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblButtons.ResumeLayout(false);
            tblButtons.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tblMain;
        private TextBox txtUserName;
        private TextBox txtPassword;
        private Label lblUserName;
        private Label lblPassword;
        private Button btnCancel;
        private Button btnLogin;
        private TableLayoutPanel tblButtons;
    }
}