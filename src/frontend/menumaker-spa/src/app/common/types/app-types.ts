import { GroceriesListItem } from "./dto-types"

export interface SelectedRecipe {
  id: number,
  title: string,
  portions: number
}

export interface GroceriesListCategory {
  name: string,
  groceries: GroceriesListItem[]
}