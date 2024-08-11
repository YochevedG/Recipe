using System;
using System.Data;
using System.Diagnostics;


namespace RecipeWinForms
{
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
            btnSearch.Click += BtnSearch_Click;
            gRecipe.CellDoubleClick += GRecipe_CellDoubleClick;
            btnNew.Click += BtnNew_Click;
            gRecipe.KeyDown += GRecipe_KeyDown;
        }


        private void FormatGrid()
        { 
            gRecipe.AllowUserToAddRows = false;
            gRecipe.ReadOnly = true;
            gRecipe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gRecipe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        private void SearchRecipe(string recipename)
        {
            WindowsFormsUtility.FormatGridForSearchResults(gRecipe, "Recipe");
            DataTable dt = Recipe.SearchRecipe(recipename);
            gRecipe.DataSource = dt;
            gRecipe.Columns["RecipeId"].Visible = false;
            gRecipe.Columns["CuisineId"].Visible = false;
            gRecipe.Columns["UsersId"].Visible = false;
            gRecipe.Columns["DraftedDate"].Visible = false;
            gRecipe.Columns["PublishedDate"].Visible = false;
            gRecipe.Columns["ArchivedDate"].Visible = false;
            gRecipe.Columns["RecipeDesc"].Visible = false;
            gRecipe.Columns["MealCaloriesTotals"].Visible = false;
            gRecipe.Columns["RecipePic"].Visible = false;
        }


        private void ShowRecipeForm(int rowindex)
        {
            int id = 0;
            if(rowindex > -1)
            {
                id = WindowsFormsUtility.GetIdFromGrid(gRecipe, rowindex, "RecipeId");
            }
            if(this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmRecipe), id);
            } 
            //int id = 0;
            //if (rowindex > -1)
            //{
            //    id = (int)gRecipe.Rows[rowindex].Cells["RecipeId"].Value;
            //}
            //frmRecipe frm = new();
            //frm.ShowForm(id);
        }

        private void GRecipe_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            ShowRecipeForm(e.RowIndex);
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            SearchRecipe(txtSearch.Text);
        }

        private void BtnNew_Click(object? sender, EventArgs e)
        {
            ShowRecipeForm(-1);
        }

        private void GRecipe_KeyDown(object? sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && gRecipe.SelectedRows.Count > 0)
            {
                ShowRecipeForm(gRecipe.SelectedRows[0].Index);
                e.SuppressKeyPress = true;
            }
        }
    }
}
