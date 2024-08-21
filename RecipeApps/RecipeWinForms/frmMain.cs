namespace RecipeWinForms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            mnuWindowCascade.Click += MnuWindowCascade_Click;
            mnuWindowTile.Click += MnuWindowTile_Click;
            mnuRecipeList.Click += MnuRecipeList_Click;
            mnuNewRecipe.Click += MnuNewRecipe_Click;
            mnuCloneARecipe.Click += MnuCloneARecipe_Click;
            mnuMealList.Click += MnuMealList_Click;
            mnuCoobookList.Click += MnuCoobookList_Click;
            mnuNewCookbook.Click += MnuNewCookbook_Click;
            mnuCookbookAutoCreate.Click += MnuCookbookAutoCreate_Click;
            mnuEditData.Click += MnuEditData_Click;
            mnuDashboard.Click += MnuDashboard_Click;
            this.Shown += FrmMain_Shown;
        }

       

        private void FrmMain_Shown(object? sender, EventArgs e)
        {
            frmLogin f = new() { StartPosition = FormStartPosition.CenterParent }; 
            bool b = f.ShowLogin();
            if (b == false)
            {
                this.Close();
                Application.Exit();
                return;
            }
            OpenForm(typeof(frmDashboard));
        }

        public void OpenForm(Type frmtype, int pkvalue = 0)
        {
            bool b = WindowsFormsUtility.IsFormOpen(frmtype);
            if(b == false)
            {
                Form? newfrm = null;
                if (frmtype == typeof(frmRecipe))
                {
                    frmRecipe f = new();
                    newfrm = f;
                    f.LoadForm(pkvalue);
                }
                else if (frmtype == typeof(frmSearch))
                {
                    frmSearch f = new();
                    newfrm = f;
                }
                else if (frmtype == typeof(frmDataMaintenance))
                {
                    frmDataMaintenance f = new();
                    newfrm = f;
                }
                else if (frmtype == typeof(frmDashboard))
                {
                    frmDashboard f = new();
                    newfrm = f;
                }
                else if(frmtype == typeof(frmCloneRecipe))
                {
                    frmCloneRecipe f = new();
                    newfrm = f;
                }
                else if(frmtype == typeof(frmAutoCreateCookbook))
                {
                    frmAutoCreateCookbook f = new();
                    newfrm = f;
                }
                else if (frmtype == typeof(frmNewCookbook))
                {
                    frmNewCookbook f = new();
                    newfrm = f;
                    f.LoadCookbookForm(pkvalue);
                }
                else if(frmtype == typeof(frmCookbookList))
                {
                    frmCookbookList f = new();
                    newfrm = f;
                }
                else if(frmtype == typeof(frmMealList))
                {
                    frmMealList f = new();
                    newfrm = f;
                }
                else if (frmtype == typeof(frmChangeRecipeStatus))
                {
                    frmChangeRecipeStatus f = new();
                    newfrm = f;
                    f.LoadForm(pkvalue);
                }
                if (newfrm != null)
                {
                    newfrm.MdiParent = this;
                    newfrm.WindowState = FormWindowState.Maximized;
                    newfrm.FormClosed += Newfrm_FormClosed;
                    newfrm.TextChanged += Newfrm_TextChanged;
                    newfrm.Show();
                }
            }
            WindowsFormsUtility.SetupNav(tsMain);
        }

        private void Newfrm_TextChanged(object? sender, EventArgs e)
        {
            WindowsFormsUtility.SetupNav(tsMain);
        }

        private void Newfrm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            WindowsFormsUtility.SetupNav(tsMain);
        }

        private void MnuWindowTile_Click(object? sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void MnuWindowCascade_Click(object? sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void MnuRecipeList_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmSearch));
        }

        private void MnuEditData_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmDataMaintenance));
        }

        private void MnuCookbookAutoCreate_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmAutoCreateCookbook));
        }

        private void MnuNewCookbook_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmNewCookbook));
        }

        private void MnuCoobookList_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmCookbookList));  
        }

        private void MnuMealList_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmMealList));
        }

        private void MnuCloneARecipe_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmCloneRecipe));
        }

        private void MnuNewRecipe_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmRecipe));
        }

        private void MnuDashboard_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmDashboard));
        }
    }
}
