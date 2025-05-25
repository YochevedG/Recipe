import { FieldValues } from "react-hook-form";
import { ICuisine, IRecipe, IUsers } from "./DataInterfaces";
import { createAPI, getUserStore } from "@yochevedg/reactutils";

const baseurl = "https://recipeapi-yg.azurewebsites.net/api/"

function api() {
    const sessionkey = getUserStore(baseurl).getState().sessionKey;
    return createAPI(baseurl, sessionkey);
}

export async function fetchRecipes() {
    return await api().fetchData<IRecipe[]>("recipe");
}

export async function fetchCuisine() {
    return await api().fetchData<ICuisine[]>("cuisine");
}

export async function fetchRecipesByCuisineId(cuisineId: number) {
    return await api().fetchData<IRecipe[]>(`Recipe/getbycuisine/${cuisineId}`);
}

export async function fetchUsers() {
    return await api().fetchData<IUsers[]>("recipe/users");
}

export async function postRecipe(form: FieldValues) {
    return api().postData<IRecipe>("recipe", form);
}

export async function deleteRecipe(recipeId: number) {
    return api().deleteData<IRecipe>(`recipe?id=${recipeId}`);
}

export const blankrecipe: IRecipe = {
    recipeId: 0,
    cuisineId: 0,
    usersId: 0,
    recipeName: "",
    draftedDate: new Date(),
    publishedDate: new Date(),
    //archivedDate: new Date(),
    calories: 0,
    vegan: "",
    errorMessage: ""
};