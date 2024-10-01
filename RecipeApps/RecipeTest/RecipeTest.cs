using CPUFramework;
using System.Data;
using System.Configuration;
using Microsoft.Identity.Client;

namespace RecipeTest
{
    public class RecipeTest
    {
        //string connstring = ConfigurationManager.ConnectionStrings["devconn"].ConnectionString;
        string liveconnstring = ConfigurationManager.ConnectionStrings["liveconn"].ConnectionString;

        [SetUp]
        public void Setup()
        {
            DBManager.SetConnectionString(liveconnstring,true);
        }

        private DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            DBManager.SetConnectionString(liveconnstring, false);
            dt = SQLUtility.GetDataTable(sql);
            DBManager.SetConnectionString(liveconnstring, false);
            return dt;
        }

        private int GetFirstRowValue(string sql)
        {
            int n = 0;
            DBManager.SetConnectionString(liveconnstring, false);
            n = SQLUtility.GetFirstRowValue(sql);
            DBManager.SetConnectionString(liveconnstring, false);
            return n;
        }

        private void ExecuteSQL(string sql)
        {
            DBManager.SetConnectionString(liveconnstring, false);
            SQLUtility.ExecuteSQL(sql);
            DBManager.SetConnectionString(liveconnstring, false);
        }

        [Test]
        [TestCase("cake", "1800-1-1", 600)]
        public void InsertNewRecipe(string recipename, DateTime drafteddate, int calories)
        {
            DataTable dt = GetDataTable("select * from recipe where recipeid = 0");
            DataRow r = dt.Rows.Add();
            Assume.That(dt.Rows.Count == 1);

            int cuisineid = GetFirstRowValue("select top 1 cuisineid from cuisine");
            Assume.That(cuisineid > 0, "cant run test, no cuisines in db");

            int usersid = GetFirstRowValue("select top 1 usersid from users");
            Assume.That(usersid > 0, "cant run test, no users in db");

            BizRecipe recipe = new();
            recipe.CuisineId = cuisineid;
            recipe.UsersId = usersid;
            recipe.RecipeName = recipename;
            recipe.DraftedDate = drafteddate;
            recipe.Calories = calories;

            recipe.Save();

            //string s = "";
            //DataTable recipename = SQLUtility.GetDataTable("select top 1 recipename from recipe r");

            //string recipename = "Breakfast Muffins " + DateTime.Now;

            //int maxcalories = GetFirstRowValue("select max(calories) from recipe");
            //maxcalories = maxcalories + 50;

            //TestContext.WriteLine("Insert Recipe with RecipeName = " + recipename);

            //r["cuisineid"] = cuisineid;
            //r["usersid"] = usersid;
            //r["recipename"] = recipename;
            //r["drafteddate"] = "2023-01-01";
            //r["calories"] = maxcalories;
            //Recipe.Save(dt);


            int newid = GetFirstRowValue("select * from recipe where calories = " + calories);
            Assert.IsTrue(newid > 0, "Recipe with calories = " + calories + "is not found in db");
            TestContext.WriteLine("recipe with " + calories + "is found in db with pk value = " + newid);
        }


        [Test]
        public void ChangeExistingRecipeCalories()
        {
            int recipeid = GetExsistingRecipeID();
            Assume.That(recipeid > 0, "no recipes in DB, cant run test");
            int calories = GetFirstRowValue("select calories from recipe where recipeid = " + recipeid);
            TestContext.WriteLine("calories for recipeid  " + recipeid + " is " + calories);
            calories = calories + 100;
            TestContext.WriteLine("change calories to " + calories);

            DataTable dt = Recipe.Load(recipeid);
            dt.Rows[0]["calories"] = calories;
            BizRecipe recipe = new();
            recipe.Save(dt);

            int newcalories = GetFirstRowValue("select calories from recipe where recipeid = " + recipeid);
            Assert.IsTrue(newcalories == calories, "calories for recipe (" + recipeid + ") = " + newcalories);
            TestContext.WriteLine("calories for recipe (" + recipeid + ") = " + newcalories);
        }

        [Test]
        public void ChangeExistingRecipeToBlankRecipeName()
        {
            int recipeid = GetExsistingRecipeID();
            string recipename = ""; 
            Assume.That(recipeid > 0, "no recipes in DB, cant run test");

            TestContext.WriteLine("recipename for recipeid  " + recipeid + " is " + recipename);
            recipename = "";
            TestContext.WriteLine("change recipename to " + recipename);

            DataTable dt = Recipe.Load(recipeid);
            dt.Rows[0]["recipename"] = recipename;

            Exception ex = Assert.Throws<Exception>(() => Recipe.Save(dt));
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public void ChangeExistingRecipeToNonUniqueName()
        {
            int recipeid = GetExsistingRecipeID();
            Assume.That(recipeid > 0, "no recipes in DB, cant run test");
            string recipename = GetFirstColumnFirstRowValueAsString("select top 1 recipename from recipe where recipeid <> " + recipeid);
            string currentrecipename = GetFirstColumnFirstRowValueAsString("select top 1 recipename from recipe where recipeid = " + recipeid);

            TestContext.WriteLine("change recipeid " + recipeid + " from " + currentrecipename + " to " + recipename + " which belongs to a different recipe");

            DataTable dt = Recipe.Load(recipeid);
            dt.Rows[0]["recipename"] = recipename;

            Exception ex = Assert.Throws<Exception>(() => Recipe.Save(dt));
            TestContext.WriteLine(ex.Message);
        }


        [Test]
        public void DeleteRecipe()
        {
            DataTable dt = GetDataTable("select top 1 r.recipeid, r.recipename from Recipe r left join RecipeIngredient re on re.RecipeId = r.RecipeId left join RecipeSteps rs on rs.recipeid = r.recipeid left join mealcourserecipe mc on mc.recipeid = r.recipeid left join cookbookrecipe cr on cr.RecipeId = r.RecipeId where re.RecipeIngredientId is null and rs.RecipeStepsId is null  and mc.MealCourseRecipeId is null and cr.CookbookRecipeId is null \r\n");
            int recipeid = 0;
            string recipedesc = "";
            if (dt.Rows.Count > 0)
            {
                recipeid = (int)dt.Rows[0]["recipeid"];
                recipedesc = dt.Rows[0]["RecipeName"] + " " + dt.Rows[0]["RecipeName"];
            }
            Assume.That(recipeid > 0, "no recipes without related info order in DB, cant run test");
            TestContext.WriteLine("exsisting recipe without related info = " + recipeid + " " + recipedesc);
            TestContext.WriteLine("Ensure that app can delete this " + recipeid);

            BizRecipe recipe = new();
            recipe.Load(recipeid);
            recipe.Delete();

            DataTable dtafterdelete = GetDataTable("select * from recipe where recipeid = " + recipeid);
            Assert.IsTrue(dtafterdelete.Rows.Count == 0, "Record with recipeid " + recipeid + "exists in db");
            TestContext.WriteLine("Record with recipeid " + recipeid + "does not exist in DB");
        }

        [Test]
        public void DeletePublishedRecipeOrArchivedForLessThan30Days()
        {
            string sql = @"
select top 1  r.recipeid, r.recipename
from Recipe r
where r.CurrentStatus = 'Published' or  DATEDIFF(day, r.ArchivedDate, CURRENT_TIMESTAMP) <= 30";
            DataTable dt = GetDataTable(sql);
            int recipeid = 0;
            string recipedesc = "";
            if (dt.Rows.Count > 0)
            {
                recipeid = (int)dt.Rows[0]["recipeid"];
                recipedesc = dt.Rows[0]["RecipeName"] + " " + dt.Rows[0]["RecipeName"];
            }
            Assume.That(recipeid > 0, "no recipes that are published or archived for less than 30 days, cant run test");
            TestContext.WriteLine("exsisting recipe that are Archived More Than 30 Days Or not published in DB = " + recipeid + " " + recipedesc);
            TestContext.WriteLine("Ensure that app cannot delete this " + recipeid);

            Exception ex = Assert.Throws<Exception>(() => Recipe.Delete(dt));
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public void DeleteRecipeWithRelatedRecords()
        {
            DataTable dt = GetDataTable("select top 1 r.recipeid, r.recipename from Recipe r join RecipeIngredient re on re.RecipeId = r.RecipeId join RecipeSteps rs on rs.recipeid = r.recipeid left join mealcourserecipe mc on mc.recipeid = r.recipeid left join cookbookrecipe cr on cr.RecipeId = r.RecipeId");
            int recipeid = 0;
            string recipedesc = "";
            if (dt.Rows.Count > 0)
            {
                recipeid = (int)dt.Rows[0]["recipeid"];
                recipedesc = dt.Rows[0]["RecipeName"] + " " + dt.Rows[0]["RecipeName"];
            }
            Assume.That(recipeid > 0, "no recipes with related info order in DB, cant run test");
            TestContext.WriteLine("exsisting recipe with related info = " + recipeid + " " + recipedesc);
            TestContext.WriteLine("Ensure that app cannot delete this " + recipeid);
            BizRecipe recipe = new();
            Exception ex = Assert.Throws<Exception>(() => recipe.Delete(dt));
            TestContext.WriteLine(ex.Message);
        }


        [Test]
        public void LoadRecipe()
        {
            int recipeid = GetExsistingRecipeID();
            Assume.That(recipeid > 0, "no recipe in DB, cant run test");
            TestContext.WriteLine("Exsisting recipe with id = " + recipeid);
            TestContext.WriteLine("ensure that app loads recipe " + recipeid);
            //DataTable dt = recipe.Load(recipeid);
            //int loadedid = (int)dt.Rows[0]["recipeid"];
            BizRecipe recipe = new();
            recipe.Load(recipeid);
            int loadedid = recipe.RecipeId;
            string recipename = recipe.RecipeName;
            Assert.IsTrue(loadedid == recipeid && recipename != "", loadedid + " <> " + recipeid + " RecipeName = " + recipename);
            TestContext.WriteLine("Loaded recipe (" + loadedid + ")");
        }

        [Test]
        public void SearchRecipe()
        {
            string criteria = "a";
            int num = GetFirstRowValue("select total = count(*) from recipe where recipename like '%" + criteria + "%'");

            Assume.That(num > 0, "there are no recipes that match the search for " + num);
            TestContext.WriteLine(num + "recipes that match " + criteria);
            TestContext.WriteLine("ensure that recipe search returns " + num + "rows");

            //DataTable dt = Recipe.SearchRecipe(criteria);
            //int results = dt.Rows.Count;
            //Assert.IsTrue(results == num, "results of recipe search does not match number of recipes, " + results + " <> " + num);
            //TestContext.WriteLine("Number of rows returned by recipe search is " + results);
            BizRecipe r = new();
            List<BizRecipe> lst = r.Search(criteria);
            Assert.IsTrue(lst.Count == num, "num rows returned by search (" + lst.Count + ") <> " + num);
            TestContext.WriteLine("Number of rows in search results return by app = " + lst.Count);
        }

        [Test]
        public void GetListOfUsers()
        {
            int userscount = GetFirstRowValue("select total = count(*) from users");
            Assume.That(userscount > 0, "no users found in db, cant test");

            TestContext.WriteLine("Num of users in DB = " +  userscount);
            TestContext.WriteLine("ensure that num of rows returned by app matches " + userscount);

            DataTable dt =  Recipe.GetUsersList();
            Assert.IsTrue(dt.Rows.Count == userscount, "Num rows returned by app (" + dt.Rows.Count + ") <> " + userscount);
            TestContext.WriteLine("Number of rows in Users returned by app = " + dt.Rows.Count);
        }
        
        [Test]
        public void GetListOfCuisine()
        {
            int cuisinecount = GetFirstRowValue("select total = count(*) from cuisine");
            Assume.That(cuisinecount > 0, "no cuisine found in db, cant test");

            TestContext.WriteLine("Num of cuisine in DB = " + cuisinecount);
            TestContext.WriteLine("ensure that num of rows returned by app matches " + cuisinecount);

            DataTable dt = Recipe.GetCuisineList();
            Assert.IsTrue(dt.Rows.Count == cuisinecount, "Num rows returned by app (" + dt.Rows.Count + ") <> " + cuisinecount);
            TestContext.WriteLine("Number of rows in Cuisine returned by app = " + dt.Rows.Count);
        }

        [Test]
        public void GetListOfIngredients()
        {
            int ingcount = GetFirstRowValue("select total = count (*) from ingredient");
            Assume.That(ingcount > 0, "no ingredients in db, cant test");

            TestContext.WriteLine("Num of Ingredients in DB = " + ingcount);
            TestContext.WriteLine("ensure that num of rows return by app matches " + ingcount);

            BizIngredient i = new();
            var lst = i.GetList();

            Assert.IsTrue(lst.Count == ingcount, "Num rows returned by app (" + lst.Count + ") <> " + ingcount);
            TestContext.WriteLine("Number of rows in Ingredients returned by app = " + lst.Count);
        }

        [Test]
        public void GetListOfRecipe()
        {
            int recipecount = GetFirstRowValue("select total = count (*) from recipe");
            Assume.That(recipecount > 0, "no recipe in db, cant test");

            TestContext.WriteLine("Num of recipes in DB = " + recipecount);
            TestContext.WriteLine("ensure that num of rows return by app matches " + recipecount);

            BizRecipe i = new();
            var lst = i.GetList();

            Assert.IsTrue(lst.Count == recipecount, "Num rows returned by app (" + lst.Count + ") <> " + recipecount);
            TestContext.WriteLine("Number of rows in Recipe returned by app = " + lst.Count);
        }

        [Test]
        public void SearchIngredients()
        {
            string ingname = "e";
            int ingcount = GetFirstRowValue($"select total = count(*) from ingredient where ingredientname like '%{ingname}%'");
            TestContext.WriteLine("Num of search results in DB = " + ingcount);
            TestContext.WriteLine("Ensure that num of rows return by app matches " + ingcount);
            BizIngredient i = new();
            List<BizIngredient> lst = i.Search(ingname);
            Assert.IsTrue(lst.Count == ingcount, "num rows returned by search (" + lst.Count + ") <> " + ingcount);
            TestContext.WriteLine("Number of rows in search results return by app = " + lst.Count);
        }

        private int GetExsistingRecipeID()
        {
            return GetFirstRowValue("select top 1 recipeid from recipe");
        }

        private string GetFirstColumnFirstRowValueAsString(string sql)
        {
            DataTable dt = GetDataTable(sql);
            sql = dt.Rows[0][0].ToString();
            return sql.ToString();
        }
    }
}