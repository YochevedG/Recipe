using System.Data.SqlClient;

namespace RecipeSystem
{
    public class Dashboard
    {

        public static DataTable GetDashboard()
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("DashboardGet");
            SQLUtility.SetParamValue(cmd, "@All", 1);
            return SQLUtility.GetDataTable(cmd);
        }
    }
}
