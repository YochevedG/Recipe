import { IRecipe } from "./DataInterfaces";

interface Props {
    recipe: IRecipe
}

export default function RecipeCard({ recipe }: Props) {
    return (
        <>
            <div className="card">
                <img src={`/images/recipe-images/${recipe.recipeName}pic.jpg`} className="card-img-top" alt="..." />
                <div className="card-body">
                    <h5 className="card-title">{recipe.recipeName}</h5>
                    <p className="card-text"></p>
                </div>
            </div>
        </>
    )
}