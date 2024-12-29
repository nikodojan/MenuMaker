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
  class?: string,
  text?: string,
  portions?: number
}

@Component({
    selector: 'add-recipe-to-list-button',
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
        MatDialogClose
    ],
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
    options: AddButtonOptions = {};

    ngOnInit() {
      console.log(this.options);
      this.options = {
        class: this.options.class ? this.options.class : "btn btn-primary btn-sm",
        text: this.options.text ? this.options.text : "Add to list",
        portions: this.options.portions ? this.options.portions : 2
      }
    }
    
    addButtonClicked(){
      this.openDialog(this.recipeId, this.recipeTitle);
    }
  
    openDialog(id : number, title : string): void {
      const dialogRef = this.dialog.open(AddRecipeToMenuDialogComponent, {
        data: {portions: this.options.portions},
      });
  
      dialogRef.afterClosed().subscribe(result => {
        let portions = result;
        this.appStateService.addSelectedRecipe(id, title, portions)
      });
    }
}
