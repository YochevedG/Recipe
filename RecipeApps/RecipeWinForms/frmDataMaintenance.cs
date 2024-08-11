namespace RecipeWinForms
{
    public partial class frmDataMaintenance : Form
    {
        private enum TableTypeEnum { Users, Cuisine, Ingredient, Measurement, Course }
        DataTable dtlist = new();
        TableTypeEnum currenttabletype = TableTypeEnum.Users;
        string deletecolumnname = "deletecol";

        public frmDataMaintenance()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            this.FormClosing += FrmDataMaintenance_FormClosing;
            gData.CellContentClick += GData_CellContentClick;
            SetUpRadioButtons();
            BindData(currenttabletype);
        }

        private void BindData(TableTypeEnum tabletype)
        {
            currenttabletype = tabletype;
            dtlist = DataMaintenence.GetDataList(currenttabletype.ToString());
            gData.Columns.Clear();
            gData.DataSource = dtlist;
            switch (tabletype)
            {
                case TableTypeEnum.Measurement:
                    WindowsFormsUtility.AddComboBoxToGrid(gData, DataMaintenence.GetDataList(TableTypeEnum.Measurement.ToString()), "RecipeIngredient", "MeasurementAmount");
                    break;
            }
            DataGridViewButtonColumn col = new();

            WindowsFormsUtility.AddDeleteButtonToGrid(gData, deletecolumnname);
            WindowsFormsUtility.FormatGridForEdit(gData, tabletype.ToString());
        }

        private bool Save()
        {
            bool b = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                DataMaintenence.SaveDataList(dtlist, currenttabletype.ToString());
                b = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            return b;
        }

        private void Delete(int rowindex)
        {
            int id = WindowsFormsUtility.GetIdFromGrid(gData, rowindex, currenttabletype.ToString() + "Id");
            if (id != 0)
            {
                var response = MessageBox.Show("Are you sure you would like to delete this " + currenttabletype.ToString() + " and all related records?",Application.ProductName, MessageBoxButtons.YesNo);
               if (response == DialogResult.No)
                {
                    return;
                }
                Application.UseWaitCursor = true;
                try
                {
                    DataMaintenence.DeleteRow(currenttabletype.ToString(), id);
                    BindData(currenttabletype);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName);
                }
                finally
                {
                    Application.UseWaitCursor = false;
                }
            }
            else if (id == 0 && rowindex < gData.Rows.Count)
            {
                gData.Rows.Remove(gData.Rows[rowindex]);
            }
        }

        private void SetUpRadioButtons()
        {
            foreach (Control c in pnlOptions.Controls)
            {
                if (c is RadioButton)
                {
                    c.Click += C_Click;
                }
            }
            optUsers.Tag = TableTypeEnum.Users;
            optCuisine.Tag = TableTypeEnum.Cuisine;
            optIngredient.Tag = TableTypeEnum.Ingredient;
            optMeasurements.Tag = TableTypeEnum.Measurement;
            optCourses.Tag = TableTypeEnum.Course;
        }

        private void C_Click(object? sender, EventArgs e)
        {
            if (sender is Control && ((Control)sender).Tag is TableTypeEnum)
            {
                BindData((TableTypeEnum)((Control)sender).Tag);
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }

        private void FrmDataMaintenance_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (SQLUtility.TableHasChanges(dtlist))
            {
                var res = MessageBox.Show($"Do you want to save changes to {this.Text} before closing?", Application.ProductName, MessageBoxButtons.YesNoCancel);
                switch (res)
                {
                    case DialogResult.Yes:
                        bool b = Save();
                        if (b == false)
                        {
                            e.Cancel = true;
                            this.Activate();
                        }
                        Save();
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        this.Activate();
                        break;
                }
            }
        }
         
        private void GData_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (gData.Columns[e.ColumnIndex].Name == deletecolumnname)
            {
                Delete(e.RowIndex);
            }
        }
    }
}
