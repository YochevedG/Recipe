import { IRecipe } from "./DataInterfaces";

interface Props {
    recipe: IRecipe;
    onRecipeSelected: (recipe: number) => void;
    onRecipeSelectedForEdit: (recipe: IRecipe) => void;
}

export default function RecipeCard({ recipe }: Props) {
    return (
        <div className="card">
            <img src={`/images/recipe-images/${recipe.recipeName}pic.jpg`} className="card-img-top" alt="..." />
            <div className="card-body">
                <h5 className="card-title">{recipe.recipeName}</h5>
                <p className="card-text"></p>
                {/* <button onClick={() => onEdit(recipe)} className="btn btn-primary">Edit</button> */}
            </div>
        </div>
    );
}