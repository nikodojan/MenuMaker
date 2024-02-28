import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, retry, catchError, throwError } from 'rxjs';
import { Recipe } from '../common/types/dto-types';

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
      return this.httpClient.get<Recipe[]>(this.baseUrl + query)
      .pipe(
        retry(2),
        catchError(this.handleError)
      );
  }

  getRecipeById(id: number) : Observable<Recipe> {
    return this.httpClient.get<Recipe>(this.baseUrl + '/' + id);
  }

  createRecipe(recipe: Recipe) : Observable<Recipe> {
    return this.httpClient.post<Recipe>(
      this.baseUrl, 
      recipe, 
      {
        headers: {
          'x-api-key': environment.apiKey
      }
    });
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    // Return an observable with a user-facing error message.
    return throwError(() => new Error('An error occured while loading the recipes; please try again.'));
  }

}
