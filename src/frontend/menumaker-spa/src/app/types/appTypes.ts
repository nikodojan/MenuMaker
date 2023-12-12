import { GroceriesListItem } from "./dtoTypes"

export interface SelectedRecipe {
  id: number,
  title: string,
  portions: number
}

export interface GroceriesListCategory {
  name: string,
  groceries: GroceriesListItem[]
}