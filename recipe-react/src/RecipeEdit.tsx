import { useEffect, useState } from "react";
import { FieldValues, useForm } from "react-hook-form";
import { blankrecipe, deleteRecipe, fetchCuisine, fetchUsers, postRecipe } from "./DataUtil";
import { IUsers, IRecipe, ICuisine } from "./DataInterfaces";

interface Props {
    recipe: IRecipe;
    onClose: () => void;
}

export function RecipeEdit({ recipe, onClose }: Props) {
    const { register, handleSubmit, reset } = useForm({ defaultValues: recipe });
    const [users, setUsers] = useState<IUsers[]>([]);
    const [cuisine, setCuisine] = useState<ICuisine[]>([]);
    const [errormsg, setErrorMsg] = useState("");

    useEffect(() => {
        const fetchdata = async () => {
            const data = await fetchUsers();
            setUsers(data);
            reset(recipe);
        }
        fetchdata();
    }, [recipe, reset]);

    useEffect(() => {
        const fetchdata = async () => {
            const data = await fetchCuisine();
            setCuisine(data);
            reset(recipe);
        }
        fetchdata();
    }, [recipe, reset]);

    const submitForm = async (data: FieldValues) => {
        console.log("Form Data:", data); // Log form data to verify fields
        console.log("Payload being sent to postRecipe:", JSON.stringify(data)); // Log payload being sent
        const r = await postRecipe(data);
        setErrorMsg(r.errorMessage);
        if (!r.errorMessage) {
            onClose();
        }
    };

    const handleDelete = async () => {
        const r = await deleteRecipe(recipe.recipeId);
        setErrorMsg(r.errorMessage);
        if (r.errorMessage === "") {
            reset(blankrecipe);
        }
    };

    return (
        <div className="bg-light mt-4 p-4">
            <div className="row">
                <div className="col-12">
                    <h2 id="hmsg">{errormsg} </h2>
                </div>
            </div>
            <div className="row">
                <div className="col-6">
                    <form onSubmit={handleSubmit(submitForm)} className="needs-validation">
                        <div className="mb-3">
                            <label htmlFor="recipeId" className="form-label">Recipe ID:</label>
                            <input type="hidden" id="txtRecipeId" {...register("recipeId")} className="form-control" required />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="usersId" className="form-label">Users ID:</label>
                            <select  {...register("usersId")} className="form-select">
                                {users.map(u => <option key={u.usersId} value={u.usersId}>{u.lastName}</option>)}
                            </select>
                        </div>
                        <div className="mb-3">
                            <label htmlFor="cuisineId" className="form-label">Cuisine ID:</label>
                            <select  {...register("cuisineId")} className="form-select">
                                {cuisine.map(c => <option key={c.cuisineId} value={c.cuisineId}>{c.cuisineType}</option>)}
                            </select>
                        </div>
                        <div className="mb-3">
                            <label htmlFor="recipeName" className="form-label">Recipe Name:</label>
                            <input type="text" id="recipeName" {...register("recipeName")} name="recipeName" className="form-control" required />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="draftedDate" className="form-label">Drafted Date:</label>
                            <input type="text" {...register("draftedDate")} name="draftedDate" className="form-control" required />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="publishedDate" className="form-label">Published Date:</label>
                            <div className="form-control-plaintext">{recipe.publishedDate?.toString()}</div>
                        </div>
                        <div className="mb-3">
                            <label htmlFor="calories" className="form-label">Calories:</label>
                            <input type="number" {...register("calories")} name="calories" className="form-control" required />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="vegan" className="form-label">Vegan:</label>
                            <input type="text" {...register("vegan")} name="vegan" className="form-control" />
                        </div>
                        <button type="submit" className="btn btn-primary">Submit</button>
                        <button onClick={handleDelete} type="button" id="btndelete" className="btn btn-danger">Delete</button>
                    </form>
                </div>
            </div>
        </div>
    );
}