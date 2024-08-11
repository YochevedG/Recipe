using System.Data.SqlClient;

namespace RecipeSystem
{
    public class Recipe
    {
        public static DataTable SearchRecipe(string recipename)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeGet");
            cmd.Parameters["@RecipeName"].Value = recipename;
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable Load(int recipeid)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeGet");
            SQLUtility.SetParamValue(cmd, "@RecipeId", recipeid);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable GetRecipeList()
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeGet");
            SQLUtility.SetParamValue(cmd, "@All", 1);
            SQLUtility.SetParamValue(cmd, "@IncludeBlank", 1);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable GetCuisineList()
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("CuisineGet");
            SQLUtility.SetParamValue(cmd, "@All", 1);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
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

        public static void Save(DataTable dtrecipe)
        {
            if (dtrecipe.Rows.Count == 0)
            {
                throw new Exception("Cannot call Recipe Save method because there are no rows in the table");
            }
            DataRow r = dtrecipe.Rows[0];
            SQLUtility.SaveDataRow(r, "RecipeUpdate");
        }

        public static void Delete(DataTable dtrecipe)
        {
            int id = (int)dtrecipe.Rows[0]["RecipeId"];
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeDelete");
            SQLUtility.SetParamValue(cmd, "@RecipeId", id);
            SQLUtility.ExecuteSQL(cmd);
        }

        public static void CloneRecipe(int newrecipeid, int recipeid)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeClone");
            SQLUtility.SetParamValue(cmd, "@RecipeId", recipeid);
            SQLUtility.SetParamValue(cmd, "@NewRecipeId",newrecipeid);
            SQLUtility.ExecuteSQL(cmd);
            
        }

        public static void GetRecipeStatus(int recipeid)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("StatusGet");
            SQLUtility.SetParamValue(cmd, "@StatusId", recipeid);
            SQLUtility.ExecuteSQL(cmd);
        }

        public static void ChangeRecipeStatus(int recipeid, string newstatus)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("ChangeRecipeStatus");
            cmd.CommandType = CommandType.StoredProcedure;
            SQLUtility.SetParamValue(cmd, "@RecipeId", recipeid);
            SQLUtility.SetParamValue(cmd, "@NewStatus", newstatus);
            SQLUtility.ExecuteSQL(cmd);
        }

    }
}
