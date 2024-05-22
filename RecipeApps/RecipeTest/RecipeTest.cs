using CPUFramework;
using System.Data;

namespace RecipeTest
{
    public class RecipeTest
    {
        [SetUp]
        public void Setup()
        {
            DBManager.SetConnectionString("Server=.\\SQLExpress;Database=RecipeDB;Trusted_Connection=true");
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

            string recipename = SQLUtility.GetFirstRowValue("select recipeplusdate = concat(recipename,  CURRENT_TIMESTAMP) from recipe").ToString();
            recipename = "Breakfast Muffins";

            TestContext.WriteLine("Insert Recipe with recipename = " + recipename);

            r["cuisineid"] = cuisineid;
            r["usersid"] = usersid;
            r["recipename"] = recipename;
            r["drafteddate"] = "2023-01-01";
            r["calories"] = 200;
            Recipe.Save(dt);

            int newid = SQLUtility.GetFirstRowValue("select * from recipe where recipename " + recipename);
            Assert.IsTrue(newid > 0, "recipe with " + recipename + "is not found in db");
            TestContext.WriteLine("recipe with " + recipename + "is found in db with value = " + newid);
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

            DataTable dt = Recipe.GetUsersList();
            Assert.IsTrue(dt.Rows.Count == cuisinecount, "Num rows returned by app (" + dt.Rows.Count + ") <> " + cuisinecount);
            TestContext.WriteLine("Number of rows in Cuisine returned by app = " + dt.Rows.Count);
        }

        private int GetExsistingRecipeID()
        {
            return SQLUtility.GetFirstRowValue("select top 1 recipeid from recipe");
        }
    }
}