import { Component } from '@angular/core';
import { AppstateService } from '../../services/appstate.service';
import { AsyncPipe } from '@angular/common';
import { GroceriesListItem } from '../../types/dtoTypes';
import { Observable, groupBy, map } from 'rxjs';
import { GroceriesListCategory } from '../../types/appTypes';


@Component({
  selector: 'groceries-list-dialog-content',
  standalone: true,
  imports: [AsyncPipe],
  templateUrl: './groceries-list-dialog-content.component.html',
  styleUrl: './groceries-list-dialog-content.component.scss'
})
export class GroceriesListDialogContentComponent {
  constructor(
    private stateService : AppstateService) {}

  groceriesList : Observable<GroceriesListItem[]> = this.stateService.getGroceriesList();

  // groceriesListSorted : any = {};

  // ngOnInit() {
  //   this.stateService.getGroceriesList().subscribe(
  //     groceries => {
  //       groceries.map(g=> {
  //         if (this.groceriesListSorted[g.category]){
  //           let arr : GroceriesListItem[] = this.groceriesListSorted[g.category];
  //           arr.push(g);
  //           this.groceriesListSorted[g.category] = arr;
  //         } else {
  //           this.groceriesListSorted[g.category] = [g];
  //         }
  //       })
  //     }
  //   )
  // }
}
