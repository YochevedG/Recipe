using RecipeSystem;

namespace RecipeWinForms
{
    public partial class frmAutoCreateCookbook : Form
    {
        public frmAutoCreateCookbook()
        {
            InitializeComponent();
            BindData();
            btnCreateCookbook.Click += BtnCreateCookbook_Click;
        }


        private void BindData()
        {
            DataTable usersdt = Cookbooks.GetUsersList();
            lstUsers.DataSource = usersdt;
            lstUsers.ValueMember = "UsersId";
            lstUsers.DisplayMember = "LastName";
        }

        private void CreateCookbook()
        {
            int usersid = WindowsFormsUtility.GetIdFromComboBox(lstUsers);
            Cursor = Cursors.WaitCursor;
            try
            {
                if (this.MdiParent != null && this.MdiParent is frmMain)
                {
                    Cookbooks.AutoCreateCookbook(usersid);
                    ((frmMain)this.MdiParent).OpenForm(typeof(frmNewCookbook),usersid);
                    this.Close();
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

        private void BtnCreateCookbook_Click(object? sender, EventArgs e)
        {
            CreateCookbook();
        }
    }
}