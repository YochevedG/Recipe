namespace RecipeWinForms
{
    partial class frmDataMaintenance
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
            pnlOptions = new FlowLayoutPanel();
            optUsers = new RadioButton();
            optCuisine = new RadioButton();
            optIngredient = new RadioButton();
            optMeasurements = new RadioButton();
            optCourses = new RadioButton();
            gData = new DataGridView();
            btnSave = new Button();
            tblMain.SuspendLayout();
            pnlOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gData).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.32692F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80.67308F));
            tblMain.Controls.Add(pnlOptions, 0, 1);
            tblMain.Controls.Add(gData, 1, 1);
            tblMain.Controls.Add(btnSave, 1, 2);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 3;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.Size = new Size(1040, 576);
            tblMain.TabIndex = 0;
            // 
            // pnlOptions
            // 
            pnlOptions.Controls.Add(optUsers);
            pnlOptions.Controls.Add(optCuisine);
            pnlOptions.Controls.Add(optIngredient);
            pnlOptions.Controls.Add(optMeasurements);
            pnlOptions.Controls.Add(optCourses);
            pnlOptions.Dock = DockStyle.Fill;
            pnlOptions.Location = new Point(3, 3);
            pnlOptions.Name = "pnlOptions";
            tblMain.SetRowSpan(pnlOptions, 2);
            pnlOptions.Size = new Size(194, 570);
            pnlOptions.TabIndex = 3;
            // 
            // optUsers
            // 
            optUsers.AutoSize = true;
            optUsers.Location = new Point(3, 3);
            optUsers.Name = "optUsers";
            optUsers.Size = new Size(96, 36);
            optUsers.TabIndex = 0;
            optUsers.TabStop = true;
            optUsers.Text = "Users";
            optUsers.UseVisualStyleBackColor = true;
            // 
            // optCuisine
            // 
            optCuisine.AutoSize = true;
            optCuisine.Location = new Point(3, 45);
            optCuisine.Name = "optCuisine";
            optCuisine.Size = new Size(111, 36);
            optCuisine.TabIndex = 1;
            optCuisine.TabStop = true;
            optCuisine.Text = "Cusine";
            optCuisine.UseVisualStyleBackColor = true;
            // 
            // optIngredient
            // 
            optIngredient.AutoSize = true;
            optIngredient.Location = new Point(3, 87);
            optIngredient.Name = "optIngredient";
            optIngredient.Size = new Size(149, 36);
            optIngredient.TabIndex = 2;
            optIngredient.TabStop = true;
            optIngredient.Text = "Ingredient";
            optIngredient.UseVisualStyleBackColor = true;
            // 
            // optMeasurements
            // 
            optMeasurements.AutoSize = true;
            optMeasurements.Location = new Point(3, 129);
            optMeasurements.Name = "optMeasurements";
            optMeasurements.Size = new Size(187, 36);
            optMeasurements.TabIndex = 3;
            optMeasurements.TabStop = true;
            optMeasurements.Text = "Measurement";
            optMeasurements.UseVisualStyleBackColor = true;
            // 
            // optCourses
            // 
            optCourses.AutoSize = true;
            optCourses.Location = new Point(3, 171);
            optCourses.Name = "optCourses";
            optCourses.Size = new Size(113, 36);
            optCourses.TabIndex = 4;
            optCourses.TabStop = true;
            optCourses.Text = "Course";
            optCourses.UseVisualStyleBackColor = true;
            // 
            // gData
            // 
            gData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gData.Dock = DockStyle.Fill;
            gData.Location = new Point(203, 3);
            gData.Name = "gData";
            gData.RowHeadersWidth = 62;
            gData.Size = new Size(834, 282);
            gData.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.AutoSize = true;
            btnSave.Location = new Point(925, 531);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 42);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // frmDataMaintenance
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 576);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "frmDataMaintenance";
            Text = "Data Maintenance";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            pnlOptions.ResumeLayout(false);
            pnlOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private FlowLayoutPanel pnlOptions;
        private RadioButton optUsers;
        private RadioButton optCuisine;
        private RadioButton optIngredient;
        private RadioButton optMeasurements;
        private RadioButton optCourses;
        private DataGridView gData;
        private Button btnSave;
    }
}