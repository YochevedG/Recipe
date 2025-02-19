export interface ICuisine {
    cuisineId: number;
    cuisineType: string;
    errorMessage: string;
}

export interface IRecipe {
    recipeId: number;
    cuisineId: number;
    usersId: number;
    recipeName: string;
    draftedDate: Date;
    publishedDate: Date | null;
    //archivedDate: Date | null;
    calories: number;
    vegan: string;
    errorMessage: string;
}


export interface IUsers {
    usersId: number;
    lastName: string;
}