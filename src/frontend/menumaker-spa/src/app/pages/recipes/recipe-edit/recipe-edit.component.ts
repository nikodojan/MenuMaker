import { Component, Input } from '@angular/core';
import { GroceryCategory, NewRecipeModel, Recipe } from '../../../common/types/dto-types';
import { ActivatedRoute } from '@angular/router';
import { Observable, map } from 'rxjs';
import { RecipesService } from '../../../services/recipes-service.service';
import { ReactiveFormsModule , FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';


@Component({
    selector: 'recipe-edit',
    imports: [ReactiveFormsModule],
    templateUrl: './recipe-edit.component.html',
    styleUrl: './recipe-edit.component.scss'
})
export class RecipeEditComponent {
  
  @Input() 
  Recipe : Recipe | null = null;

  // @Input()
  // GroceryCategories : GroceryCategory[] = [];

  recipeForm : FormGroup;

  constructor( 
    private recipesService : RecipesService,
    private formBuilder: FormBuilder){
      this.recipeForm = this.formBuilder.group({
        title:['', [Validators.required]],
        imgPath: [''],
        description: [''],
        timeinminutes: [1, [Validators.required]],
        portions: [1, [Validators.required]],
        ingredients: this.formBuilder.array([
          this.formBuilder.group({
            amount: [0],
            unit: [''],
            description: [''], 
            part: [''], 
            groceryname: ['', [Validators.required]]
          })
        ])
        // instructions: this.formBuilder.array([
        //   this.formBuilder.group({
        //     part: ['main', [Validators.required]],
        //     steps: this.formBuilder.array([
        //       this.formBuilder.control({
        //         step: ['', [Validators.required]]
        //       })
        //     ])
        //   })
        // ])
      });
      // create form group
  }

  ngOnInit() {
    if (this.Recipe == null){
      throw new TypeError("The input 'Recipe' is required");
    }
    console.log(this.Recipe)
    this.recipeForm.value.title = this.Recipe.title;
    this.recipeForm.value.imgPath = this.Recipe.imgPath;
    this.recipeForm.value.description = this.Recipe.description;
    this.recipeForm.value.timeinminutes = this.Recipe.timeInMinutes;

    this.Recipe.ingredients?.forEach(ingr => {
      this.recipeForm.value.ingredients.push(this.formBuilder.group({
        amount: [ingr.amount],
            unit: [ingr.unit],
            description: [ingr.description], 
            part: [ingr.partOfDish], 
            groceryname: [ingr.grocery.name, [Validators.required]]
      }))
    });

  }

  onSubmit() {
    console.log(this.recipeForm);
  }

  // methods to add ingredients and parts
  // methods to add instructions and part

}
