namespace RecipeWinForms
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            this.Activated += FrmDashboard_Activated;
            btnRecipeList.Click += BtnRecipeList_Click;
            btnMealList.Click += BtnMealList_Click;
            btnCookbookList.Click += BtnCookbookList_Click;
        }

        private void BtnCookbookList_Click(object? sender, EventArgs e)
        {
            ShowCookbookForm();
        }

        private void BtnMealList_Click(object? sender, EventArgs e)
        {
            ShowMealForm();
        }

        private void BtnRecipeList_Click(object? sender, EventArgs e)
        {
            ShowRecipeForm();
        }

        private void FrmDashboard_Activated(object? sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            gData.DataSource = Dashboard.GetDashboard();
            WindowsFormsUtility.FormatGridForEdit(gData, "Dashboard");
        }


        private void ShowRecipeForm()
        {
            if(this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmSearch));
            }
        }

        private void ShowCookbookForm()
        {
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmCookbookList));
            }
        }

        private void ShowMealForm()
        {
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmMealList));
            }
        }
    }
}
