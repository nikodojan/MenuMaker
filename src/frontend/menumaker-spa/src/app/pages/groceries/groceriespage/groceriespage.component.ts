import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Grocery } from '../../../common/types/dto-types';
import { GroceriesService } from '../../../services/groceries-service.service';

@Component({
    selector: 'app-groceriespage',
    imports: [],
    templateUrl: './groceriespage.component.html',
    styleUrl: './groceriespage.component.scss'
})
export class GroceriespageComponent {
  constructor(private groceriesService : GroceriesService) {

  }

  groceries : Grocery[] = [];

  ngOnInit() {
    this.groceriesService.getGroceries().subscribe(
      response => {
        this.groceries = response.sort((a: Grocery, b: Grocery) => {
          if (a.name < b.name) {
            return -1
          }
          else {
            return 1
          }
        });
      }
    )
  }
}
