export interface Recipe {
  id: number,
  title: string,
  imgPath: string | null,
  description: string | null,
  portions: number,
  timeInMinutes: number,
  ingredients: Ingredient[] | null,
  instructions: string,
  nutritionFacts: NutritionFacts | null
}

export interface Ingredient {
  id: number,
  amount: number | null,
  unit: string | null,
  description: string | null,
  partOfDish: string | null
  grocery: Grocery
}

export interface Grocery {
  id: number,
  name: string,
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
