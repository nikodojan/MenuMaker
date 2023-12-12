import { Component } from '@angular/core';
import { AppstateService } from '../../services/appstate.service';
import { AsyncPipe } from '@angular/common';
import { GroceriesListItem } from '../../types/dtoTypes';
import { Observable } from 'rxjs';
import { GroceriesListCategory } from '../../types/appTypes';
import {MatDividerModule} from '@angular/material/divider';
import {ClipboardModule} from '@angular/cdk/clipboard';

@Component({
  selector: 'groceries-list-dialog-content',
  standalone: true,
  imports: [AsyncPipe,MatDividerModule,ClipboardModule],
  templateUrl: './groceries-list-dialog-content.component.html',
  styleUrl: './groceries-list-dialog-content.component.scss'
})
export class GroceriesListDialogContentComponent {
  constructor(
    private stateService : AppstateService) {}

  groceriesList : Observable<GroceriesListItem[]> = this.stateService.getGroceriesList();

  groceriesListSorted : GroceriesListCategory[] = [];

  ngOnInit() {
    this.stateService.getGroceriesList().subscribe(
      groceries => {
        groceries.map(gli=> {
          if (this.groceriesListSorted.find(cat => cat.name === gli.category)){
            this.groceriesListSorted[this.groceriesListSorted.indexOf(this.groceriesListSorted.filter(i=>i.name === gli.category)[0])].groceries.push(gli);
          } else {
            const newCat : GroceriesListCategory = {
              name: gli.category,
              groceries: [gli]
            }
            this.groceriesListSorted.push(newCat);
          }
        })
      }
    )
  }

  // getGroceriesListForCopy() : string {
  //   let text : string = '';

  //   for (let cat of this. groceriesListSorted){
  //     text += cat.name + '\n';
  //     for (let grocery of cat.groceries){
  //       text += this.formatGroceryLine(grocery);  
  //     }
  //   }

  //   return text;
  // }

  // formatGroceryLine(grocery : GroceriesListItem) : string{
  //   return grocery.amount + '\t' + grocery.unit + '\t' + grocery.groceryName;
  // }
}
