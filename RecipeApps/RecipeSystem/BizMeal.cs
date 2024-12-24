using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace RecipeSystem
{
    public class BizMeal : BizObject<BizMeal>
    {
        public BizMeal()
        {

        }
        private int _mealid;
        private int _usersid;
        private string _mealname;
        private DateTime? _datecreated;
        private string _mealdesc;
        private string _mealuser;
        private int _numcourses;
        private int _numrecipes;
        private List<BizMeal> _lstmeal;


        public List<BizMeal> Search(string mealnameval)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand(this.GetSprocName);
            SQLUtility.SetParamValue(cmd, "mealName", mealnameval);
            DataTable dt = SQLUtility.GetDataTable(cmd);
            return this.GetListFromDataTable(dt);
        }

        private List<BizMeal> MealList
        {
            get
            {
                if (_lstmeal == null)
                {
                    _lstmeal = new BizMeal().GetList(true);
                }
                return _lstmeal;
            }
        }

        public int MealId
        {
            get { return _mealid; }
            set
            {
                if (_mealid != value)
                {
                    _mealid = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int UsersId
        {
            get { return _usersid; }
            set
            {
                if (_usersid != value)
                {
                    _usersid = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string MealName
        {
            get { return _mealname; }
            set
            {
                if (_mealname != value)
                {
                    _mealname = value;
                    InvokePropertyChanged();
                }
            }
        }

        public DateTime? DateCreated
        {
            get { return _datecreated; }
            set
            {
                if (_datecreated != value)
                {
                    _datecreated = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string MealDesc
        {
            get { return _mealdesc; }
            set
            {
                if (_mealdesc != value)
                {
                    _mealdesc = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string MealUser
        {
            get { return _mealuser; }
            set
            {
                if (_mealuser != value)
                {
                    _mealuser = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int NumCourses
        {
            get { return _numcourses; }
            set
            {
                if (_numcourses != value)
                {
                    _numcourses = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int NumRecipes
        {
            get { return _numrecipes; }
            set
            {
                if (_numrecipes != value)
                {
                    _numrecipes = value;
                    InvokePropertyChanged();
                }
            }
        }

    }
}
