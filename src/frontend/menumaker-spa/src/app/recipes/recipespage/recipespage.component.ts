import { Component } from '@angular/core';
import { RecipesService } from '../../services/recipes-service.service';
import { Recipe } from '../../types/recipeTypes';
import { RouterLink } from '@angular/router';

import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatGridListModule} from '@angular/material/grid-list';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';

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
import { AppstateService } from '../../services/appstate.service';

@Component({
  selector: 'recipespage',
  standalone: true,
  imports: [
    RouterLink,
    MatCardModule,
    MatButtonModule, 
    MatGridListModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatButtonModule,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose],
  templateUrl: './recipespage.component.html',
  styleUrl: './recipespage.component.scss'
})
export class RecipespageComponent {
  constructor(
    private recipesService : RecipesService, 
    public dialog: MatDialog,
    private appStateService : AppstateService){}

  recipesList : Recipe[] = [];
  imgNotAvailable : string = '../../../assets/images/donut.png';
    repeater : number[] = [1,2,3,4,5,6];

  async ngOnInit(){
    this.recipesService
      .getRecipes()
      .subscribe((recipes) => 
        this.recipesList = recipes
      );
  }

  addButtonClicked(id: number, title: string){
    this.openDialog(id, title);
  }

  openDialog(id : number, title : string): void {
    const dialogRef = this.dialog.open(AddRecipeToMenuDialogComponent, {
      data: {portions: 2},
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      let portions = result;
      this.appStateService.addSelectedRecipe(id, title, portions)
    });
  }
}