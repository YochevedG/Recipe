using CPUFramework;
using System.Data;
using CPUWindowsFormFramework;
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
            string sql = "select r.*, c.cuisinetype, u.LastName from Recipe r join Cuisine c on c.CuisineId = r.CuisineId join Users u on u.UsersId = r.UsersId where r.RecipeId =  " + recipeid.ToString();
            dtrecipe = SQLUtility.GetDataTable(sql);
            if(recipeid == 0)
            {
                dtrecipe.Rows.Add();
            }
            DataTable dtcuisine = SQLUtility.GetDataTable("select cuisineid, cuisinetype from cuisine");
            DataTable dtusers = SQLUtility.GetDataTable("select usersid, lastname from users");
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
            SQLUtility.DebugPrintDataTable(dtrecipe);
            DataRow r = dtrecipe.Rows[0];
            int id = (int)r["recipeid"];
            string sql = "";

            if (id > 0)
            {
                sql = string.Join(Environment.NewLine, $"update recipe set",
               $"CuisineId = '{r["CuisineId"]}',",
               $"UsersId = '{r["UsersId"]}',",
               $"RecipeName = '{r["RecipeName"]}',",
               $"DraftedDate = '{r["DraftedDate"]}',",
               //$"PublishedDate = '{r["PublishedDate"]}',",
               //$"ArchivedDate = '{r["ArchivedDate"]}',",
               $"Calories = '{r["Calories"]}'",
               //$"CurrentStatus = '{r["CurrentStatus"]}',",
              // $"RecipePic = '{r["RecipePic"]}'",
               $"where recipeid = {r["recipeid"]}");
            }

            else
            {
                sql = "insert recipe(cuisineid, usersid, recipename, drafteddate, calories)"; //, currentstatus, recipepic)";
                sql += $"select '{r["cuisineid"]}', '{r["usersid"]}', '{r["RecipeName"]}','{r["DraftedDate"]}','{r["Calories"]}'"; //'{r["CurrentStatus"]}','{r["RecipePic"]}'";
            }
            Debug.Print(sql);
            SQLUtility.ExecuteSQL(sql);
        }

        private void Delete()
        {
            int id = (int)dtrecipe.Rows[0]["Recipeid"];
            string sql = "delete recipe where recipeid = " + id;
            SQLUtility.ExecuteSQL(sql);
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
