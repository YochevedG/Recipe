using CPUFramework;
using System.Data;

namespace RecipeTest
{
    public class RecipeTest
    {
        [SetUp]
        public void Setup()
        {
            DBManager.SetConnectionString("Server=tcp:ygoldberg.database.windows.net,1433;Initial Catalog=RecipeDB;Persist Security Info=False;User ID=ygoldberg;Password=Mlowinger1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        [Test]
        public void InsertNewRecipe()
        {
            DataTable dt = SQLUtility.GetDataTable("select * from recipe where recipeid = 0");
            DataRow r = dt.Rows.Add();
            Assume.That(dt.Rows.Count == 1);

            int cuisineid = SQLUtility.GetFirstRowValue("select top 1 cuisineid from cuisine");
            Assume.That(cuisineid > 0, "cant run test, no cuisines in db");

            int usersid = SQLUtility.GetFirstRowValue("select top 1 usersid from users");
            Assume.That(usersid > 0, "cant run test, no users in db");

            //string s = "";
            //DataTable recipename = SQLUtility.GetDataTable("select top 1 recipename from recipe r");
            string recipename = "Breakfast Muffins " + DateTime.Now;

            int maxcalories = SQLUtility.GetFirstRowValue("select max(calories) from recipe");
            maxcalories = maxcalories + 50;

            TestContext.WriteLine("Insert Recipe with RecipeName = " + recipename);

            r["cuisineid"] = cuisineid;
            r["usersid"] = usersid;
            r["recipename"] = recipename;
            r["drafteddate"] = "2023-01-01";
            r["calories"] = maxcalories;
            Recipe.Save(dt);


            int newid = SQLUtility.GetFirstRowValue("select * from recipe where calories = " + maxcalories);
            Assert.IsTrue(newid > 0, "Recipe with calories = " + maxcalories + "is not found in db");
            TestContext.WriteLine("recipe with " + maxcalories + "is found in db with pk value = " + newid);
        }


        [Test]
        public void ChangeExistingRecipeCalories()
        {
            int recipeid = GetExsistingRecipeID();
            Assume.That(recipeid > 0, "no recipes in DB, cant run test");
            int calories = SQLUtility.GetFirstRowValue("select calories from recipe where recipeid = " + recipeid);
            TestContext.WriteLine("calories for recipeid  " + recipeid + " is " + calories);
            calories = calories + 100;
            TestContext.WriteLine("change calories to " + calories);

            DataTable dt = Recipe.Load(recipeid);
            dt.Rows[0]["calories"] = calories;
            Recipe.Save(dt);

            int newcalories = SQLUtility.GetFirstRowValue("select calories from recipe where recipeid = " + recipeid);
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
            DataTable dt = SQLUtility.GetDataTable("select top 1 r.recipeid, r.recipename from Recipe r left join RecipeIngredient re on re.RecipeId = r.RecipeId left join RecipeSteps rs on rs.recipeid = r.recipeid left join mealcourserecipe mc on mc.recipeid = r.recipeid left join cookbookrecipe cr on cr.RecipeId = r.RecipeId where re.RecipeIngredientId is null and rs.RecipeStepsId is null  and mc.MealCourseRecipeId is null and cr.CookbookRecipeId is null \r\n");
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
            Recipe.Delete(dt);

            DataTable dtafterdelete = SQLUtility.GetDataTable("select * from recipe where recipeid = " + recipeid);
            Assert.IsTrue(dtafterdelete.Rows.Count == 0, "Record with recipeid " + recipeid + "exists in db");
            TestContext.WriteLine("Record with recipeid " + recipeid + "does not exist in DB");
        }

        [Test]
        public void CannotDeleteRecipeDraftedOrArchivedOver30Days()
        {
            string sql = @"
select top 1  r.recipeid, r.recipename
from Recipe r
where r.CurrentStatus <> 'Drafted' and  DATEDIFF(day, r.ArchivedDate, CURRENT_TIMESTAMP) <= 30";
            DataTable dt = SQLUtility.GetDataTable(sql);
            int recipeid = 0;
            string recipedesc = "";
            if (dt.Rows.Count > 0)
            {
                recipeid = (int)dt.Rows[0]["recipeid"];
                recipedesc = dt.Rows[0]["RecipeName"] + " " + dt.Rows[0]["RecipeName"];
            }
            Assume.That(recipeid > 0, "no recipes that are Archived less Than 30 Days Or Drafted in DB, cant run test");
            TestContext.WriteLine("exsisting recipe that are Archived More Than 30 Days Or Drafted in DB = " + recipeid + " " + recipedesc);
            TestContext.WriteLine("Ensure that app cannot delete this " + recipeid);

            Exception ex = Assert.Throws<Exception>(() => Recipe.Delete(dt));
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public void DeleteRecipeWithRelatedRecords()
        {
            DataTable dt = SQLUtility.GetDataTable("select top 1 r.recipeid, r.recipename from Recipe r join RecipeIngredient re on re.RecipeId = r.RecipeId join RecipeSteps rs on rs.recipeid = r.recipeid left join mealcourserecipe mc on mc.recipeid = r.recipeid left join cookbookrecipe cr on cr.RecipeId = r.RecipeId");
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

            Exception ex = Assert.Throws<Exception>(() => Recipe.Delete(dt));
            TestContext.WriteLine(ex.Message);
        }


        [Test]
        public void LoadRecipe()
        {
            int recipeid = GetExsistingRecipeID();
            Assume.That(recipeid > 0, "no recipe in DB, cant run test");
            TestContext.WriteLine("Exsisting recipe with id = " + recipeid);
            TestContext.WriteLine("ensure that app loads recipe " + recipeid);

            DataTable dt = Recipe.Load(recipeid);

            int loadedid = (int)dt.Rows[0]["recipeid"];
            Assert.IsTrue(loadedid == recipeid, dt.Rows[0]["recipeid"] + " <> " + recipeid);
            TestContext.WriteLine("Loaded recipe (" + loadedid + ")");
        }

        [Test]
        public void SearchRecipe()
        {
            string criteria = "a";
            int num = SQLUtility.GetFirstRowValue("select total = count(*) from recipe where recipename like '%" + criteria + "%'");

            Assume.That(num > 0, "there are no recipes that match the search for " + num);
            TestContext.WriteLine(num + "recipes that match " + criteria);
            TestContext.WriteLine("ensure that recipe search returns " + num + "rows");

            DataTable dt = Recipe.SearchRecipe(criteria);
            int results = dt.Rows.Count;
            Assert.IsTrue(results == num, "results of recipe search does not match number of recipes, " + results + " <> " + num);
            TestContext.WriteLine("Number of rows returned by recipe search is " + results);
        }

        [Test]
        public void GetListOfUsers()
        {
            int userscount = SQLUtility.GetFirstRowValue("select total = count(*) from users");
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
            int cuisinecount = SQLUtility.GetFirstRowValue("select total = count(*) from cuisine");
            Assume.That(cuisinecount > 0, "no cuisine found in db, cant test");

            TestContext.WriteLine("Num of cuisine in DB = " + cuisinecount);
            TestContext.WriteLine("ensure that num of rows returned by app matches " + cuisinecount);

            DataTable dt = Recipe.GetCuisineList();
            Assert.IsTrue(dt.Rows.Count == cuisinecount, "Num rows returned by app (" + dt.Rows.Count + ") <> " + cuisinecount);
            TestContext.WriteLine("Number of rows in Cuisine returned by app = " + dt.Rows.Count);
        }

        private int GetExsistingRecipeID()
        {
            return SQLUtility.GetFirstRowValue("select top 1 recipeid from recipe");
        }

        private string GetFirstColumnFirstRowValueAsString(string sql)
        {
            DataTable dt = SQLUtility.GetDataTable(sql);
            sql = dt.Rows[0][0].ToString();
            return sql.ToString();
        }
    }
}