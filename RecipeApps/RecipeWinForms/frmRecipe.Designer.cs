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
            txtDateDrafted = new TextBox();
            txtDatePublished = new TextBox();
            txtDateArchived = new TextBox();
            txtCalories = new TextBox();
            txtCurrentStatus = new TextBox();
            txtRecipePic = new TextBox();
            tblMain.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tblMain.Controls.Add(lblCaptionRecipeName, 0, 0);
            tblMain.Controls.Add(lblCaptionDateDrafted, 0, 1);
            tblMain.Controls.Add(lblCaptionDatePublished, 0, 2);
            tblMain.Controls.Add(lblCaptionDateArchived, 0, 3);
            tblMain.Controls.Add(lblCaptionCalories, 0, 4);
            tblMain.Controls.Add(lblCaptionCurrentStatus, 0, 5);
            tblMain.Controls.Add(lblCaptionRecipePic, 0, 6);
            tblMain.Controls.Add(txtRecipeName, 1, 0);
            tblMain.Controls.Add(txtDateDrafted, 1, 1);
            tblMain.Controls.Add(txtDatePublished, 1, 2);
            tblMain.Controls.Add(txtDateArchived, 1, 3);
            tblMain.Controls.Add(txtCalories, 1, 4);
            tblMain.Controls.Add(txtCurrentStatus, 1, 5);
            tblMain.Controls.Add(txtRecipePic, 1, 6);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Margin = new Padding(4);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 7;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tblMain.Size = new Size(899, 553);
            tblMain.TabIndex = 0;
            // 
            // lblCaptionRecipeName
            // 
            lblCaptionRecipeName.AutoSize = true;
            lblCaptionRecipeName.Dock = DockStyle.Fill;
            lblCaptionRecipeName.Location = new Point(4, 0);
            lblCaptionRecipeName.Margin = new Padding(4, 0, 4, 0);
            lblCaptionRecipeName.Name = "lblCaptionRecipeName";
            lblCaptionRecipeName.Size = new Size(171, 79);
            lblCaptionRecipeName.TabIndex = 0;
            lblCaptionRecipeName.Text = "Recipe Name";
            // 
            // lblCaptionDateDrafted
            // 
            lblCaptionDateDrafted.AutoSize = true;
            lblCaptionDateDrafted.Dock = DockStyle.Fill;
            lblCaptionDateDrafted.Location = new Point(4, 79);
            lblCaptionDateDrafted.Margin = new Padding(4, 0, 4, 0);
            lblCaptionDateDrafted.Name = "lblCaptionDateDrafted";
            lblCaptionDateDrafted.Size = new Size(171, 79);
            lblCaptionDateDrafted.TabIndex = 1;
            lblCaptionDateDrafted.Text = "Date Drafted";
            // 
            // lblCaptionDatePublished
            // 
            lblCaptionDatePublished.AutoSize = true;
            lblCaptionDatePublished.Dock = DockStyle.Fill;
            lblCaptionDatePublished.Location = new Point(4, 158);
            lblCaptionDatePublished.Margin = new Padding(4, 0, 4, 0);
            lblCaptionDatePublished.Name = "lblCaptionDatePublished";
            lblCaptionDatePublished.Size = new Size(171, 79);
            lblCaptionDatePublished.TabIndex = 2;
            lblCaptionDatePublished.Text = "Date Published";
            // 
            // lblCaptionDateArchived
            // 
            lblCaptionDateArchived.AutoSize = true;
            lblCaptionDateArchived.Dock = DockStyle.Fill;
            lblCaptionDateArchived.Location = new Point(4, 237);
            lblCaptionDateArchived.Margin = new Padding(4, 0, 4, 0);
            lblCaptionDateArchived.Name = "lblCaptionDateArchived";
            lblCaptionDateArchived.Size = new Size(171, 79);
            lblCaptionDateArchived.TabIndex = 3;
            lblCaptionDateArchived.Text = "Date Archived";
            // 
            // lblCaptionCalories
            // 
            lblCaptionCalories.AutoSize = true;
            lblCaptionCalories.Dock = DockStyle.Fill;
            lblCaptionCalories.Location = new Point(4, 316);
            lblCaptionCalories.Margin = new Padding(4, 0, 4, 0);
            lblCaptionCalories.Name = "lblCaptionCalories";
            lblCaptionCalories.Size = new Size(171, 79);
            lblCaptionCalories.TabIndex = 4;
            lblCaptionCalories.Text = "Calories";
            // 
            // lblCaptionCurrentStatus
            // 
            lblCaptionCurrentStatus.AutoSize = true;
            lblCaptionCurrentStatus.Dock = DockStyle.Fill;
            lblCaptionCurrentStatus.Location = new Point(4, 395);
            lblCaptionCurrentStatus.Margin = new Padding(4, 0, 4, 0);
            lblCaptionCurrentStatus.Name = "lblCaptionCurrentStatus";
            lblCaptionCurrentStatus.Size = new Size(171, 79);
            lblCaptionCurrentStatus.TabIndex = 5;
            lblCaptionCurrentStatus.Text = "Current Status";
            // 
            // lblCaptionRecipePic
            // 
            lblCaptionRecipePic.AutoSize = true;
            lblCaptionRecipePic.Dock = DockStyle.Fill;
            lblCaptionRecipePic.Location = new Point(4, 474);
            lblCaptionRecipePic.Margin = new Padding(4, 0, 4, 0);
            lblCaptionRecipePic.Name = "lblCaptionRecipePic";
            lblCaptionRecipePic.Size = new Size(171, 79);
            lblCaptionRecipePic.TabIndex = 6;
            lblCaptionRecipePic.Text = "Recipe Picture";
            // 
            // txtRecipeName
            // 
            txtRecipeName.Dock = DockStyle.Fill;
            txtRecipeName.Location = new Point(183, 4);
            txtRecipeName.Margin = new Padding(4);
            txtRecipeName.Multiline = true;
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(712, 71);
            txtRecipeName.TabIndex = 7;
            // 
            // txtDateDrafted
            // 
            txtDateDrafted.Dock = DockStyle.Fill;
            txtDateDrafted.Location = new Point(183, 83);
            txtDateDrafted.Margin = new Padding(4);
            txtDateDrafted.Multiline = true;
            txtDateDrafted.Name = "txtDateDrafted";
            txtDateDrafted.Size = new Size(712, 71);
            txtDateDrafted.TabIndex = 8;
            // 
            // txtDatePublished
            // 
            txtDatePublished.Dock = DockStyle.Fill;
            txtDatePublished.Location = new Point(183, 162);
            txtDatePublished.Margin = new Padding(4);
            txtDatePublished.Multiline = true;
            txtDatePublished.Name = "txtDatePublished";
            txtDatePublished.Size = new Size(712, 71);
            txtDatePublished.TabIndex = 9;
            // 
            // txtDateArchived
            // 
            txtDateArchived.Dock = DockStyle.Fill;
            txtDateArchived.Location = new Point(183, 241);
            txtDateArchived.Margin = new Padding(4);
            txtDateArchived.Multiline = true;
            txtDateArchived.Name = "txtDateArchived";
            txtDateArchived.Size = new Size(712, 71);
            txtDateArchived.TabIndex = 10;
            // 
            // txtCalories
            // 
            txtCalories.Dock = DockStyle.Fill;
            txtCalories.Location = new Point(183, 320);
            txtCalories.Margin = new Padding(4);
            txtCalories.Multiline = true;
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(712, 71);
            txtCalories.TabIndex = 11;
            // 
            // txtCurrentStatus
            // 
            txtCurrentStatus.Dock = DockStyle.Fill;
            txtCurrentStatus.Location = new Point(183, 399);
            txtCurrentStatus.Margin = new Padding(4);
            txtCurrentStatus.Multiline = true;
            txtCurrentStatus.Name = "txtCurrentStatus";
            txtCurrentStatus.Size = new Size(712, 71);
            txtCurrentStatus.TabIndex = 12;
            // 
            // txtRecipePic
            // 
            txtRecipePic.Dock = DockStyle.Fill;
            txtRecipePic.Location = new Point(183, 478);
            txtRecipePic.Margin = new Padding(4);
            txtRecipePic.Multiline = true;
            txtRecipePic.Name = "txtRecipePic";
            txtRecipePic.Size = new Size(712, 71);
            txtRecipePic.TabIndex = 13;
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
        private TextBox txtDateDrafted;
        private TextBox txtDatePublished;
        private TextBox txtDateArchived;
        private TextBox txtCalories;
        private TextBox txtCurrentStatus;
        private TextBox txtRecipePic;
    }
}