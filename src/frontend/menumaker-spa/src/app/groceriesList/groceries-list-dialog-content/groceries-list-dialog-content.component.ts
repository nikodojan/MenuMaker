import { Component } from '@angular/core';
import { AppstateService } from '../../services/appstate.service';
import { GroceriesListService } from '../../services/groceries-list.service';
import { AsyncPipe } from '@angular/common';
import { GroceriesListItem } from '../../types/dtoTypes';
import { Observable } from 'rxjs';

@Component({
  selector: 'groceries-list-dialog-content',
  standalone: true,
  imports: [AsyncPipe],
  templateUrl: './groceries-list-dialog-content.component.html',
  styleUrl: './groceries-list-dialog-content.component.scss'
})
export class GroceriesListDialogContentComponent {
  constructor(
    private stateService : AppstateService, 
    private groceriesListService : GroceriesListService) {}

  groceriesList : Observable<GroceriesListItem[]> = this.stateService.getGroceriesList();
}