using RecipeSystem;

namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        DataTable dtrecipe = new DataTable();
        DataTable dtrecipeingredients = new DataTable();
        DataTable dtrecipesteps = new DataTable();
        BindingSource bindsource = new BindingSource();
        string deletecolumnname = "deletcol";
        int recipeid = 0;
        public frmRecipe()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            this.FormClosing += FrmRecipe_FormClosing;
            btnSaveIngredient.Click += BtnSaveIngredient_Click;
            btnSaveSteps.Click += BtnSaveSteps_Click;
            gIngredient.CellContentClick += GIngredient_CellContentClick;
            gSteps.CellContentClick += GSteps_CellContentClick;
            btnChangeStatus.Click += BtnChangeStatus_Click;
            gIngredient.DataError += GIngredient_DataError;
            gSteps.DataError += GSteps_DataError;
            this.Shown += FrmRecipe_Shown;
        }

        private void GSteps_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Wrong Data Type", Application.ProductName);
        }

        private void GIngredient_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Wrong Data Type", Application.ProductName);
        }

        private void FrmRecipe_Shown(object? sender, EventArgs e)
        {
            LoadRecipeIngredients();
            LoadRecipeSteps();
        }

        public void LoadForm(int recipeidval)
        {
            recipeid = recipeidval;
            dtrecipe = Recipe.Load(recipeid);
            bindsource.DataSource = dtrecipe;
            if (recipeid == 0)
            {
                dtrecipe.Rows.Add();
            }
            DataTable dtcuisine = Recipe.GetCuisineList();
            DataTable dtusers = Recipe.GetUsersList();
            lstCuisine.DataSource = dtcuisine;
            lstCuisine.ValueMember = "CuisineId";
            lstCuisine.DisplayMember = "CuisineType";
            lstCuisine.DataBindings.Add("SelectedValue", dtrecipe, "cuisineid");

            lstUsers.DataSource = dtusers;
            lstUsers.ValueMember = "UsersId";
            lstUsers.DisplayMember = "LastName";
            lstUsers.DataBindings.Add("SelectedValue", dtrecipe, "usersid");

            WindowsFormsUtility.SetControlBinding(txtRecipeName, bindsource);
            WindowsFormsUtility.SetControlBinding(txtDraftedDate, bindsource);
            WindowsFormsUtility.SetControlBinding(txtPublishedDate, bindsource);
            WindowsFormsUtility.SetControlBinding(txtArchivedDate, bindsource);
            WindowsFormsUtility.SetControlBinding(txtCalories, bindsource);
            WindowsFormsUtility.SetControlBinding(txtCurrentStatus, bindsource);
            WindowsFormsUtility.SetControlBinding(txtRecipePic, bindsource);

            this.Text = GetRecipeDesc();
            LoadRecipeIngredients();
            LoadRecipeSteps();
            SetButtonsEnabledBasedOnNewRecord();
        }

        private void LoadRecipeIngredients()
        {
            dtrecipeingredients = RecipeIngredient.LoadByRecipeId(recipeid);
            gIngredient.Columns.Clear();
            gIngredient.DataSource = dtrecipeingredients;
            WindowsFormsUtility.AddComboBoxToGrid(gIngredient, DataMaintenence.GetDataList("Ingredient"), "Ingredient", "IngredientName");
            WindowsFormsUtility.AddDeleteButtonToGrid(gIngredient, deletecolumnname);
            WindowsFormsUtility.FormatGridForEdit(gIngredient, "RecipeIngredient");
            gIngredient.Columns["recipeid"].Visible = false;
            gIngredient.Columns["MeasurementTypeid"].Visible = false;
        }

        private void LoadRecipeSteps()
        {
            dtrecipesteps = RecipeSteps.LoadByRecipeId(recipeid);
            gSteps.Columns.Clear();
            gSteps.DataSource = dtrecipesteps;
            WindowsFormsUtility.AddComboBoxToGrid(gSteps, DataMaintenence.GetDataList("RecipeSteps"), "RecipeSteps", "Instructions");
            WindowsFormsUtility.AddDeleteButtonToGrid(gSteps, deletecolumnname);
            WindowsFormsUtility.FormatGridForEdit(gSteps, "RecipeSteps");
            gSteps.Columns["recipeid"].Visible = false;
            gSteps.Columns["Instructions"].Visible = false;
        }

        private bool Save()
        {
            bool b = false;
            Application.UseWaitCursor = true;
            try
            {
                Recipe.Save(dtrecipe);
                bindsource.ResetBindings(false);
                recipeid = SQLUtility.GetValueFromFirstRowAsInt(dtrecipe, "RecipeId");
                this.Tag = recipeid;
                SetButtonsEnabledBasedOnNewRecord();
                this.Text = GetRecipeDesc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Recipe");
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
            return b;
        }


        private void Delete()
        {
            //string alloweddelete = SQLUtility.GetValueFromFirstRowAsString(dtrecipe, "IsDeleteAllowed");
            //if(alloweddelete != "")
            //{
            //    MessageBox.Show(alloweddelete, Application.ProductName);
            //    return;
            //}

            var response = MessageBox.Show("Are you sure you want to delete this recipe?", "Recipe", MessageBoxButtons.YesNo);
            if (response == DialogResult.No)
            {
                return;
            }
            Application.UseWaitCursor = true;
            try
            {
                Recipe.Delete(dtrecipe);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Recipe");
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
        }

        private void SaveRecipeIngredient()
        {
            try
            {
                var response = MessageBox.Show($"Would you like to save changes to {this.Text} before closing?", Application.ProductName, MessageBoxButtons.YesNoCancel);
                if (response == DialogResult.No)
                {
                    return;
                }
                if(response == DialogResult.Yes)
                {
                    RecipeIngredient.SaveTable(dtrecipeingredients, recipeid);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
        }

        private void SaveRecipeSteps()
        {
            try
            {
                RecipeSteps.SaveTable(dtrecipesteps, recipeid);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
        }

        private void DeleteRecipeIngredient(int rowindex)
        {
            int id = WindowsFormsUtility.GetIdFromGrid(gIngredient, rowindex, "RecipeIngredientId");
            if (id > 0)
            {
                try
                {
                    RecipeIngredient.Delete(id);
                    LoadRecipeIngredients();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName);
                }
            }
            else if (id < gIngredient.Rows.Count)
            {
                gIngredient.Rows.RemoveAt(rowindex);
            }
        }

        private void DeleteRecipeSteps(int rowindex)
        {
            int id = WindowsFormsUtility.GetIdFromGrid(gSteps, rowindex, "RecipeStepstId");
            if (id > 0)
            {
                try
                {
                    RecipeSteps.Delete(id);
                    LoadRecipeSteps();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName);
                }
            }
            else if (id < gSteps.Rows.Count)
            {
                gSteps.Rows.RemoveAt(rowindex);
            }
        }

        private void SetButtonsEnabledBasedOnNewRecord()
        {
            bool b = recipeid == 0 ? false : true;
            btnDelete.Enabled = b;
            btnSaveIngredient.Enabled = b;
            btnSaveSteps.Enabled = b;
        }


        private string GetRecipeDesc()
        {
            string value = "New Recipe";
            int pkvalue = SQLUtility.GetValueFromFirstRowAsInt(dtrecipe, "RecipeId");
            if (pkvalue > 0)
            {
                value = /*SQLUtility.GetValueFromFirstRowAsInt(dtrecipe, "Calories") + " " +*/ SQLUtility.GetValueFromFirstRowAsString(dtrecipe, "RecipeName");
            }
            return value;
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            Delete();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }

        private void FrmRecipe_FormClosing(object? sender, FormClosingEventArgs e)
        {
            bindsource.EndEdit();
            if (SQLUtility.TableHasChanges(dtrecipe))
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

        private void BtnSaveSteps_Click(object? sender, EventArgs e)
        {
            SaveRecipeSteps();
        }

        private void BtnSaveIngredient_Click(object? sender, EventArgs e)
        {
            SaveRecipeIngredient();
        }

        private void GSteps_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            DeleteRecipeSteps(e.RowIndex);
        }

        private void GIngredient_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            DeleteRecipeIngredient(e.RowIndex);
        }

        private void BtnChangeStatus_Click(object? sender, EventArgs e)
        {
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmChangeRecipeStatus), recipeid);
                Recipe.GetRecipeStatus(recipeid);
            }
            this.Close();
        }

    }
}
