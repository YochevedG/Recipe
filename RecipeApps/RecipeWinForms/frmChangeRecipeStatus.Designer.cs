namespace RecipeWinForms
{
    partial class frmChangeRecipeStatus
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
            lblRecipeName = new Label();
            tblCurrentStatus = new TableLayoutPanel();
            lblCurrentStatus = new Label();
            txtCurrentStatus = new TextBox();
            tblStatusDates = new TableLayoutPanel();
            lblStatusDates = new Label();
            lblDrafted = new Label();
            lblPublished = new Label();
            lblArchived = new Label();
            txtDraftedDate = new TextBox();
            txtPublishedDate = new TextBox();
            txtArchivedDate = new TextBox();
            tblStatusButtons = new TableLayoutPanel();
            btnDraft = new Button();
            btnArchive = new Button();
            btnPublish = new Button();
            tblMain.SuspendLayout();
            tblCurrentStatus.SuspendLayout();
            tblStatusDates.SuspendLayout();
            tblStatusButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.Controls.Add(lblRecipeName, 0, 0);
            tblMain.Controls.Add(tblCurrentStatus, 0, 1);
            tblMain.Controls.Add(tblStatusDates, 0, 2);
            tblMain.Controls.Add(tblStatusButtons, 0, 3);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 4;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 48.5576935F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 51.4423065F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 188F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 179F));
            tblMain.Size = new Size(1040, 576);
            tblMain.TabIndex = 0;
            // 
            // lblRecipeName
            // 
            lblRecipeName.AutoSize = true;
            lblRecipeName.Dock = DockStyle.Fill;
            lblRecipeName.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecipeName.Location = new Point(3, 0);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(1034, 101);
            lblRecipeName.TabIndex = 0;
            // 
            // tblCurrentStatus
            // 
            tblCurrentStatus.ColumnCount = 2;
            tblCurrentStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblCurrentStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblCurrentStatus.Controls.Add(lblCurrentStatus, 0, 0);
            tblCurrentStatus.Controls.Add(txtCurrentStatus, 1, 0);
            tblCurrentStatus.Dock = DockStyle.Fill;
            tblCurrentStatus.Location = new Point(3, 104);
            tblCurrentStatus.Name = "tblCurrentStatus";
            tblCurrentStatus.RowCount = 1;
            tblCurrentStatus.RowStyles.Add(new RowStyle());
            tblCurrentStatus.Size = new Size(1034, 101);
            tblCurrentStatus.TabIndex = 1;
            // 
            // lblCurrentStatus
            // 
            lblCurrentStatus.AutoSize = true;
            lblCurrentStatus.Dock = DockStyle.Fill;
            lblCurrentStatus.Location = new Point(3, 0);
            lblCurrentStatus.Name = "lblCurrentStatus";
            lblCurrentStatus.Size = new Size(511, 101);
            lblCurrentStatus.TabIndex = 0;
            lblCurrentStatus.Text = "Current Status:";
            lblCurrentStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtCurrentStatus
            // 
            txtCurrentStatus.Dock = DockStyle.Fill;
            txtCurrentStatus.Location = new Point(520, 3);
            txtCurrentStatus.Multiline = true;
            txtCurrentStatus.Name = "txtCurrentStatus";
            txtCurrentStatus.Size = new Size(511, 95);
            txtCurrentStatus.TabIndex = 1;
            // 
            // tblStatusDates
            // 
            tblStatusDates.ColumnCount = 4;
            tblStatusDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblStatusDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblStatusDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblStatusDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblStatusDates.Controls.Add(lblStatusDates, 0, 0);
            tblStatusDates.Controls.Add(lblDrafted, 1, 0);
            tblStatusDates.Controls.Add(lblPublished, 2, 0);
            tblStatusDates.Controls.Add(lblArchived, 3, 0);
            tblStatusDates.Controls.Add(txtDraftedDate, 1, 1);
            tblStatusDates.Controls.Add(txtPublishedDate, 2, 1);
            tblStatusDates.Controls.Add(txtArchivedDate, 3, 1);
            tblStatusDates.Dock = DockStyle.Fill;
            tblStatusDates.Location = new Point(3, 211);
            tblStatusDates.Name = "tblStatusDates";
            tblStatusDates.RowCount = 2;
            tblStatusDates.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblStatusDates.RowStyles.Add(new RowStyle(SizeType.Absolute, 84F));
            tblStatusDates.Size = new Size(1034, 182);
            tblStatusDates.TabIndex = 2;
            // 
            // lblStatusDates
            // 
            lblStatusDates.AutoSize = true;
            lblStatusDates.Dock = DockStyle.Fill;
            lblStatusDates.Location = new Point(3, 0);
            lblStatusDates.Name = "lblStatusDates";
            tblStatusDates.SetRowSpan(lblStatusDates, 2);
            lblStatusDates.Size = new Size(252, 182);
            lblStatusDates.TabIndex = 0;
            lblStatusDates.Text = "Status Dates";
            lblStatusDates.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDrafted
            // 
            lblDrafted.AutoSize = true;
            lblDrafted.Dock = DockStyle.Fill;
            lblDrafted.Location = new Point(261, 0);
            lblDrafted.Name = "lblDrafted";
            lblDrafted.Size = new Size(252, 98);
            lblDrafted.TabIndex = 1;
            lblDrafted.Text = "Drafted";
            lblDrafted.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPublished
            // 
            lblPublished.AutoSize = true;
            lblPublished.Dock = DockStyle.Fill;
            lblPublished.Location = new Point(519, 0);
            lblPublished.Name = "lblPublished";
            lblPublished.Size = new Size(252, 98);
            lblPublished.TabIndex = 2;
            lblPublished.Text = "Published";
            lblPublished.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblArchived
            // 
            lblArchived.AutoSize = true;
            lblArchived.Dock = DockStyle.Fill;
            lblArchived.Location = new Point(777, 0);
            lblArchived.Name = "lblArchived";
            lblArchived.Size = new Size(254, 98);
            lblArchived.TabIndex = 3;
            lblArchived.Text = "Archived";
            lblArchived.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtDraftedDate
            // 
            txtDraftedDate.Location = new Point(261, 101);
            txtDraftedDate.Name = "txtDraftedDate";
            txtDraftedDate.Size = new Size(150, 39);
            txtDraftedDate.TabIndex = 4;
            // 
            // txtPublishedDate
            // 
            txtPublishedDate.Location = new Point(519, 101);
            txtPublishedDate.Name = "txtPublishedDate";
            txtPublishedDate.Size = new Size(150, 39);
            txtPublishedDate.TabIndex = 5;
            // 
            // txtArchivedDate
            // 
            txtArchivedDate.Location = new Point(777, 101);
            txtArchivedDate.Name = "txtArchivedDate";
            txtArchivedDate.Size = new Size(150, 39);
            txtArchivedDate.TabIndex = 6;
            // 
            // tblStatusButtons
            // 
            tblStatusButtons.ColumnCount = 3;
            tblStatusButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblStatusButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblStatusButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblStatusButtons.Controls.Add(btnDraft, 0, 0);
            tblStatusButtons.Controls.Add(btnArchive, 2, 0);
            tblStatusButtons.Controls.Add(btnPublish, 1, 0);
            tblStatusButtons.Dock = DockStyle.Fill;
            tblStatusButtons.Location = new Point(3, 399);
            tblStatusButtons.Name = "tblStatusButtons";
            tblStatusButtons.RowCount = 2;
            tblStatusButtons.RowStyles.Add(new RowStyle());
            tblStatusButtons.RowStyles.Add(new RowStyle(SizeType.Absolute, 106F));
            tblStatusButtons.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblStatusButtons.Size = new Size(1034, 174);
            tblStatusButtons.TabIndex = 3;
            // 
            // btnDraft
            // 
            btnDraft.AutoSize = true;
            btnDraft.Dock = DockStyle.Fill;
            btnDraft.Location = new Point(3, 3);
            btnDraft.Name = "btnDraft";
            btnDraft.Size = new Size(338, 42);
            btnDraft.TabIndex = 0;
            btnDraft.Text = "Draft";
            btnDraft.UseVisualStyleBackColor = true;
            // 
            // btnArchive
            // 
            btnArchive.AutoSize = true;
            btnArchive.Dock = DockStyle.Fill;
            btnArchive.Location = new Point(691, 3);
            btnArchive.Name = "btnArchive";
            btnArchive.Size = new Size(340, 42);
            btnArchive.TabIndex = 2;
            btnArchive.Text = "Archive";
            btnArchive.UseVisualStyleBackColor = true;
            // 
            // btnPublish
            // 
            btnPublish.AutoSize = true;
            btnPublish.Dock = DockStyle.Fill;
            btnPublish.Location = new Point(347, 3);
            btnPublish.Name = "btnPublish";
            btnPublish.Size = new Size(338, 42);
            btnPublish.TabIndex = 1;
            btnPublish.Text = "Publish";
            btnPublish.UseVisualStyleBackColor = true;
            // 
            // frmChangeRecipeStatus
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 576);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "frmChangeRecipeStatus";
            Text = "Change Status";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblCurrentStatus.ResumeLayout(false);
            tblCurrentStatus.PerformLayout();
            tblStatusDates.ResumeLayout(false);
            tblStatusDates.PerformLayout();
            tblStatusButtons.ResumeLayout(false);
            tblStatusButtons.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblRecipeName;
        private TableLayoutPanel tblCurrentStatus;
        private Label lblCurrentStatus;
        private TableLayoutPanel tblStatusDates;
        private Label lblStatusDates;
        private Label lblDrafted;
        private Label lblPublished;
        private Label lblArchived;
        private TableLayoutPanel tblStatusButtons;
        private Button btnDraft;
        private Button btnPublish;
        private Button btnArchive;
        private TextBox txtDraftedDate;
        private TextBox txtPublishedDate;
        private TextBox txtArchivedDate;
        private TextBox txtCurrentStatus;
    }
}