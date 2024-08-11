namespace RecipeWinForms
{
    partial class frmMealList
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
            gMealData = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gMealData).BeginInit();
            SuspendLayout();
            // 
            // gMealData
            // 
            gMealData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gMealData.Dock = DockStyle.Fill;
            gMealData.Location = new Point(0, 0);
            gMealData.Name = "gMealData";
            gMealData.RowHeadersWidth = 62;
            gMealData.Size = new Size(1040, 576);
            gMealData.TabIndex = 0;
            // 
            // frmMealList
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 576);
            Controls.Add(gMealData);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 4, 4, 4);
            Name = "frmMealList";
            Text = "Meal List";
            ((System.ComponentModel.ISupportInitialize)gMealData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gMealData;
    }
}