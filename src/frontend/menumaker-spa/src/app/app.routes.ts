import { Routes } from '@angular/router';
import { HomepageComponent } from './home/homepage/homepage.component';

export const routes: Routes = [
  {
    path: '',
    component: HomepageComponent
  },
  {
    path: 'recipes',
    loadComponent: () => 
      import('./recipes/recipespage/recipespage.component').then(mod=>mod.RecipespageComponent)
  },
  {
    path: 'recipes/:id',
    loadComponent: () => 
      import('./recipes/recipe/recipe.component').then(mod=>mod.RecipeComponent)
  }
];
