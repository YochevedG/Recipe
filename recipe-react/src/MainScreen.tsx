import { useEffect, useState } from "react";
import { fetchRecipesByCuisineId } from "./DataUtil";
import RecipeCard from "./RecipeCard";
import { IRecipe } from "./DataInterfaces";

interface Props {
    cuisineId: number;
    onEdit: (recipe: IRecipe) => void;
}

export default function MainScreen({ cuisineId, onEdit }: Props) {
    const [recipelist, setRecipeList] = useState<IRecipe[]>([]);
    const [isloading, setIsLoading] = useState(false);

    useEffect(() => {
        if (cuisineId > 0) {
            setIsLoading(true);
            const fetchdata = async () => {
                const data = await fetchRecipesByCuisineId(cuisineId);
                setRecipeList(data);
                setIsLoading(false);
            };
            fetchdata();
        }
    }, [cuisineId]);

    return (
        <>
            <div className="row">
                <div className={isloading ? "placeholder-glow" : ""}>
                    <h2 className="mt-2 bg-light ">
                        <span className={isloading ? "placeholder" : ""}> {recipelist.length} Recipes</span>
                    </h2>
                </div>
            </div>
            <div className="row">
                {recipelist.map(p => (
                    <div className="col-md-6 col-lg-3 mb-2" key={p.recipeId}>
                        <RecipeCard
                            recipe={p}
                            onRecipeSelected={() => { }}
                            onRecipeSelectedForEdit={() => { }}
                        />
                        <button onClick={() => onEdit(p)} className="btn btn-primary mt-2">Edit</button>
                    </div>
                ))}
            </div>
        </>
    );
}