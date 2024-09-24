using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class BizRecipe : BizObject
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
        private DateTime? _archiveddate;
        private int _calories;

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

        public DateTime? ArchivedDate
        {
            get { return _archiveddate; }
            set
            {
                if (_archiveddate != value)
                {
                    _archiveddate = value;
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
    }
}
