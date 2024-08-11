using System.Data.SqlClient;

namespace RecipeSystem
{
    public class Cookbooks
    {
        public static DataTable GetCookbookList()
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("CookbookGet");
            SQLUtility.SetParamValue(cmd, "@All", 1);
            return SQLUtility.GetDataTable(cmd);
        }
        public static DataTable GetUsersList()
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("UsersGet");
            SQLUtility.SetParamValue(cmd, "@All", 1);
            SQLUtility.SetParamValue(cmd, "@IncludeBlank", 1);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }
        public static DataTable Load(int cookbookid)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("CookbookGet");
            SQLUtility.SetParamValue(cmd, "@CookbookId", cookbookid);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static void Save(DataTable dtcookbook)
        {
            if (dtcookbook.Rows.Count == 0)
            {
                throw new Exception("Cannot call Cookbook Save method because there are no rows in the table");
            }
            DataRow r = dtcookbook.Rows[0];
            SQLUtility.SaveDataRow(r, "CookbookUpdate");
        }

        public static void Delete(DataTable dtcookbook)
        {
            int id = (int)dtcookbook.Rows[0]["CookbookId"];
            SqlCommand cmd = SQLUtility.GetSQLCommand("CookbookDelete");
            SQLUtility.SetParamValue(cmd, "@CookbookId", id);
            SQLUtility.ExecuteSQL(cmd);
        }

        public static int AutoCreateCookbook(int usersid)
        {
            int cookbookid = 1;
            SqlCommand cmd = SQLUtility.GetSQLCommand("CookbookAutoCreate");
            SQLUtility.SetParamValue(cmd, "@UsersId", usersid);
            SQLUtility.ExecuteSQL(cmd);
            cookbookid = (int)cmd.Parameters["@CookbookId"].Value;
            return cookbookid;
        }
    }
}
