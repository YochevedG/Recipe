using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RecipeSystem
{
    public class BizCookbook : BizObject<BizCookbook>
    {
        public BizCookbook()
        {

        }

        private int _cookbookid;
        private int _usersid;
        private string _cookbookname = "";
        private decimal _price;
        private DateTime? _datecreated;
        private string _author;
        private int _numrecipes;
        private int _cookbookskill;
        private string _cookbookdesc;
        private List<BizCookbook> _lstcookbook;


        public List<BizCookbook> Search(int recipeid,string cookbooknameval)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand(this.GetSprocName);
            SQLUtility.SetParamValue(cmd, "CookbookName", cookbooknameval);
            DataTable dt = SQLUtility.GetDataTable(cmd);
            return this.GetListFromDataTable(dt);
        }

        private List<BizCookbook> CookbookList
        {
            get
            {
                if (_lstcookbook == null)
                {
                    _lstcookbook = new BizCookbook().GetList(true);
                }
                return _lstcookbook;
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

        public string CookbookName
        {
            get { return _cookbookname; }
            set
            {
                if (_cookbookname != value)
                {
                    _cookbookname = value;
                    InvokePropertyChanged();
                }
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
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

        public int CookbookSkill
        {
            get { return _cookbookskill; }
            set
            {
                if (_cookbookskill != value)
                {
                    _cookbookskill = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string CookbookDesc
        {
            get { return _cookbookdesc; }
            set
            {
                if (_cookbookdesc != value)
                {
                    _cookbookdesc = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string Author
        {
            get { return _author; }
            set
            {
                if (_author != value)
                {
                    _author = value;
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
