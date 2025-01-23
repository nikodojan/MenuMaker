import { Component } from '@angular/core';
import { Grocery, GroceryCategory, Ingredient, Recipe } from '../../../common/types/dto-types';
import { RecipesService } from '../../../services/recipes-service.service';
import { ActivatedRoute } from '@angular/router';
import { GroceriesService } from '../../../services/groceries-service.service';
import { RecipeEditComponent } from '../recipe-edit/recipe-edit.component';

@Component({
    selector: 'edit-recipe-page',
    imports: [RecipeEditComponent],
    templateUrl: './edit-recipe-page.component.html',
    styleUrl: './edit-recipe-page.component.scss'
})
export class EditRecipePageComponent {

  Recipe : Recipe;
  GroceryCategories : GroceryCategory[] = [];

  constructor(
    private route: ActivatedRoute, 
    private recipesService : RecipesService,
    private groceriesService : GroceriesService) {
      this.Recipe = this.getNewRecipe();
    }

    ngOnInit() {    
      let id : number = this.route.snapshot.params['id'];
      console.log(id)
      if (id != null) {
        this.recipesService.getRecipeById(id).subscribe(response => {
          this.Recipe = response;
          console.log(this.Recipe)
        });
      }
      console.log(this.Recipe)
      this.groceriesService.getGroceriesCategories().subscribe(response=> {
        this.GroceryCategories = response;
      })
    }

    private getNewRecipe() : Recipe {
      const dummyGrocery : Grocery = {
        id: 0,
        name: "",
        category: "",
        nutritionFacts: null
      }
      
      const newIngredient : Ingredient = {
        id: 0,
        amount: 0,
        unit: 'g',
        description: null,
        partOfDish: null,
        grocery: dummyGrocery
      }

      const newRecipe : Recipe = {
        id: 0,
        title: "",
        imgPath: null,
        description: null,
        portions: 1,
        timeInMinutes: 0,
        ingredients: [],
        instructions: {"main": []},
        nutritionFacts: null
      }

      return newRecipe;
    }
}
