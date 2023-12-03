import { Component, Input } from '@angular/core';
import { Recipe } from '../../types/recipeTypes';
import { ActivatedRoute } from '@angular/router';
import { RecipesService } from '../../services/recipes-service.service';
import { AddRecipeToListButtonComponent } from '../add-recipe-to-list-button/add-recipe-to-list-button.component';

@Component({
  selector: 'recipe',
  standalone: true,
  imports: [AddRecipeToListButtonComponent],
  templateUrl: './recipe.component.html',
  styleUrl: './recipe.component.scss'
})
export class RecipeComponent {
  recipe : Recipe;
  image: string;

  constructor(
    private route: ActivatedRoute,
    private recipesService: RecipesService){
    this.recipe = {} as Recipe;
    this.image = this.recipe?.imgPath ? this.recipe?.imgPath : '../../../assets/images/donut.png';
  }

  ngOnInit() {
    let id : number = this.route.snapshot.params['id'];
    this.recipesService.getRecipeById(id).subscribe(response => {
      this.recipe = response;
    });
  }
}
