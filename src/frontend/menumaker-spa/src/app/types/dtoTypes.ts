export interface GroceriesListRequestObject {
  recipeId: number,
  portions: number
}

export interface GroceriesListItem {
  groceryName: string,
  amount: number,
  unit: string,
  category: string
}