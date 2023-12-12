import { Component } from '@angular/core';
import { AppstateService } from '../../services/appstate.service';
import { AsyncPipe } from '@angular/common';
import { ListitemComponent } from '../listitem/listitem.component';
import { GroceriesListService } from '../../services/groceries-list.service';

import {
  MatDialog,
  MatDialogTitle,
  MatDialogContent,
  MatDialogActions,
  MatDialogClose,
} from '@angular/material/dialog';
import { GroceriesListDialogComponent } from '../../groceriesList/groceries-list-dialog/groceries-list-dialog.component';

@Component({
  selector: 'listcontainer',
  standalone: true,
  imports: [
    AsyncPipe, 
    ListitemComponent,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose,
    GroceriesListDialogComponent
  ],
  templateUrl: './listcontainer.component.html',
  styleUrl: './listcontainer.component.scss'
})
export class ListcontainerComponent {
  constructor(
    private stateService : AppstateService, 
    private groceriesListService : GroceriesListService,
    public dialog: MatDialog){}

  recipes = this.stateService.getSelectedRecipes();

  delete(id: number) {
    this.stateService.deleteSelectedRecipe(id);
  }

  clearList() {
    this.stateService.clearSelectedRecipes();
  }

  onGetList(){
    this.recipes.subscribe(selectedRecipes => {
      this.groceriesListService.getGroceriesListForMenu(selectedRecipes)
      .subscribe(data => {
        this.stateService.setGroceriesList(data);
        this.openDialog();
      })
    }).unsubscribe()
  }

  openDialog(): void {
    this.dialog.open(GroceriesListDialogComponent);
  }
}



