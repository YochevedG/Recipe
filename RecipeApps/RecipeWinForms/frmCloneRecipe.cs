using System.Data.SqlClient;

namespace RecipeWinForms
{
    public partial class frmCloneRecipe : Form
    {
        DataTable dtrecipe = new DataTable();
        public frmCloneRecipe()
        {
            InitializeComponent();
            BindData();
            btnClone.Click += BtnClone_Click;
        }

        private void BindData()
        {
            DataTable dtRecipeName = Recipe.GetRecipeList();
            lstRecipes.DataSource = dtRecipeName;
            lstRecipes.ValueMember = "RecipeId";
            lstRecipes.DisplayMember = "RecipeName";
        }

        private void CreateRecipes()
        {
            int recipeid = WindowsFormsUtility.GetIdFromComboBox(lstRecipes);
            int newrecipeid = 0;
            Cursor = Cursors.WaitCursor;
            try
            {
                SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeClone");
                SQLUtility.SetParamValue(cmd, "@RecipeId", recipeid);
                SQLUtility.SetParamValue(cmd, "@NewRecipeId", newrecipeid);
                SQLUtility.ExecuteSQL(cmd);

                newrecipeid = (int)cmd.Parameters["@NewRecipeId"].Value;

                if (newrecipeid > 0)
                {
                    int id = newrecipeid;
                    if (this.MdiParent != null && this.MdiParent is frmMain)
                    {
                        
                        ((frmMain)this.MdiParent).OpenForm(typeof(frmRecipe), id);
                        this.Close();
                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);

            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void BtnClone_Click(object? sender, EventArgs e)
        {
            CreateRecipes();
        }

    }
}
