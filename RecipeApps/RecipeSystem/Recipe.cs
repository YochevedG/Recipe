using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RecipeSystem
{
    public class Recipe
    {
        public static DataTable SearchRecipe(string recipename)
        {
            string sql = "select * from recipe r where r.recipename like '%" + recipename + "%'";

            DataTable dt = SQLUtility.GetDataTable(sql);
            return dt;
        }

        public static DataTable Load(int recipeid)
        {
            string sql = "select r.*, c.cuisinetype, u.LastName from Recipe r join Cuisine c on c.CuisineId = r.CuisineId join Users u on u.UsersId = r.UsersId where r.RecipeId =  " + recipeid.ToString();
            return SQLUtility.GetDataTable(sql);
        }

        public static DataTable GetCuisineList()
        {
            return SQLUtility.GetDataTable("select cuisineid, cuisinetype from cuisine");
        }

        public static DataTable GetUsersList()
        {
            return SQLUtility.GetDataTable("select usersid, lastname from users");
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
                sql += $"select '{r["cuisineid"]}', '{r["usersid"]}', '{r["RecipeName"]}','{r["DraftedDate"]}','{r["Calories"]}'"; //'{r["CurrentStatus"]}','{r["RecipePic"]}'";
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
