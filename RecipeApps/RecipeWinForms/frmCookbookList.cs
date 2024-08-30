using RecipeSystem;

namespace RecipeWinForms
{
    public partial class frmCookbookList : Form
    {
       
        public frmCookbookList()
        {
            InitializeComponent();
            btnNewCookbook.Click += BtnNewCookbook_Click;
            this.Activated += FrmCookbookList_Activated;
            gDataCookbook.CellDoubleClick += GDataCookbook_CellDoubleClick;
            gDataCookbook.KeyDown += GDataCookbook_KeyDown;
        }

        private void GDataCookbook_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            ShowCookbookForm(e.RowIndex);
        }

        private void BtnNewCookbook_Click(object? sender, EventArgs e)
        {
            ShowCookbookForm(-1);
        }

        private void ShowCookbookForm(int rowindex)
        {

            int id = 0;
            if (rowindex > -1)
            {
                id = WindowsFormsUtility.GetIdFromGrid(gDataCookbook, rowindex, "CookbookId");
            }
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmNewCookbook), id);
            }
        }
        private void FrmCookbookList_Activated(object? sender, EventArgs e)
        {
            BindData();
            gDataCookbook.Columns["ActiveInactive"].Visible = false;
        }

        private void BindData()
        {
            gDataCookbook.DataSource = Cookbooks.GetCookbookList();
            WindowsFormsUtility.FormatGridForEdit(gDataCookbook, "Cookbook");
        }

        private void GDataCookbook_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gDataCookbook.SelectedRows.Count > 0)
            {
                ShowCookbookForm(gDataCookbook.SelectedRows[0].Index);
                e.SuppressKeyPress = true;
            }
        }
    }
}
