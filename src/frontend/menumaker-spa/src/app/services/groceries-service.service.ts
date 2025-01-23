import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { catchError, retry, throwError } from 'rxjs';
import { Grocery, GroceryCategory } from '../common/types/dto-types';

@Injectable({
  providedIn: 'root'
})
export class GroceriesService {

  constructor(private httpClient : HttpClient) { }

  baseUrl: string = environment.apiBaseUrl;
  groceriesUrl : string = this.baseUrl + '/v1/groceries';
  groceriesCategoriesUrl : string = this.baseUrl + '/v1/groceries/categories';

  getGroceries() {
    return this.httpClient.get<Grocery[]>(this.groceriesUrl)
      .pipe(
        retry(2),
        catchError(this.handleError)
      );
  };

  getGroceriesCategories() {
    return this.httpClient.get<GroceryCategory[]>(this.groceriesCategoriesUrl)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
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
