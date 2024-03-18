import { Component, Input } from '@angular/core';
import { Recipe } from '../../../common/types/dto-types';
import { ActivatedRoute } from '@angular/router';
import { RecipesService } from '../../../services/recipes-service.service';
import { FooterComponent } from '../../../pages/common-components/footer/footer.component';
import { AppstateService } from '../../../services/appstate.service';

import {
  MatDialog,
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatDialogTitle,
  MatDialogContent,
  MatDialogActions,
  MatDialogClose,
} from '@angular/material/dialog';
import { AddRecipeToMenuDialogComponent } from '../add-recipe-to-menu-dialog/add-recipe-to-menu-dialog.component';

@Component({
  selector: 'recipe',
  standalone: true,
  imports: [
    FooterComponent,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose],
  templateUrl: './recipe.component.html',
  styleUrl: './recipe.component.scss'
})
export class RecipeComponent {
  constructor(
    private route: ActivatedRoute,
    private recipesService: RecipesService,
    public dialog: MatDialog,
    private appStateService : AppstateService){
      this.recipe = {} as Recipe;
      this.image = this.recipe?.imgPath ? this.recipe?.imgPath : '../../../assets/images/donut.png';
  }

  recipe : Recipe;
  image: string;
  instructionsKeys: string[] = [];

  ngOnInit() {
    let id : number = this.route.snapshot.params['id'];
    this.recipesService.getRecipeById(id).subscribe(response => {
      this.recipe = response;
      this.instructionsKeys = Object.keys(this.recipe.instructions);
    });
  }

  onPortionsChanged(event: any) {
    if (event.target.value !== this.recipe.portions) {
      let newPortions = event.target.value
      this.changeIngredientAmountsForPortions(newPortions);
      this.recipe.portions = newPortions;
    }
  }

  changeIngredientAmountsForPortions(newPortions : number){
    if (this.recipe.ingredients === null) {return}

    for (let ingredient of this.recipe.ingredients) {
      
      if (!this.recipe.portions || !ingredient.amount) {
        continue;
      }
      let newAmount = ingredient.amount / this.recipe.portions * newPortions;
      this.recipe.ingredients[this.recipe.ingredients.indexOf(ingredient)].amount = newAmount;
    }
  }
  
  addButtonClicked(){
    if (this.recipe.portions < 1) {
      this.recipe.portions = 1
    }
    this.openDialog(this.recipe.id, this.recipe.title, this.recipe.portions);
  }

  openDialog(id : number, title : string, portions: number): void {
    const dialogRef = this.dialog.open(AddRecipeToMenuDialogComponent, {
      data: {portions: portions},
    });

    dialogRef.afterClosed().subscribe(result => {
      let portions = result;
      this.appStateService.addSelectedRecipe(id, title, portions)
    });
  }
}
