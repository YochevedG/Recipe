using CPUFramework;
using System.Data;

namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        public frmRecipe()
        {
            InitializeComponent();
        }

        public void ShowForm(int recipeid)
        {
            string sql = "select * from recipe r where r.recipeid = " + recipeid.ToString();
            DataTable dt = SQLUtility.GetDataTable(sql);
            txtRecipeName.DataBindings.Add("Text", dt, "RecipeName");
            txtDateDrafted.DataBindings.Add("Text", dt, "DraftedDate");
            txtDatePublished.DataBindings.Add("Text", dt, "PublishedDate");
            txtDateArchived.DataBindings.Add("Text", dt, "ArchivedDate");
            txtCalories.DataBindings.Add("Text", dt, "Calories");
            txtCurrentStatus.DataBindings.Add("Text", dt, "CurrentStatus");
            txtRecipePic.DataBindings.Add("Text", dt, "RecipePic");
            this.Show();
        }


    }
}
