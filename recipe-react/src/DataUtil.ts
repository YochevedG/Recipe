import { FieldValues } from "react-hook-form";
import { ICuisine, IRecipe, IUsers } from "./DataInterfaces";

const baseurl = "https://localhost:44370/api/"
// "https://recipeapi-yg.azurewebsites.net/api/"

async function fetchData<T>(url: string): Promise<T> {
    url = baseurl + url;
    const r = await fetch(url);
    const data = await r.json();
    return data;
}

async function deleteData<T>(url: string): Promise<T> {
    url = baseurl + url;
    const r = await fetch(url, { method: "DELETE" });
    const data = await r.json();
    return data;
}

async function postData<T>(url: string, form: FieldValues): Promise<T> {
    url = baseurl + url;
    const r = await fetch(url, {
        method: "POST",
        body: JSON.stringify(form),
        headers: {
            "Content-Type": "application/json"
        }
    });
    const data = await r.json();
    return data;
}

export async function fetchRecipes() {
    return await fetchData<IRecipe[]>("recipe");
}

export async function fetchCuisine() {
    return await fetchData<ICuisine[]>("cuisine");
}

export async function fetchRecipesByCuisineId(cuisineId: number) {
    return await fetchData<IRecipe[]>(`Recipe/getbycuisine/${cuisineId}`);
}

export async function fetchUsers() {
    return await fetchData<IUsers[]>("recipe/users");
}

export async function postRecipe(form: FieldValues) {
    return postData<IRecipe>("recipe", form);
}

export async function deleteRecipe(recipeId: number) {
    return deleteData<IRecipe>(`recipe?id=${recipeId}`);
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