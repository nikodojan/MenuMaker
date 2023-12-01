export interface Recipe {
  id: number,
  title: string,
  description: string | null,
  portions: number,
  minutes: number,
  ingredients: Ingredient[] | null
}

export interface Ingredient {
  id: number,
  amount: number,
  unit: string | null,
  description: string | null,
  partOfDish: string | null
  grocery: object
}

export interface Grocery {
  id: number,
  name: string | null,
  category: string | null
  nutritionFacts: NutritionFacts[] | null
}

export interface NutritionFacts {
  referenceAmount: number,
  referenceAmountUnit: string,
  calories: number,
  fat: number,
  carbonhydrates: number,
  sugar: number,
  protein: number,
  fiber: number
}

export interface GroceryCategory {
  id: number, 
  name: string
}
