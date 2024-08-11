namespace RecipeWinForms
{
    public partial class frmMealList : Form
    {
        public frmMealList()
        {
            InitializeComponent();
            this.Activated += FrmMealList_Activated;
        }

        private void FrmMealList_Activated(object? sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            gMealData.DataSource = Meals.GetMealList();
            WindowsFormsUtility.FormatGridForEdit(gMealData, "Meal");
        }
    }
}
