import { Component } from '@angular/core';
import { RecipesService } from '../../services/recipes-service.service';
import { Recipe } from '../../types/recipeTypes';

import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatGridListModule} from '@angular/material/grid-list';

@Component({
  selector: 'recipespage',
  standalone: true,
  imports: [MatCardModule, MatButtonModule, MatGridListModule],
  templateUrl: './recipespage.component.html',
  styleUrl: './recipespage.component.sass'
})
export class RecipespageComponent {
  constructor(private recipesService : RecipesService){}

  recipesList : Recipe[] = [];

  async ngOnInit(){
    this.recipesService
      .getRecipes()
      .subscribe((recipes) => 
        this.recipesList = recipes
      );
  }
}
