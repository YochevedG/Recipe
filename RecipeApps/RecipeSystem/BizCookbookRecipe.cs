using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;


namespace RecipeSystem
{
    public class BizCookbookRecipe: BizObject<BizCookbookRecipe>
    {
        public BizCookbookRecipe()
        {
           
        }
        private int _cookbookrecipeid;
        private int _recipeid;
        private int _cookbookid;
        private int? _recipesequence;
        private string _recipename = "";
        private int _calories;
        private string _vegan;
        private string _lastname;
        private int _numingredients;
        private string _currentstatus;

        public List<BizCookbookRecipe> LoadbyCookbookId(int cookbookid)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("CookbookRecipeGet");
            cmd.Parameters["@cookbookid"].Value = cookbookid;
            var dt = SQLUtility.GetDataTable(cmd);
            return this.GetListFromDataTable(dt);
        }

        public List<BizCookbookRecipe> Search(string cookbookname)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand(this.GetSprocName);
            SQLUtility.SetParamValue(cmd, "CookbookName", cookbookname);
            DataTable dt = SQLUtility.GetDataTable(cmd);
            return this.GetListFromDataTable(dt);
        }

        public int CookbookRecipeId
        {
            get { return _cookbookrecipeid; }
            set
            {
                if (_cookbookrecipeid != value)
                {
                    _cookbookrecipeid = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int CookbookId
        {
            get { return _cookbookid; }
            set
            {
                if (_cookbookid != value)
                {
                    _cookbookid = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int RecipeId
        {
            get { return _recipeid; }
            set
            {
                if (_recipeid != value)
                {
                    _recipeid = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int? RecipeSequence
        {
            get { return _recipesequence; }
            set
            {
                if (_recipesequence != value)
                {
                    _recipesequence = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string RecipeName
        {
            get { return _recipename; }
            set
            {
                if (_recipename != value)
                {
                    _recipename = value;
                    InvokePropertyChanged();
                }
            }
        }
        public int Calories
        {
            get { return _calories; }
            set
            {
                if (_calories != value)
                {
                    _calories = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string LastName
        {
            get { return _lastname; }
            set
            {
                if (_lastname != value)
                {
                    _lastname = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string CurrentStatus
        {
            get { return _currentstatus; }
            set
            {
                if (_currentstatus != value)
                {
                    _currentstatus = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string Vegan
        {
            get { return _vegan; }
            set
            {
                if (_vegan != value)
                {
                    _vegan = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int NumIngredients
        {
            get { return _numingredients; }
            set
            {
                if (_numingredients != value)
                {
                    _numingredients = value;
                    InvokePropertyChanged();
                }
            }
        }

    }
}
