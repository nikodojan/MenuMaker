import { Grocery } from "./recipeTypes"

export interface SelectedRecipe {
  id: number,
  title: string,
  portions: number
}

export interface GroceryCategoryGrouping {
  name: string,
  groeries: Grocery[]
}