using RecipeSystem;

namespace RecipeWinForms
{
    public partial class frmNewCookbook : Form
    {
        DataTable dtrecipe = new DataTable();
        DataTable dtcookbooks = new DataTable();
        DataTable dtcookbookrecipe = new DataTable();
        int cookbookid = 0;
        string deletecolumnname = "deletcol";
        BindingSource bindsource = new BindingSource();

        public frmNewCookbook()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            btnSaveRecipe.Click += BtnSaveRecipe_Click;
            gData.CellContentClick += GData_CellContentClick;
            this.Shown += FrmNewCookbook_Shown;
        }


        private void FrmNewCookbook_Shown(object? sender, EventArgs e)
        {
            LoadCookbookRecipe();
        }

        public void LoadCookbookForm(int cookbookidval)
        {
            cookbookid = cookbookidval;
            this.Tag = cookbookid;
            dtcookbooks = Cookbooks.Load(cookbookid);
            bindsource.DataSource = dtcookbooks;
            if (cookbookid == 0)
            {
                dtcookbooks.Rows.Add();
            }
            DataTable dtusers = Cookbooks.GetUsersList();
            lstUsers.DataSource = dtusers;
            lstUsers.ValueMember = "UsersId";
            lstUsers.DisplayMember = "LastName";
            lstUsers.DataBindings.Add("SelectedValue", dtcookbooks, "usersid");

            WindowsFormsUtility.SetControlBinding(txtCookbookName, bindsource);
            WindowsFormsUtility.SetControlBinding(txtDateCreated, bindsource);
            WindowsFormsUtility.SetControlBinding(txtPrice, bindsource);
            WindowsFormsUtility.SetControlBinding(lblDateCreated, bindsource);
            ckActive.DataBindings.Add("Checked", dtcookbooks, "ActiveInactive", true, DataSourceUpdateMode.OnPropertyChanged);

            this.Text = GetCookbookDesc();
            LoadCookbookRecipe();
            SetButtonsEnabledBasedOnNewRecord();
            dtcookbooks.AcceptChanges();
        }

        private void LoadCookbookRecipe()
        {
            dtcookbookrecipe = CookbookRecipe.LoadByCookbookId(cookbookid);
            gData.Columns.Clear();
            gData.DataSource = dtcookbookrecipe;
            WindowsFormsUtility.AddComboBoxToGrid(gData, DataMaintenence.GetDataList("Recipe"), "Recipe", "RecipeName");
            WindowsFormsUtility.AddDeleteButtonToGrid(gData, deletecolumnname);
            WindowsFormsUtility.FormatGridForEdit(gData, "CookbookRecipe");
            gData.Columns["recipename"].Visible = false;
            gData.Columns["cookbookid"].Visible = false;
        }

        private string GetCookbookDesc()
        {
            string value = "New Cookbook";
            int pkvalue = SQLUtility.GetValueFromFirstRowAsInt(dtcookbooks, "CookbookId");
            if (pkvalue > 0)
            {
                value = SQLUtility.GetValueFromFirstRowAsString(dtcookbooks, "CookbookName");
            }
            return value;
        }

        private bool Save()
        {
            bool b = false;
            Application.UseWaitCursor = true;
            try
            {
                var response = MessageBox.Show($"Would you like to save changes to {this.Text} before closing?", Application.ProductName, MessageBoxButtons.YesNoCancel);
                if (response == DialogResult.No)
                {
                    return b;
                }
                if(response == DialogResult.Yes)
                {
                    Cookbooks.Save(dtcookbooks);
                    bindsource.ResetBindings(false);
                    cookbookid = SQLUtility.GetValueFromFirstRowAsInt(dtcookbooks, "CookbookId");
                    this.Tag = cookbookid;
                    SetButtonsEnabledBasedOnNewRecord();
                    this.Text = GetCookbookDesc();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cookbook");
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
            return b;
        }

        private void SaveCookbookRecipe()
        {
            try
            {
                var response = MessageBox.Show($"Would you like to save changes to {this.Text} before closing?", Application.ProductName, MessageBoxButtons.YesNoCancel);
                if(response == DialogResult.No)
                {
                    return;
                }
                if(response == DialogResult.Yes)
                {
                     CookbookRecipe.SaveTable(dtcookbookrecipe, cookbookid);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
        }

        private void Delete()
        {
            var response = MessageBox.Show("Are you sure you want to delete this cookbook?", "Cookbook", MessageBoxButtons.YesNo);
            if (response == DialogResult.No)
            {
                return;
            }
            Application.UseWaitCursor = true;
            try
            {
                Recipe.Delete(dtcookbooks);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cookbook");
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
        }

        private void SetButtonsEnabledBasedOnNewRecord()
        {
            bool b = cookbookid == 0 ? false : true;
            btnDelete.Enabled = b;
            btnSaveRecipe.Enabled = b;
            btnSave.Enabled = b;
        }

        private void DeleteCookbookRecipe(int rowindex)
        {
            int id = WindowsFormsUtility.GetIdFromGrid(gData, rowindex, "CookbookRecipeId");
            if (id > 0)
            {
                try
                {
                    CookbookRecipe.Delete(id);
                    LoadCookbookRecipe();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName);
                }
            }
            else if (id < gData.Rows.Count)
            {
                gData.Rows.RemoveAt(rowindex);
            }
        }
        private void BtnSaveRecipe_Click(object? sender, EventArgs e)
        {
            SaveCookbookRecipe();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            Delete();
        }

        private void GData_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            DeleteCookbookRecipe(e.RowIndex);
        }
    }
}
