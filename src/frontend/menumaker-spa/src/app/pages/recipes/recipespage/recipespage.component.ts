import { Component } from '@angular/core';
import { CommonModule, NgIf } from '@angular/common';
import { RecipesService } from '../../../services/recipes-service.service';
import { Recipe } from '../../../common/types/dto-types';
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
import { AppstateService } from '../../../services/appstate.service';

@Component({
  selector: 'recipespage',
  standalone: true,
  imports: [
    CommonModule,
    NgIf,
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

  isLoading : boolean = true;
  loadingError: string = '';

  async ngOnInit(){
    this.recipesService
      .getRecipes()
      .subscribe({
        next: (response) => {
          this.recipesList = response;
          this.isLoading = false;
        },
        error: (error) => {
          this.recipesList = []
          this.isLoading = false;
          this.loadingError = 'Recipes could not be loaded. Please try again in a minute.';
          console.error(error)
        },
        complete: () => {} 
      }
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
      let portions = result;
      this.appStateService.addSelectedRecipe(id, title, portions)
    });
  }
}
