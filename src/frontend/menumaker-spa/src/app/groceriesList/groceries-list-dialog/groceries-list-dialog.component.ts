import { Component, Inject } from '@angular/core';
import {
  MatDialog,
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatDialogTitle,
  MatDialogContent,
  MatDialogActions,
  MatDialogClose,
} from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { GroceriesListDialogContentComponent } from '../groceries-list-dialog-content/groceries-list-dialog-content.component';
import { MatIconModule } from '@angular/material/icon';
import { AppstateService } from '../../services/appstate.service';
import { Observable } from 'rxjs';
import { GroceriesListItem } from '../../types/dtoTypes';
import { GroceriesListCategory } from '../../types/appTypes';
import { ClipboardModule } from '@angular/cdk/clipboard';
import { MatTooltipModule } from '@angular/material/tooltip';

@Component({
  selector: 'groceries-list-dialog',
  standalone: true,
  imports: [   MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatButtonModule,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose,
    GroceriesListDialogContentComponent,
    MatIconModule,
    ClipboardModule,
    MatTooltipModule],
  templateUrl: './groceries-list-dialog.component.html',
  styleUrl: './groceries-list-dialog.component.scss'
})
export class GroceriesListDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<GroceriesListDialogComponent>,
    private stateService : AppstateService
  ) {}

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

  getGroceriesListForCopy() : string {
    let text : string = '';

    for (let cat of this. groceriesListSorted){
      let catLine = cat.name + '\n';

      if (this.groceriesListSorted.indexOf(cat) !== 0){
        catLine = '\n' + catLine;
      }

      text += catLine;
      for (let grocery of cat.groceries){
        text += this.formatGroceryLine(grocery) + '\n';  
      }
    }

    return text;
  }

  formatGroceryLine(grocery : GroceriesListItem) : string{
    return (grocery.amount ? grocery.amount : '') + '\t' + grocery.unit + '\t' + grocery.groceryName;
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
