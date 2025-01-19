export interface ICuisine {
    cuisineId: number;
    cuisineType: string;
}

export interface IRecipe {
    recipeId: number;
    cuisineId: number;
    userId: number;
    recipeName: number;
    draftedDate: Date;
    publishedDate: Date | null;
    archivedDate: Date | null;
    calories: number;
    currentStatus: string;
    recipePic: string;
    vegan: string;
}