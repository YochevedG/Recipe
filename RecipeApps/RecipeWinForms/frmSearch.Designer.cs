namespace RecipeWinForms
{
    partial class frmSearch
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
            gRecipe = new DataGridView();
            tblMain = new TableLayoutPanel();
            tblSearch = new TableLayoutPanel();
            btnNew = new Button();
            ((System.ComponentModel.ISupportInitialize)gRecipe).BeginInit();
            tblMain.SuspendLayout();
            tblSearch.SuspendLayout();
            SuspendLayout();
            // 
            // gRecipe
            // 
            gRecipe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gRecipe.Dock = DockStyle.Fill;
            gRecipe.Location = new Point(3, 61);
            gRecipe.Name = "gRecipe";
            gRecipe.RowHeadersWidth = 62;
            gRecipe.Size = new Size(996, 521);
            gRecipe.TabIndex = 1;
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(tblSearch, 0, 0);
            tblMain.Controls.Add(gRecipe, 0, 1);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tblMain.Size = new Size(1002, 585);
            tblMain.TabIndex = 0;
            // 
            // tblSearch
            // 
            tblSearch.AutoSize = true;
            tblSearch.ColumnCount = 4;
            tblSearch.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblSearch.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblSearch.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblSearch.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblSearch.Controls.Add(btnNew, 3, 0);
            tblSearch.Dock = DockStyle.Fill;
            tblSearch.Location = new Point(3, 3);
            tblSearch.Name = "tblSearch";
            tblSearch.RowCount = 1;
            tblSearch.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblSearch.Size = new Size(996, 52);
            tblSearch.TabIndex = 0;
            // 
            // btnNew
            // 
            btnNew.Dock = DockStyle.Fill;
            btnNew.Location = new Point(750, 3);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(243, 46);
            btnNew.TabIndex = 3;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // frmSearch
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1002, 585);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "frmSearch";
            Text = "Recipe Search";
            ((System.ComponentModel.ISupportInitialize)gRecipe).EndInit();
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblSearch.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gRecipe;
        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblSearch;
        private Button btnNew;
    }
}