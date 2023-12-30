import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject, groupBy, map } from 'rxjs';
import { GroceriesListCategory, SelectedRecipe } from '../types/appTypes';
import { GroceriesListItem } from '../types/dtoTypes';

@Injectable({
  providedIn: 'root'
})
export class AppstateService {

  constructor() { 
  }

  private selectedRecipes = new BehaviorSubject<SelectedRecipe[]>([]);
  private currentGroceriesList = new BehaviorSubject<GroceriesListItem[]>([]);

  setGroceriesList(list:any): void {
    this.currentGroceriesList.next(list);
  } 

  getGroceriesList() : Observable<GroceriesListItem[]> {
    return this.currentGroceriesList.asObservable();
  }

  getSelectedRecipes(): Observable<SelectedRecipe[]> {
    return this.selectedRecipes.asObservable();
  }

  addSelectedRecipe(id : number, title : string, portions : number = 0) {
    let selectedR : SelectedRecipe = {
      id: id,
      title: title,
      portions: portions > 0 ? portions : 1
    }
    let current = this.selectedRecipes.value;
    current.push(selectedR);
    this.selectedRecipes.next(current);
  }

  deleteSelectedRecipe(id : number) {
    let current = this.selectedRecipes.value;
    let i = current.findIndex(r=>r.id == id)
    current.splice(i, 1);
    this.selectedRecipes.next(current);
  }

  clearSelectedRecipes() {
    this.selectedRecipes.next([]);
  }

  changeAmountOfSelectedRecipe(id: number, amount: number) {
    let current = this.selectedRecipes.value;
    
    let index = current.findIndex(r=>r.id === id);
    if (index < 0) {return}

    current[index].portions = amount;
    this.selectedRecipes.next(current);
  }
}
