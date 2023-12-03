import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { SelectedRecipe } from '../types/appTypes';
import {GroceriesListRequestObject, GroceriesListItem} from '../types/dtoTypes';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GroceriesListService {

  baseUrl : string =  environment.apiBaseUrl + '/v1/grocerieslists';

  constructor(private httpClient : HttpClient) { }

  getGroceriesListForMenu(recipes : SelectedRecipe[]) : Observable<GroceriesListItem[]>{
    const requestData: GroceriesListRequestObject[] = [];
    for (let set of recipes) {
      requestData.push({
        recipeId: set.id,
        portions: set.portions
      })
    }

    return this.httpClient.post<GroceriesListItem[]>(this.baseUrl, requestData );
  }
}
