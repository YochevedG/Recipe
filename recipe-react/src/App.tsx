import { useState } from 'react';
import './assets/css/bootstrap.min.css';
import MainScreen from './MainScreen';
import NavBar from './NavBar';
import SideBar from './SideBar';
import { blankrecipe } from './DataUtil';
import { IRecipe } from './DataInterfaces';
import { RecipeEdit } from './RecipeEdit';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
import { Outlet, BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Meals from './Meals';
import Cookbooks from './Cookbooks';

function App() {
  const [selectedcuisineid, setSelectedCuisineId] = useState(0);
  const [isRecipeEdit, setIsRecipeEdit] = useState(false);
  const [recipeForEdit, setRecipeForEdit] = useState(blankrecipe);

  const handleCusineSelected = (cuisineId: number) => {
    setIsRecipeEdit(false);
    setSelectedCuisineId(cuisineId);
  };

  const handleRecipeSelectedForEdit = (recipe: IRecipe) => {
    setRecipeForEdit(recipe);
    setIsRecipeEdit(true);
  };

  const handleFormClose = () => {
    setIsRecipeEdit(false);
  };

  return (
    <Router>
      <NavBar />

      <div className='container'>
        <div className="row">
          <div className="col-12 px-0">
            <hr />
            <Outlet />
          </div>
        </div>
        <div className="row">
          <div className="col-3 col-lg-2 border border-light">
            <button onClick={() => handleRecipeSelectedForEdit(blankrecipe)} className="btn btn-outline-primary">New Recipe</button>
            <SideBar onCuisineSelected={handleCusineSelected} />
          </div>
          <div className="col-9 col-lg-10 bg-primary">
            {isRecipeEdit ? (
              <RecipeEdit recipe={recipeForEdit} onClose={handleFormClose} />
            ) : (
              <div className="recipe-list">
                <Routes>
                  <Route path="/meals" element={<Meals />} />
                  <Route path="/cookbooks" element={<Cookbooks />} />
                  <Route path="/recipes" element={<MainScreen cuisineId={selectedcuisineid} onEdit={handleRecipeSelectedForEdit} />} />
                  <Route path="*" element={<h1>Page Not Found</h1>} />

                </Routes>
                {/* <MainScreen cuisineId={selectedcuisineid} onEdit={handleRecipeSelectedForEdit} /> */}
              </div>
            )}
          </div>
          <div className="col-9 col-lg-10 bg-primary">
          </div>
        </div>
      </div>
    </Router>
  );
}

export default App;