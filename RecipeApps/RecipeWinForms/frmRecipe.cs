using System.Data;
using System.Diagnostics;


namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        DataTable dtrecipe;
        public frmRecipe()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
        }

       

        public void ShowForm(int recipeid)
        {
            dtrecipe = Recipe.Load(recipeid);
            if(recipeid == 0)
            {
                dtrecipe.Rows.Add();
            }
            DataTable dtcuisine = Recipe.GetCuisineList();
            DataTable dtusers = Recipe.GetUsersList();
            lstCuisine.DataSource = dtcuisine;
            lstCuisine.ValueMember = "CuisineId";
            lstCuisine.DisplayMember = "CuisineType";
            lstCuisine.DataBindings.Add("SelectedValue", dtrecipe, "cuisineid");

            lstUser.DataSource = dtusers;
            lstUser.ValueMember = "UsersId";
            lstUser.DisplayMember = "LastName";
            lstUser.DataBindings.Add("SelectedValue", dtrecipe, "usersid");

            WindowsFormsUtility.SetControlBinding(txtRecipeName, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtDraftedDate, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtPublishedDate, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtArchivedDate, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtCalories, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtCurrentStatus, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtRecipePic, dtrecipe);

            this.Show();
        }

        private void Save()
        {
            Recipe.Save(dtrecipe);
        }

        private void Delete()
        {
            Recipe.Delete(dtrecipe);
            this.Close();
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            Delete();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }

    }
}
