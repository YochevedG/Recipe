import { useEffect, useState } from 'react';
import './assets/css/bootstrap.min.css';
import MainScreen from './MainScreen';
import NavBar from './NavBar';
import SideBar from './SideBar';
import { blankrecipe } from './DataUtil';
import { IRecipe } from './DataInterfaces';
import { RecipeEdit } from './RecipeEdit';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import Meals from './Meals';
import Cookbooks from './Cookbooks';
import Login from './Login';
import ProtectedRoute from './ProtectedRoute';
import { useUserStore } from './userstore';

function App() {
  const [selectedcuisineid, setSelectedCuisineId] = useState(0);
  const [isRecipeEdit, setIsRecipeEdit] = useState(false);
  const [recipeForEdit, setRecipeForEdit] = useState(blankrecipe);
  const [unauthorizedMessage, setUnauthorizedMessage] = useState('');
  const isLoggedIn = useUserStore(state => state.isLoggedin);

  useEffect(() => {
    if (isLoggedIn) {
      setUnauthorizedMessage('');
    }
  }, [isLoggedIn]);

  const handleCusineSelected = (cuisineId: number) => {
    setIsRecipeEdit(false);
    setSelectedCuisineId(cuisineId);
  };

  const handleRecipeSelectedForEdit = (recipe: IRecipe) => {
    if (!isLoggedIn) {
      setUnauthorizedMessage('You are not authorized to view this page. Please login.');
      return;
    }
    setUnauthorizedMessage('');
    setRecipeForEdit(recipe);
    setIsRecipeEdit(true);
  };

  const handleFormClose = () => {
    setIsRecipeEdit(false);
  };

  return (
    <Router>
      {isLoggedIn ? (
        <>
          <NavBar />
          <div className='container'>
            <div className="row">
              <div className="col-12 px-0">
                <hr />
              </div>
            </div>
            <div className="row">
              <div className="col-3 col-lg-2 border border-light">
                <button onClick={() => handleRecipeSelectedForEdit(blankrecipe)} className="btn btn-outline-primary">New Recipe</button>
                <SideBar onCuisineSelected={handleCusineSelected} />
              </div>
              <div className="col-9 col-lg-10 bg-primary">
                {unauthorizedMessage && (
                  <div className="alert alert-danger" role="alert">
                    {unauthorizedMessage}
                  </div>
                )}
                {isRecipeEdit ? (
                  <RecipeEdit recipe={recipeForEdit} onClose={handleFormClose} />
                ) : (
                  <div className="recipe-list">
                    <Routes>
                      <Route path="/meals" element={<Meals />} />
                      <Route path="/cookbooks" element={<Cookbooks />} />
                      <Route path="/recipes" element={<MainScreen cuisineId={selectedcuisineid} onEdit={handleRecipeSelectedForEdit} />} />
                      <Route path="/edit-recipe" element={<ProtectedRoute requiredrole="user" element={<RecipeEdit recipe={recipeForEdit} onClose={handleFormClose} />} />} />
                      <Route path="*" element={<MainScreen cuisineId={selectedcuisineid} onEdit={handleRecipeSelectedForEdit} />} />
                    </Routes>
                  </div>
                )}
              </div>
            </div>
          </div>
        </>
      ) : (
        <Routes>
          <Route path="*" element={<Navigate to="/login" />} />
          <Route path="/login" element={<Login />} />
        </Routes>
      )}
    </Router>
  );
}

export default App;