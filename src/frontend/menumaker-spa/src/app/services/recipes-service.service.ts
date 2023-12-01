import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Recipe } from '../types/recipeTypes';

@Injectable({
  providedIn: 'root'
})
export class RecipesService {

  constructor(private httpClient : HttpClient) { }

  baseUrl : string =  environment.apiBaseUrl + '/v1/recipes';
  
  getRecipes(
    includeIngredients : boolean = false, 
    skip: number = 0, 
    take: number = 0): Observable<Recipe[]> { 
    const query = `?includeIngredients=${includeIngredients}&skip=${skip}&take=${take}`;
    return this.httpClient.get<Recipe[]>(this.baseUrl + query);
  }

}
