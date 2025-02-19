using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RecipeSystem
{
    public class BizRecipe : BizObject<BizRecipe>
    {
        public BizRecipe() 
        {

        }

        private int _recipeId;
        private int _cuisineId;
        private int _usersId;
        private string _recipename = "";
        private DateTime _drafteddate;
        private DateTime? _publisheddate;
        //private DateTime? _archiveddate;
        private int _calories;
        private string _vegan;
        //private string _lastname;
        //private int _numingredients;
        //private string _currentstatus;
        //private string _cuisinetype;
        private List<BizRecipe> _lstrecipe;
        private List<BizCuisine> _lstcuisine;


        public List<BizRecipe> Search(string recipenameval)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand(this.GetSprocName);
            SQLUtility.SetParamValue(cmd, "@RecipeName", recipenameval);

            DataTable dt = SQLUtility.GetDataTable(cmd);
            return this.GetListFromDataTable(dt);
        }

        public List<BizRecipe> SearchRecipes(int cuisineid, string recipename, string cuisinetype)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeGet");
            SQLUtility.SetParamValue(cmd, "@RecipeName", recipename);
            SQLUtility.SetParamValue(cmd, "@CuisineId", cuisineid);
            SQLUtility.SetParamValue(cmd, "@CuisineType", cuisinetype);
            DataTable dt = SQLUtility.GetDataTable(cmd);
            return this.GetListFromDataTable(dt);
        }

        private List<BizCuisine> CuisineList
        {
            get
            {
                if (_lstcuisine == null)
                {
                    _lstcuisine = new BizCuisine().GetList(true);
                }
                return _lstcuisine;
            }
        }

        private List<BizRecipe> RecipeList
        {
            get
            {
                if (_lstrecipe == null)
                {
                    _lstrecipe = new BizRecipe().GetList(true);
                }
                return _lstrecipe;
            }
        }

        public int RecipeId
        {
            get { return _recipeId; }
            set
            {
                if (_recipeId != value)
                {
                    _recipeId = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int CuisineId
        {
            get { return _cuisineId; }
            set
            {
                if (_cuisineId != value)
                {
                    _cuisineId = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int UsersId
        {
            get { return _usersId; }
            set
            {
                if (_usersId != value)
                {
                    _usersId = value;
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

        public DateTime DraftedDate
        {
            get { return _drafteddate; }
            set
            {
                if (_drafteddate != value)
                {
                    _drafteddate = value;
                    InvokePropertyChanged();
                }
            }
        }

        public DateTime? PublishedDate
        {
            get { return _publisheddate; }
            set
            {
                if (_publisheddate != value)
                {
                    _publisheddate = value;
                    InvokePropertyChanged();
                }
            }
        }

        //public DateTime? ArchivedDate
        //{
        //    get { return _archiveddate; }
        //    set
        //    {
        //        if (_archiveddate != value)
        //        {
        //            _archiveddate = value;
        //            InvokePropertyChanged();
        //        }
        //    }
        //}

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

        //public string LastName
        //{
        //    get { return _lastname; }
        //    set
        //    {
        //        if (_lastname != value)
        //        {
        //            _lastname = value;
        //            InvokePropertyChanged();
        //        }
        //    }
        //}

        //public string CurrentStatus
        //{
        //    get { return _currentstatus; }
        //    set
        //    {
        //        if (_currentstatus != value)
        //        {
        //            _currentstatus = value;
        //            InvokePropertyChanged();
        //        }
        //    }
        //}

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

        //public int NumIngredients
        //{
        //    get { return _numingredients; }
        //    set
        //    {
        //        if (_numingredients != value)
        //        {
        //            _numingredients = value;
        //            InvokePropertyChanged();
        //        }
        //    }
        //}
        //public string CuisineType
        //{
        //    get { return _cuisinetype; }
        //    set
        //    {
        //        if (_cuisinetype != value)
        //        {
        //            _cuisinetype = value;
        //            InvokePropertyChanged();
        //        }
        //    }
        //}

        private BizCuisine Cuisine
        {
            get => _lstcuisine?.FirstOrDefault(p => p.CuisineId == this.CuisineId);
            set
            {
                this.CuisineId = value == null ? 0 : value.CuisineId;
                InvokePropertyChanged();
            }
        }
    }
}
