import { Component } from '@angular/core';
import { AppstateService } from '../../services/appstate.service';
import { GroceriesListService } from '../../services/groceries-list.service';
import { GroceriesListItem } from '../../common/types/dtoTypes';

@Component({
    selector: 'groceries-list-page',
    imports: [],
    templateUrl: './groceries-list-page.component.html',
    styleUrl: './groceries-list-page.component.scss'
})
export class GroceriesListPageComponent {
  constructor(
    private stateService : AppstateService, 
    private groceriesListService : GroceriesListService) {}

}
