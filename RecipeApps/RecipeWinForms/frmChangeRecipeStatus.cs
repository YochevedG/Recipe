using RecipeSystem;

namespace RecipeWinForms
{
    public partial class frmChangeRecipeStatus : Form
    {
        DataTable dtrecipe = new DataTable();
        BindingSource bindsource = new BindingSource();
        int recipeid = 0;
        public frmChangeRecipeStatus()
        {
            InitializeComponent();
            btnArchive.Click += BtnArchive_Click;
            btnPublish.Click += BtnPublish_Click;
            btnDraft.Click += BtnDraft_Click;
        }

        public void LoadForm(int recipeidval)
        {
            recipeid = recipeidval;
            dtrecipe = Recipe.Load(recipeid);
            bindsource.DataSource = dtrecipe;

            WindowsFormsUtility.SetControlBinding(lblRecipeName, bindsource);
            WindowsFormsUtility.SetControlBinding(txtCurrentStatus, bindsource);
            WindowsFormsUtility.SetControlBinding(txtArchivedDate, bindsource);
            WindowsFormsUtility.SetControlBinding(txtPublishedDate, bindsource);
            WindowsFormsUtility.SetControlBinding(txtDraftedDate, bindsource);
            DisableButtons();
        }

        private void DisableButtons()
        {
            if (txtCurrentStatus.Text.Contains("Published"))
            {
                btnPublish.Enabled = false;
            }
            else if (txtCurrentStatus.Text.Contains("Drafted"))
            {
                btnDraft.Enabled = false;
            }
            else if (txtCurrentStatus.Text.Contains("Archived"))
            {
                btnArchive.Enabled = false;
            }
        }

        private void BtnDraft_Click(object? sender, EventArgs e)
        {

            var response = MessageBox.Show("Are you sure you want to change this recipe status to Drafted?", Application.ProductName, MessageBoxButtons.YesNo);
            if( response == DialogResult.No)
            {
                return;
            }
            if(response == DialogResult.Yes)
            {
                string newstatus = "Drafted";
                Recipe.ChangeRecipeStatus(recipeid, newstatus);
                dtrecipe = Recipe.Load(recipeid);
                bindsource.DataSource = dtrecipe;
            }
            
        }

        private void BtnPublish_Click(object? sender, EventArgs e)
        {
            var response = MessageBox.Show("Are you sure you want to change this recipe status to Published?", Application.ProductName, MessageBoxButtons.YesNo);
            if (response == DialogResult.No)
            {
                return;
            }
            if (response == DialogResult.Yes)
            {
                string newstatus = "Published";
                Recipe.ChangeRecipeStatus(recipeid, newstatus);
                dtrecipe = Recipe.Load(recipeid);
                bindsource.DataSource = dtrecipe;
            }
        }

        private void BtnArchive_Click(object? sender, EventArgs e)
        {
            var response = MessageBox.Show("Are you sure you want to change this recipe status to Archived?", Application.ProductName, MessageBoxButtons.YesNo);
            if (response == DialogResult.No)
            {
                return;
            }
            if (response == DialogResult.Yes)
            {
                string newstatus = "Archived";
                Recipe.ChangeRecipeStatus(recipeid, newstatus);
                dtrecipe = Recipe.Load(recipeid);
                bindsource.DataSource = dtrecipe;
            }
        }
    }
}
