import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { SelectedRecipe } from '../types/appTypes';

@Injectable({
  providedIn: 'root'
})
export class AppstateService {

  constructor() { 
  }

  private _selectedRecipes$ = new BehaviorSubject<SelectedRecipe[]>([]);
  private _currentGroceriesList$ = new BehaviorSubject<any[]>([]);

  setGroceriesList(list:any): void {
    this._currentGroceriesList$.next(list);
  } 

  getGroceriesList() : Observable<any> {
    return this._currentGroceriesList$.asObservable();
  }

  getSelectedRecipes(): Observable<SelectedRecipe[]> {
    return this._selectedRecipes$.asObservable();
  }

  addSelectedRecipe(id : number, title : string, portions : number = 0) {
    let selectedR : SelectedRecipe = {
      id: id,
      title: title,
      portions: portions > 0 ? portions : 1
    }
    let current = this._selectedRecipes$.value;
    current.push(selectedR);
    console.log(current);
    this._selectedRecipes$.next(current);
  }

  deleteSelectedRecipe(id : number) {
    let current = this._selectedRecipes$.value;
    let i = current.findIndex(r=>r.id == id)
    current.splice(i, 1);
    this._selectedRecipes$.next(current);
  }

  clearSelectedRecipes() {
    this._selectedRecipes$.next([]);
  }

  changeAmountOfSelectedRecipe(id: number, amount: number) {
    let current = this._selectedRecipes$.value;
    
    let index = current.findIndex(r=>r.id === id);
    if (index < 0) {return}

    current[index].portions = amount;
    this._selectedRecipes$.next(current);
  }
}
