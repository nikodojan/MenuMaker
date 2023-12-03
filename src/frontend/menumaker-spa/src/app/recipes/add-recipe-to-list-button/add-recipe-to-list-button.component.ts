import { Component, Input } from '@angular/core';
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

export interface AddButtonOptions {
  class: string,
  text: string
}

@Component({
  selector: 'add-recipe-to-list-button',
  standalone: true,
  imports: [
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
  templateUrl: './add-recipe-to-list-button.component.html',
  styleUrl: './add-recipe-to-list-button.component.scss'
})
export class AddRecipeToListButtonComponent {
  constructor(
    public dialog: MatDialog,
    private appStateService : AppstateService){
    }

    @Input()
    recipeId : number = 0;

    @Input()
    recipeTitle: string = "";

    @Input()
    options: AddButtonOptions = {
      class: "btn btn-primary btn-sm",
      text: "Add to list"
    };
    
    addButtonClicked(){
      this.openDialog(this.recipeId, this.recipeTitle);
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
