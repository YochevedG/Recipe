import { ICuisine, IRecipe } from "./DataInterfaces";

const baseurl = "https://recipeapi-yg.azurewebsites.net/api/"

async function fetchData<T>(url: string): Promise<T> {
    url = baseurl + url;
    const r = await fetch(url);
    const data = await r.json();

    return data;
}

export async function fetchCuisine() {
    return await fetchData<ICuisine[]>("cuisine");
}

export async function fetchRecipesByCuisineId(cuisineId: number) {
    return await fetchData<IRecipe[]>(`Recipe/getbycuisine//${cuisineId}`);
}