namespace RecipeWinForms
{
    partial class frmNewCookbook
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
            btnSave = new Button();
            btnDelete = new Button();
            lblCookbookName = new Label();
            txtCookbookName = new TextBox();
            lblUser = new Label();
            lstUsers = new ComboBox();
            lblPrice = new Label();
            lblActive = new Label();
            tblPrice = new TableLayoutPanel();
            lblDateCreated = new Label();
            txtPrice = new TextBox();
            txtDateCreated = new TextBox();
            ckActive = new CheckBox();
            tblData = new TableLayoutPanel();
            gData = new DataGridView();
            btnSaveRecipe = new Button();
            tblMain.SuspendLayout();
            tblPrice.SuspendLayout();
            tblData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gData).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tblMain.Controls.Add(btnSave, 0, 0);
            tblMain.Controls.Add(btnDelete, 1, 0);
            tblMain.Controls.Add(lblCookbookName, 0, 1);
            tblMain.Controls.Add(txtCookbookName, 1, 1);
            tblMain.Controls.Add(lblUser, 0, 2);
            tblMain.Controls.Add(lstUsers, 1, 2);
            tblMain.Controls.Add(lblPrice, 0, 3);
            tblMain.Controls.Add(lblActive, 0, 4);
            tblMain.Controls.Add(tblPrice, 1, 3);
            tblMain.Controls.Add(ckActive, 1, 4);
            tblMain.Controls.Add(tblData, 0, 5);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 6;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 300F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.Size = new Size(1040, 576);
            tblMain.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.Location = new Point(3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 42);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.AutoSize = true;
            btnDelete.Location = new Point(211, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 42);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // lblCookbookName
            // 
            lblCookbookName.AutoSize = true;
            lblCookbookName.Dock = DockStyle.Fill;
            lblCookbookName.Location = new Point(3, 48);
            lblCookbookName.Name = "lblCookbookName";
            lblCookbookName.Size = new Size(202, 55);
            lblCookbookName.TabIndex = 2;
            lblCookbookName.Text = "Cookbook Name";
            lblCookbookName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtCookbookName
            // 
            txtCookbookName.Dock = DockStyle.Fill;
            txtCookbookName.Location = new Point(211, 51);
            txtCookbookName.Multiline = true;
            txtCookbookName.Name = "txtCookbookName";
            txtCookbookName.Size = new Size(826, 49);
            txtCookbookName.TabIndex = 3;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Dock = DockStyle.Fill;
            lblUser.Location = new Point(3, 103);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(202, 46);
            lblUser.TabIndex = 4;
            lblUser.Text = "User";
            lblUser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lstUsers
            // 
            lstUsers.Dock = DockStyle.Fill;
            lstUsers.FormattingEnabled = true;
            lstUsers.Location = new Point(211, 106);
            lstUsers.Name = "lstUsers";
            lstUsers.Size = new Size(826, 40);
            lstUsers.TabIndex = 5;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Dock = DockStyle.Fill;
            lblPrice.Location = new Point(3, 149);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(202, 55);
            lblPrice.TabIndex = 6;
            lblPrice.Text = "Price";
            lblPrice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblActive
            // 
            lblActive.AutoSize = true;
            lblActive.Dock = DockStyle.Fill;
            lblActive.Location = new Point(3, 204);
            lblActive.Name = "lblActive";
            lblActive.Size = new Size(202, 32);
            lblActive.TabIndex = 7;
            lblActive.Text = "Active";
            lblActive.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblPrice
            // 
            tblPrice.ColumnCount = 2;
            tblPrice.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblPrice.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblPrice.Controls.Add(lblDateCreated, 1, 0);
            tblPrice.Controls.Add(txtPrice, 0, 0);
            tblPrice.Controls.Add(txtDateCreated, 1, 1);
            tblPrice.Dock = DockStyle.Fill;
            tblPrice.Location = new Point(211, 152);
            tblPrice.Name = "tblPrice";
            tblPrice.RowCount = 2;
            tblPrice.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblPrice.RowStyles.Add(new RowStyle(SizeType.Absolute, 71F));
            tblPrice.Size = new Size(826, 49);
            tblPrice.TabIndex = 8;
            // 
            // lblDateCreated
            // 
            lblDateCreated.AutoSize = true;
            lblDateCreated.Dock = DockStyle.Fill;
            lblDateCreated.Location = new Point(416, 0);
            lblDateCreated.Name = "lblDateCreated";
            lblDateCreated.Size = new Size(407, 1);
            lblDateCreated.TabIndex = 0;
            lblDateCreated.Text = "Date Created";
            lblDateCreated.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtPrice
            // 
            txtPrice.Dock = DockStyle.Fill;
            txtPrice.Location = new Point(3, 3);
            txtPrice.Multiline = true;
            txtPrice.Name = "txtPrice";
            tblPrice.SetRowSpan(txtPrice, 2);
            txtPrice.Size = new Size(407, 43);
            txtPrice.TabIndex = 1;
            // 
            // txtDateCreated
            // 
            txtDateCreated.Dock = DockStyle.Fill;
            txtDateCreated.Location = new Point(416, -19);
            txtDateCreated.Multiline = true;
            txtDateCreated.Name = "txtDateCreated";
            txtDateCreated.Size = new Size(407, 65);
            txtDateCreated.TabIndex = 2;
            // 
            // ckActive
            // 
            ckActive.AutoSize = true;
            ckActive.Dock = DockStyle.Fill;
            ckActive.Location = new Point(211, 207);
            ckActive.Name = "ckActive";
            ckActive.Size = new Size(826, 26);
            ckActive.TabIndex = 9;
            ckActive.UseVisualStyleBackColor = true;
            // 
            // tblData
            // 
            tblData.ColumnCount = 1;
            tblMain.SetColumnSpan(tblData, 2);
            tblData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblData.Controls.Add(gData, 0, 1);
            tblData.Controls.Add(btnSaveRecipe, 0, 0);
            tblData.Dock = DockStyle.Fill;
            tblData.Location = new Point(3, 239);
            tblData.Name = "tblData";
            tblData.RowCount = 2;
            tblData.RowStyles.Add(new RowStyle());
            tblData.RowStyles.Add(new RowStyle(SizeType.Percent, 81.1377258F));
            tblData.Size = new Size(1034, 334);
            tblData.TabIndex = 10;
            // 
            // gData
            // 
            gData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gData.Dock = DockStyle.Fill;
            gData.Location = new Point(3, 51);
            gData.Name = "gData";
            gData.RowHeadersWidth = 62;
            gData.Size = new Size(1028, 280);
            gData.TabIndex = 0;
            // 
            // btnSaveRecipe
            // 
            btnSaveRecipe.AutoSize = true;
            btnSaveRecipe.Location = new Point(3, 3);
            btnSaveRecipe.Name = "btnSaveRecipe";
            btnSaveRecipe.Size = new Size(112, 42);
            btnSaveRecipe.TabIndex = 1;
            btnSaveRecipe.Text = "Save";
            btnSaveRecipe.UseVisualStyleBackColor = true;
            // 
            // frmNewCookbook
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 576);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "frmNewCookbook";
            Text = "Cookbook";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblPrice.ResumeLayout(false);
            tblPrice.PerformLayout();
            tblData.ResumeLayout(false);
            tblData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Button btnSave;
        private Button btnDelete;
        private Label lblCookbookName;
        private TextBox txtCookbookName;
        private Label lblUser;
        private ComboBox lstUsers;
        private Label lblPrice;
        private Label lblActive;
        private TableLayoutPanel tblPrice;
        private Label lblDateCreated;
        private TextBox txtPrice;
        private TextBox txtDateCreated;
        private CheckBox ckActive;
        private TableLayoutPanel tblData;
        private DataGridView gData;
        private Button btnSaveRecipe;
    }
}