using System.Data;
using System.Diagnostics;
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
            cmd.Parameters["@RecipeId"].Value = recipeid;
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable GetCuisineList()
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("CuisineGet");
            cmd.Parameters["@All"].Value = 1;
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable GetUsersList()
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("UsersGet");
            cmd.Parameters["@All"].Value = 1;
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static void Save(DataTable dtrecipe)
        {
            SQLUtility.DebugPrintDataTable(dtrecipe);
            DataRow r = dtrecipe.Rows[0];
            int id = (int)r["recipeid"];
            string sql = "";

            if (id > 0)
            {
                sql = string.Join(Environment.NewLine, $"update recipe set",
               $"CuisineId = '{r["CuisineId"]}',",
               $"UsersId = '{r["UsersId"]}',",
               $"RecipeName = '{r["RecipeName"]}',",
               $"DraftedDate = '{r["DraftedDate"]}',",
               //$"PublishedDate = '{r["PublishedDate"]}',",
               //$"ArchivedDate = '{r["ArchivedDate"]}',",c
               $"Calories = '{r["Calories"]}'",
               //$"CurrentStatus = '{r["CurrentStatus"]}',",
               // $"RecipePic = '{r["RecipePic"]}'",
               $"where recipeid = {r["recipeid"]}");
            }

            else
            {
                sql = "insert recipe(cuisineid, usersid, recipename, drafteddate, calories)"; //, currentstatus, recipepic)";
                sql += $"select '{r["CuisineId"]}', '{r["usersid"]}', '{r["RecipeName"]}','{r["DraftedDate"]}','{r["Calories"]}'"; //'{r["CurrentStatus"]}','{r["RecipePic"]}'";
            }
            Debug.Print(sql);
            SQLUtility.ExecuteSQL(sql);
        }

        public static void Delete(DataTable dtrecipe)
        {
            int id = (int)dtrecipe.Rows[0]["Recipeid"];
            string sql = "delete recipe where recipeid = " + id;
            SQLUtility.ExecuteSQL(sql);
        }
    }
}
