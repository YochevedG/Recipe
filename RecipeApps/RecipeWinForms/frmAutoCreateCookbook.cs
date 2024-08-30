using RecipeSystem;
using System.Data.SqlClient;

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
            int cookbookid = 0;
            Cursor = Cursors.WaitCursor;
            try
            {
                SqlCommand cmd = SQLUtility.GetSQLCommand("CookbookAutoCreate");
                SQLUtility.SetParamValue(cmd, "@UsersId", usersid);
                SQLUtility.SetParamValue(cmd, "@CookbookId", DBNull.Value);
                SQLUtility.ExecuteSQL(cmd);

                cookbookid = (int)cmd.Parameters["@CookbookId"].Value;

                if (cookbookid > 0)
                {

                    if (this.MdiParent != null && this.MdiParent is frmMain)
                    {
                        ((frmMain)this.MdiParent).OpenForm(typeof(frmNewCookbook), cookbookid);
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

        private void BtnCreateCookbook_Click(object? sender, EventArgs e)
        {
            CreateCookbook();
        }
    }
}