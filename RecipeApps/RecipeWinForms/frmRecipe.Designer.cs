namespace RecipeWinForms
{
    partial class frmRecipe
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
            lblCaptionRecipeName = new Label();
            lblCaptionDateDrafted = new Label();
            lblCaptionDatePublished = new Label();
            lblCaptionDateArchived = new Label();
            lblCaptionCalories = new Label();
            lblCaptionCurrentStatus = new Label();
            lblCaptionRecipePic = new Label();
            txtRecipeName = new TextBox();
            txtDraftedDate = new TextBox();
            txtPublishedDate = new TextBox();
            txtArchivedDate = new TextBox();
            txtCalories = new TextBox();
            txtCurrentStatus = new TextBox();
            txtRecipePic = new TextBox();
            tblToolbar = new TableLayoutPanel();
            btnSave = new Button();
            btnDelete = new Button();
            lblCaptionUser = new Label();
            lblCaptionCuisine = new Label();
            lstUser = new ComboBox();
            lstCuisine = new ComboBox();
            tblMain.SuspendLayout();
            tblToolbar.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tblMain.Controls.Add(lblCaptionRecipeName, 0, 3);
            tblMain.Controls.Add(lblCaptionDateDrafted, 0, 4);
            tblMain.Controls.Add(lblCaptionDatePublished, 0, 5);
            tblMain.Controls.Add(lblCaptionDateArchived, 0, 6);
            tblMain.Controls.Add(lblCaptionCalories, 0, 7);
            tblMain.Controls.Add(lblCaptionCurrentStatus, 0, 8);
            tblMain.Controls.Add(lblCaptionRecipePic, 0, 9);
            tblMain.Controls.Add(txtRecipeName, 1, 3);
            tblMain.Controls.Add(txtDraftedDate, 1, 4);
            tblMain.Controls.Add(txtPublishedDate, 1, 5);
            tblMain.Controls.Add(txtArchivedDate, 1, 6);
            tblMain.Controls.Add(txtCalories, 1, 7);
            tblMain.Controls.Add(txtCurrentStatus, 1, 8);
            tblMain.Controls.Add(txtRecipePic, 1, 9);
            tblMain.Controls.Add(tblToolbar, 0, 0);
            tblMain.Controls.Add(lblCaptionUser, 0, 1);
            tblMain.Controls.Add(lblCaptionCuisine, 0, 2);
            tblMain.Controls.Add(lstUser, 1, 1);
            tblMain.Controls.Add(lstCuisine, 1, 2);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Margin = new Padding(4);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 10;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tblMain.Size = new Size(899, 553);
            tblMain.TabIndex = 0;
            // 
            // lblCaptionRecipeName
            // 
            lblCaptionRecipeName.AutoSize = true;
            lblCaptionRecipeName.Dock = DockStyle.Fill;
            lblCaptionRecipeName.Location = new Point(4, 165);
            lblCaptionRecipeName.Margin = new Padding(4, 0, 4, 0);
            lblCaptionRecipeName.Name = "lblCaptionRecipeName";
            lblCaptionRecipeName.Size = new Size(171, 55);
            lblCaptionRecipeName.TabIndex = 0;
            lblCaptionRecipeName.Text = "Recipe Name";
            // 
            // lblCaptionDateDrafted
            // 
            lblCaptionDateDrafted.AutoSize = true;
            lblCaptionDateDrafted.Dock = DockStyle.Fill;
            lblCaptionDateDrafted.Location = new Point(4, 220);
            lblCaptionDateDrafted.Margin = new Padding(4, 0, 4, 0);
            lblCaptionDateDrafted.Name = "lblCaptionDateDrafted";
            lblCaptionDateDrafted.Size = new Size(171, 55);
            lblCaptionDateDrafted.TabIndex = 1;
            lblCaptionDateDrafted.Text = "Date Drafted";
            // 
            // lblCaptionDatePublished
            // 
            lblCaptionDatePublished.AutoSize = true;
            lblCaptionDatePublished.Dock = DockStyle.Fill;
            lblCaptionDatePublished.Location = new Point(4, 275);
            lblCaptionDatePublished.Margin = new Padding(4, 0, 4, 0);
            lblCaptionDatePublished.Name = "lblCaptionDatePublished";
            lblCaptionDatePublished.Size = new Size(171, 55);
            lblCaptionDatePublished.TabIndex = 2;
            lblCaptionDatePublished.Text = "Date Published";
            // 
            // lblCaptionDateArchived
            // 
            lblCaptionDateArchived.AutoSize = true;
            lblCaptionDateArchived.Dock = DockStyle.Fill;
            lblCaptionDateArchived.Location = new Point(4, 330);
            lblCaptionDateArchived.Margin = new Padding(4, 0, 4, 0);
            lblCaptionDateArchived.Name = "lblCaptionDateArchived";
            lblCaptionDateArchived.Size = new Size(171, 55);
            lblCaptionDateArchived.TabIndex = 3;
            lblCaptionDateArchived.Text = "Date Archived";
            // 
            // lblCaptionCalories
            // 
            lblCaptionCalories.AutoSize = true;
            lblCaptionCalories.Dock = DockStyle.Fill;
            lblCaptionCalories.Location = new Point(4, 385);
            lblCaptionCalories.Margin = new Padding(4, 0, 4, 0);
            lblCaptionCalories.Name = "lblCaptionCalories";
            lblCaptionCalories.Size = new Size(171, 55);
            lblCaptionCalories.TabIndex = 4;
            lblCaptionCalories.Text = "Calories";
            // 
            // lblCaptionCurrentStatus
            // 
            lblCaptionCurrentStatus.AutoSize = true;
            lblCaptionCurrentStatus.Dock = DockStyle.Fill;
            lblCaptionCurrentStatus.Location = new Point(4, 440);
            lblCaptionCurrentStatus.Margin = new Padding(4, 0, 4, 0);
            lblCaptionCurrentStatus.Name = "lblCaptionCurrentStatus";
            lblCaptionCurrentStatus.Size = new Size(171, 55);
            lblCaptionCurrentStatus.TabIndex = 5;
            lblCaptionCurrentStatus.Text = "Current Status";
            // 
            // lblCaptionRecipePic
            // 
            lblCaptionRecipePic.AutoSize = true;
            lblCaptionRecipePic.Dock = DockStyle.Fill;
            lblCaptionRecipePic.Location = new Point(4, 495);
            lblCaptionRecipePic.Margin = new Padding(4, 0, 4, 0);
            lblCaptionRecipePic.Name = "lblCaptionRecipePic";
            lblCaptionRecipePic.Size = new Size(171, 58);
            lblCaptionRecipePic.TabIndex = 6;
            lblCaptionRecipePic.Text = "Recipe Picture";
            // 
            // txtRecipeName
            // 
            txtRecipeName.Dock = DockStyle.Fill;
            txtRecipeName.Location = new Point(183, 169);
            txtRecipeName.Margin = new Padding(4);
            txtRecipeName.Multiline = true;
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(712, 47);
            txtRecipeName.TabIndex = 7;
            // 
            // txtDraftedDate
            // 
            txtDraftedDate.Dock = DockStyle.Fill;
            txtDraftedDate.Location = new Point(183, 224);
            txtDraftedDate.Margin = new Padding(4);
            txtDraftedDate.Multiline = true;
            txtDraftedDate.Name = "txtDraftedDate";
            txtDraftedDate.Size = new Size(712, 47);
            txtDraftedDate.TabIndex = 8;
            // 
            // txtPublishedDate
            // 
            txtPublishedDate.Dock = DockStyle.Fill;
            txtPublishedDate.Location = new Point(183, 279);
            txtPublishedDate.Margin = new Padding(4);
            txtPublishedDate.Multiline = true;
            txtPublishedDate.Name = "txtPublishedDate";
            txtPublishedDate.Size = new Size(712, 47);
            txtPublishedDate.TabIndex = 9;
            // 
            // txtArchivedDate
            // 
            txtArchivedDate.Dock = DockStyle.Fill;
            txtArchivedDate.Location = new Point(183, 334);
            txtArchivedDate.Margin = new Padding(4);
            txtArchivedDate.Multiline = true;
            txtArchivedDate.Name = "txtArchivedDate";
            txtArchivedDate.Size = new Size(712, 47);
            txtArchivedDate.TabIndex = 10;
            // 
            // txtCalories
            // 
            txtCalories.Dock = DockStyle.Fill;
            txtCalories.Location = new Point(183, 389);
            txtCalories.Margin = new Padding(4);
            txtCalories.Multiline = true;
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(712, 47);
            txtCalories.TabIndex = 11;
            // 
            // txtCurrentStatus
            // 
            txtCurrentStatus.Dock = DockStyle.Fill;
            txtCurrentStatus.Location = new Point(183, 444);
            txtCurrentStatus.Margin = new Padding(4);
            txtCurrentStatus.Multiline = true;
            txtCurrentStatus.Name = "txtCurrentStatus";
            txtCurrentStatus.Size = new Size(712, 47);
            txtCurrentStatus.TabIndex = 12;
            // 
            // txtRecipePic
            // 
            txtRecipePic.Dock = DockStyle.Fill;
            txtRecipePic.Location = new Point(183, 499);
            txtRecipePic.Margin = new Padding(4);
            txtRecipePic.Multiline = true;
            txtRecipePic.Name = "txtRecipePic";
            txtRecipePic.Size = new Size(712, 50);
            txtRecipePic.TabIndex = 13;
            // 
            // tblToolbar
            // 
            tblToolbar.ColumnCount = 2;
            tblMain.SetColumnSpan(tblToolbar, 2);
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tblToolbar.Controls.Add(btnSave, 0, 0);
            tblToolbar.Controls.Add(btnDelete, 1, 0);
            tblToolbar.Dock = DockStyle.Fill;
            tblToolbar.Location = new Point(3, 3);
            tblToolbar.Name = "tblToolbar";
            tblToolbar.RowCount = 1;
            tblToolbar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblToolbar.Size = new Size(893, 49);
            tblToolbar.TabIndex = 14;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Fill;
            btnSave.Location = new Point(3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(440, 43);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.Location = new Point(449, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(441, 43);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // lblCaptionUser
            // 
            lblCaptionUser.AutoSize = true;
            lblCaptionUser.Dock = DockStyle.Fill;
            lblCaptionUser.Location = new Point(3, 55);
            lblCaptionUser.Name = "lblCaptionUser";
            lblCaptionUser.Size = new Size(173, 55);
            lblCaptionUser.TabIndex = 15;
            lblCaptionUser.Text = "User";
            // 
            // lblCaptionCuisine
            // 
            lblCaptionCuisine.AutoSize = true;
            lblCaptionCuisine.Dock = DockStyle.Fill;
            lblCaptionCuisine.Location = new Point(3, 110);
            lblCaptionCuisine.Name = "lblCaptionCuisine";
            lblCaptionCuisine.Size = new Size(173, 55);
            lblCaptionCuisine.TabIndex = 16;
            lblCaptionCuisine.Text = "Cuisine";
            // 
            // lstUser
            // 
            lstUser.Dock = DockStyle.Fill;
            lstUser.FormattingEnabled = true;
            lstUser.Location = new Point(182, 58);
            lstUser.Name = "lstUser";
            lstUser.Size = new Size(714, 40);
            lstUser.TabIndex = 17;
            // 
            // lstCuisine
            // 
            lstCuisine.Dock = DockStyle.Fill;
            lstCuisine.FormattingEnabled = true;
            lstCuisine.Location = new Point(182, 113);
            lstCuisine.Name = "lstCuisine";
            lstCuisine.Size = new Size(714, 40);
            lstCuisine.TabIndex = 18;
            // 
            // frmRecipe
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(899, 553);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "frmRecipe";
            Text = "Recipe";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblToolbar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblCaptionRecipeName;
        private Label lblCaptionDateDrafted;
        private Label lblCaptionDatePublished;
        private Label lblCaptionDateArchived;
        private Label lblCaptionCalories;
        private Label lblCaptionCurrentStatus;
        private Label lblCaptionRecipePic;
        private TextBox txtRecipeName;
        private TextBox txtDraftedDate;
        private TextBox txtPublishedDate;
        private TextBox txtArchivedDate;
        private TextBox txtCalories;
        private TextBox txtCurrentStatus;
        private TextBox txtRecipePic;
        private TableLayoutPanel tblToolbar;
        private Button btnSave;
        private Button btnDelete;
        private Label lblCaptionUser;
        private Label lblCaptionCuisine;
        private ComboBox lstUser;
        private ComboBox lstCuisine;
    }
}