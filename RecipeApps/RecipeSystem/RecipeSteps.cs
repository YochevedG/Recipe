using System.Data.SqlClient;

namespace RecipeSystem
{
    public class RecipeSteps
    {
        public static DataTable LoadByRecipeId(int recipeid)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeStepsGet");
            cmd.Parameters["@RecipeId"].Value = recipeid;
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static void SaveTable(DataTable dt, int recipeid)
        {
            foreach (DataRow r in dt.Select("", "", DataViewRowState.Added))
            {
                r["RecipeId"] = recipeid;
            }
            SQLUtility.SaveDataTable(dt, "RecipeStepsUpdate");
        }

        public static void Delete(int recipestepsid)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeStepsDelete");
            cmd.Parameters["@RecipeStepsId"].Value = recipestepsid;
            SQLUtility.ExecuteSQL(cmd);
        }
    }
}
