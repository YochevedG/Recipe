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
            lblCaptionUser = new Label();
            lblCaptionDateDrafted = new Label();
            lblCaptionDatePublished = new Label();
            lblCaptionDateArchived = new Label();
            lblCaptionCalories = new Label();
            lblCaptionCurrentStatus = new Label();
            lblCaptionRecipePic = new Label();
            txtDraftedDate = new TextBox();
            txtPublishedDate = new TextBox();
            txtArchivedDate = new TextBox();
            txtCalories = new TextBox();
            txtCurrentStatus = new TextBox();
            txtRecipePic = new TextBox();
            tblToolbar = new TableLayoutPanel();
            btnSave = new Button();
            btnDelete = new Button();
            btnChangeStatus = new Button();
            lblCaptionRecipeName = new Label();
            lblCaptionCuisine = new Label();
            lstCuisine = new ComboBox();
            tbChildRecords = new TabControl();
            tbIngredients = new TabPage();
            tblIngredients = new TableLayoutPanel();
            btnSaveIngredient = new Button();
            gIngredient = new DataGridView();
            tbSteps = new TabPage();
            tblSteps = new TableLayoutPanel();
            btnSaveSteps = new Button();
            gSteps = new DataGridView();
            txtRecipeName = new TextBox();
            lstUsers = new ComboBox();
            tblMain.SuspendLayout();
            tblToolbar.SuspendLayout();
            tbChildRecords.SuspendLayout();
            tbIngredients.SuspendLayout();
            tblIngredients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gIngredient).BeginInit();
            tbSteps.SuspendLayout();
            tblSteps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gSteps).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.86817F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80.13183F));
            tblMain.Controls.Add(lblCaptionUser, 0, 3);
            tblMain.Controls.Add(lblCaptionDateDrafted, 0, 4);
            tblMain.Controls.Add(lblCaptionDatePublished, 0, 5);
            tblMain.Controls.Add(lblCaptionDateArchived, 0, 6);
            tblMain.Controls.Add(lblCaptionCalories, 0, 7);
            tblMain.Controls.Add(lblCaptionCurrentStatus, 0, 8);
            tblMain.Controls.Add(lblCaptionRecipePic, 0, 9);
            tblMain.Controls.Add(txtDraftedDate, 1, 4);
            tblMain.Controls.Add(txtPublishedDate, 1, 5);
            tblMain.Controls.Add(txtArchivedDate, 1, 6);
            tblMain.Controls.Add(txtCalories, 1, 7);
            tblMain.Controls.Add(txtCurrentStatus, 1, 8);
            tblMain.Controls.Add(txtRecipePic, 1, 9);
            tblMain.Controls.Add(tblToolbar, 0, 0);
            tblMain.Controls.Add(lblCaptionRecipeName, 0, 1);
            tblMain.Controls.Add(lblCaptionCuisine, 0, 2);
            tblMain.Controls.Add(lstCuisine, 1, 2);
            tblMain.Controls.Add(tbChildRecords, 0, 10);
            tblMain.Controls.Add(txtRecipeName, 1, 1);
            tblMain.Controls.Add(lstUsers, 1, 3);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Margin = new Padding(4);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 11;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 300F));
            tblMain.Size = new Size(1028, 685);
            tblMain.TabIndex = 0;
            // 
            // lblCaptionUser
            // 
            lblCaptionUser.AutoSize = true;
            lblCaptionUser.Dock = DockStyle.Fill;
            lblCaptionUser.Location = new Point(4, 151);
            lblCaptionUser.Margin = new Padding(4, 0, 4, 0);
            lblCaptionUser.Name = "lblCaptionUser";
            lblCaptionUser.Size = new Size(196, 46);
            lblCaptionUser.TabIndex = 0;
            lblCaptionUser.Text = "User";
            // 
            // lblCaptionDateDrafted
            // 
            lblCaptionDateDrafted.AutoSize = true;
            lblCaptionDateDrafted.Dock = DockStyle.Fill;
            lblCaptionDateDrafted.Location = new Point(4, 197);
            lblCaptionDateDrafted.Margin = new Padding(4, 0, 4, 0);
            lblCaptionDateDrafted.Name = "lblCaptionDateDrafted";
            lblCaptionDateDrafted.Size = new Size(196, 60);
            lblCaptionDateDrafted.TabIndex = 1;
            lblCaptionDateDrafted.Text = "Date Drafted";
            // 
            // lblCaptionDatePublished
            // 
            lblCaptionDatePublished.AutoSize = true;
            lblCaptionDatePublished.Dock = DockStyle.Fill;
            lblCaptionDatePublished.Location = new Point(4, 257);
            lblCaptionDatePublished.Margin = new Padding(4, 0, 4, 0);
            lblCaptionDatePublished.Name = "lblCaptionDatePublished";
            lblCaptionDatePublished.Size = new Size(196, 60);
            lblCaptionDatePublished.TabIndex = 2;
            lblCaptionDatePublished.Text = "Date Published";
            // 
            // lblCaptionDateArchived
            // 
            lblCaptionDateArchived.AutoSize = true;
            lblCaptionDateArchived.Dock = DockStyle.Fill;
            lblCaptionDateArchived.Location = new Point(4, 317);
            lblCaptionDateArchived.Margin = new Padding(4, 0, 4, 0);
            lblCaptionDateArchived.Name = "lblCaptionDateArchived";
            lblCaptionDateArchived.Size = new Size(196, 60);
            lblCaptionDateArchived.TabIndex = 3;
            lblCaptionDateArchived.Text = "Date Archived";
            // 
            // lblCaptionCalories
            // 
            lblCaptionCalories.AutoSize = true;
            lblCaptionCalories.Dock = DockStyle.Fill;
            lblCaptionCalories.Location = new Point(4, 377);
            lblCaptionCalories.Margin = new Padding(4, 0, 4, 0);
            lblCaptionCalories.Name = "lblCaptionCalories";
            lblCaptionCalories.Size = new Size(196, 60);
            lblCaptionCalories.TabIndex = 4;
            lblCaptionCalories.Text = "Calories";
            // 
            // lblCaptionCurrentStatus
            // 
            lblCaptionCurrentStatus.AutoSize = true;
            lblCaptionCurrentStatus.Dock = DockStyle.Fill;
            lblCaptionCurrentStatus.Location = new Point(4, 437);
            lblCaptionCurrentStatus.Margin = new Padding(4, 0, 4, 0);
            lblCaptionCurrentStatus.Name = "lblCaptionCurrentStatus";
            lblCaptionCurrentStatus.Size = new Size(196, 60);
            lblCaptionCurrentStatus.TabIndex = 5;
            lblCaptionCurrentStatus.Text = "Current Status";
            // 
            // lblCaptionRecipePic
            // 
            lblCaptionRecipePic.AutoSize = true;
            lblCaptionRecipePic.Dock = DockStyle.Fill;
            lblCaptionRecipePic.Location = new Point(4, 497);
            lblCaptionRecipePic.Margin = new Padding(4, 0, 4, 0);
            lblCaptionRecipePic.Name = "lblCaptionRecipePic";
            lblCaptionRecipePic.Size = new Size(196, 55);
            lblCaptionRecipePic.TabIndex = 6;
            lblCaptionRecipePic.Text = "Recipe Picture";
            // 
            // txtDraftedDate
            // 
            txtDraftedDate.Dock = DockStyle.Fill;
            txtDraftedDate.Location = new Point(208, 201);
            txtDraftedDate.Margin = new Padding(4);
            txtDraftedDate.Multiline = true;
            txtDraftedDate.Name = "txtDraftedDate";
            txtDraftedDate.ReadOnly = true;
            txtDraftedDate.Size = new Size(816, 52);
            txtDraftedDate.TabIndex = 8;
            // 
            // txtPublishedDate
            // 
            txtPublishedDate.Dock = DockStyle.Fill;
            txtPublishedDate.Location = new Point(208, 261);
            txtPublishedDate.Margin = new Padding(4);
            txtPublishedDate.Multiline = true;
            txtPublishedDate.Name = "txtPublishedDate";
            txtPublishedDate.ReadOnly = true;
            txtPublishedDate.Size = new Size(816, 52);
            txtPublishedDate.TabIndex = 9;
            // 
            // txtArchivedDate
            // 
            txtArchivedDate.Dock = DockStyle.Fill;
            txtArchivedDate.Location = new Point(208, 321);
            txtArchivedDate.Margin = new Padding(4);
            txtArchivedDate.Multiline = true;
            txtArchivedDate.Name = "txtArchivedDate";
            txtArchivedDate.ReadOnly = true;
            txtArchivedDate.Size = new Size(816, 52);
            txtArchivedDate.TabIndex = 10;
            // 
            // txtCalories
            // 
            txtCalories.Dock = DockStyle.Fill;
            txtCalories.Location = new Point(208, 381);
            txtCalories.Margin = new Padding(4);
            txtCalories.Multiline = true;
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(816, 52);
            txtCalories.TabIndex = 11;
            // 
            // txtCurrentStatus
            // 
            txtCurrentStatus.Dock = DockStyle.Fill;
            txtCurrentStatus.Location = new Point(208, 441);
            txtCurrentStatus.Margin = new Padding(4);
            txtCurrentStatus.Multiline = true;
            txtCurrentStatus.Name = "txtCurrentStatus";
            txtCurrentStatus.Size = new Size(816, 52);
            txtCurrentStatus.TabIndex = 12;
            // 
            // txtRecipePic
            // 
            txtRecipePic.Dock = DockStyle.Fill;
            txtRecipePic.Location = new Point(208, 501);
            txtRecipePic.Margin = new Padding(4);
            txtRecipePic.Multiline = true;
            txtRecipePic.Name = "txtRecipePic";
            txtRecipePic.Size = new Size(816, 47);
            txtRecipePic.TabIndex = 13;
            // 
            // tblToolbar
            // 
            tblToolbar.ColumnCount = 3;
            tblMain.SetColumnSpan(tblToolbar, 2);
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblToolbar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 282F));
            tblToolbar.Controls.Add(btnSave, 0, 0);
            tblToolbar.Controls.Add(btnDelete, 1, 0);
            tblToolbar.Controls.Add(btnChangeStatus, 2, 0);
            tblToolbar.Dock = DockStyle.Fill;
            tblToolbar.Location = new Point(3, 3);
            tblToolbar.Name = "tblToolbar";
            tblToolbar.RowCount = 1;
            tblToolbar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblToolbar.Size = new Size(1022, 54);
            tblToolbar.TabIndex = 14;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Fill;
            btnSave.Location = new Point(3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(364, 48);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.Location = new Point(373, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(364, 48);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnChangeStatus
            // 
            btnChangeStatus.AutoSize = true;
            btnChangeStatus.Dock = DockStyle.Fill;
            btnChangeStatus.Location = new Point(743, 3);
            btnChangeStatus.Name = "btnChangeStatus";
            btnChangeStatus.Size = new Size(276, 48);
            btnChangeStatus.TabIndex = 2;
            btnChangeStatus.Text = "Change Status";
            btnChangeStatus.UseVisualStyleBackColor = true;
            // 
            // lblCaptionRecipeName
            // 
            lblCaptionRecipeName.AutoSize = true;
            lblCaptionRecipeName.Dock = DockStyle.Fill;
            lblCaptionRecipeName.Location = new Point(3, 60);
            lblCaptionRecipeName.Name = "lblCaptionRecipeName";
            lblCaptionRecipeName.Size = new Size(198, 45);
            lblCaptionRecipeName.TabIndex = 15;
            lblCaptionRecipeName.Text = "Recipe Name";
            // 
            // lblCaptionCuisine
            // 
            lblCaptionCuisine.AutoSize = true;
            lblCaptionCuisine.Dock = DockStyle.Fill;
            lblCaptionCuisine.Location = new Point(3, 105);
            lblCaptionCuisine.Name = "lblCaptionCuisine";
            lblCaptionCuisine.Size = new Size(198, 46);
            lblCaptionCuisine.TabIndex = 16;
            lblCaptionCuisine.Text = "Cuisine";
            // 
            // lstCuisine
            // 
            lstCuisine.Dock = DockStyle.Fill;
            lstCuisine.FormattingEnabled = true;
            lstCuisine.Location = new Point(207, 108);
            lstCuisine.Name = "lstCuisine";
            lstCuisine.Size = new Size(818, 40);
            lstCuisine.TabIndex = 18;
            // 
            // tbChildRecords
            // 
            tblMain.SetColumnSpan(tbChildRecords, 2);
            tbChildRecords.Controls.Add(tbIngredients);
            tbChildRecords.Controls.Add(tbSteps);
            tbChildRecords.Dock = DockStyle.Fill;
            tbChildRecords.Location = new Point(3, 555);
            tbChildRecords.Name = "tbChildRecords";
            tbChildRecords.SelectedIndex = 0;
            tbChildRecords.Size = new Size(1022, 294);
            tbChildRecords.TabIndex = 20;
            // 
            // tbIngredients
            // 
            tbIngredients.Controls.Add(tblIngredients);
            tbIngredients.Location = new Point(4, 41);
            tbIngredients.Name = "tbIngredients";
            tbIngredients.Padding = new Padding(3);
            tbIngredients.Size = new Size(1014, 249);
            tbIngredients.TabIndex = 0;
            tbIngredients.Text = "Ingredients";
            tbIngredients.UseVisualStyleBackColor = true;
            // 
            // tblIngredients
            // 
            tblIngredients.ColumnCount = 1;
            tblIngredients.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblIngredients.Controls.Add(btnSaveIngredient, 0, 0);
            tblIngredients.Controls.Add(gIngredient, 0, 1);
            tblIngredients.Dock = DockStyle.Fill;
            tblIngredients.Location = new Point(3, 3);
            tblIngredients.Name = "tblIngredients";
            tblIngredients.RowCount = 2;
            tblIngredients.RowStyles.Add(new RowStyle());
            tblIngredients.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblIngredients.Size = new Size(1008, 243);
            tblIngredients.TabIndex = 0;
            // 
            // btnSaveIngredient
            // 
            btnSaveIngredient.AutoSize = true;
            btnSaveIngredient.Location = new Point(3, 3);
            btnSaveIngredient.Name = "btnSaveIngredient";
            btnSaveIngredient.Size = new Size(112, 42);
            btnSaveIngredient.TabIndex = 0;
            btnSaveIngredient.Text = "Save";
            btnSaveIngredient.UseVisualStyleBackColor = true;
            // 
            // gIngredient
            // 
            gIngredient.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gIngredient.Dock = DockStyle.Fill;
            gIngredient.Location = new Point(3, 51);
            gIngredient.Name = "gIngredient";
            gIngredient.RowHeadersWidth = 62;
            gIngredient.Size = new Size(1002, 189);
            gIngredient.TabIndex = 1;
            // 
            // tbSteps
            // 
            tbSteps.Controls.Add(tblSteps);
            tbSteps.Location = new Point(4, 34);
            tbSteps.Name = "tbSteps";
            tbSteps.Padding = new Padding(3);
            tbSteps.Size = new Size(985, 155);
            tbSteps.TabIndex = 1;
            tbSteps.Text = "Steps";
            tbSteps.UseVisualStyleBackColor = true;
            // 
            // tblSteps
            // 
            tblSteps.ColumnCount = 1;
            tblSteps.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblSteps.Controls.Add(btnSaveSteps, 0, 0);
            tblSteps.Controls.Add(gSteps, 0, 1);
            tblSteps.Dock = DockStyle.Fill;
            tblSteps.Location = new Point(3, 3);
            tblSteps.Name = "tblSteps";
            tblSteps.RowCount = 2;
            tblSteps.RowStyles.Add(new RowStyle());
            tblSteps.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblSteps.Size = new Size(979, 149);
            tblSteps.TabIndex = 0;
            // 
            // btnSaveSteps
            // 
            btnSaveSteps.AutoSize = true;
            btnSaveSteps.Location = new Point(3, 3);
            btnSaveSteps.Name = "btnSaveSteps";
            btnSaveSteps.Size = new Size(112, 42);
            btnSaveSteps.TabIndex = 0;
            btnSaveSteps.Text = "Save";
            btnSaveSteps.UseVisualStyleBackColor = true;
            // 
            // gSteps
            // 
            gSteps.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gSteps.Dock = DockStyle.Fill;
            gSteps.Location = new Point(3, 51);
            gSteps.Name = "gSteps";
            gSteps.RowHeadersWidth = 62;
            gSteps.Size = new Size(973, 95);
            gSteps.TabIndex = 1;
            // 
            // txtRecipeName
            // 
            txtRecipeName.Dock = DockStyle.Fill;
            txtRecipeName.Location = new Point(207, 63);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(818, 39);
            txtRecipeName.TabIndex = 21;
            // 
            // lstUsers
            // 
            lstUsers.Dock = DockStyle.Fill;
            lstUsers.FormattingEnabled = true;
            lstUsers.Location = new Point(207, 154);
            lstUsers.Name = "lstUsers";
            lstUsers.Size = new Size(818, 40);
            lstUsers.TabIndex = 22;
            // 
            // frmRecipe
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1028, 685);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "frmRecipe";
            Text = "Recipe";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblToolbar.ResumeLayout(false);
            tblToolbar.PerformLayout();
            tbChildRecords.ResumeLayout(false);
            tbIngredients.ResumeLayout(false);
            tblIngredients.ResumeLayout(false);
            tblIngredients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gIngredient).EndInit();
            tbSteps.ResumeLayout(false);
            tblSteps.ResumeLayout(false);
            tblSteps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gSteps).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblCaptionUser;
        private Label lblCaptionDateDrafted;
        private Label lblCaptionDatePublished;
        private Label lblCaptionDateArchived;
        private Label lblCaptionCalories;
        private Label lblCaptionCurrentStatus;
        private Label lblCaptionRecipePic;
        private TextBox txtDraftedDate;
        private TextBox txtPublishedDate;
        private TextBox txtArchivedDate;
        private TextBox txtCalories;
        private TextBox txtCurrentStatus;
        private TextBox txtRecipePic;
        private TableLayoutPanel tblToolbar;
        private Button btnSave;
        private Button btnDelete;
        private Label lblCaptionRecipeName;
        private Label lblCaptionCuisine;
        private ComboBox lstCuisine;
        private Button btnChangeStatus;
        private TabControl tbChildRecords;
        private TabPage tbIngredients;
        private TableLayoutPanel tblIngredients;
        private Button btnSaveIngredient;
        private DataGridView gIngredient;
        private TabPage tbSteps;
        private TableLayoutPanel tblSteps;
        private Button btnSaveSteps;
        private DataGridView gSteps;
        private TextBox txtRecipeName;
        private ComboBox lstUsers;
    }
}