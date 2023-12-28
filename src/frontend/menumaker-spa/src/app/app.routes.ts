import { Routes } from '@angular/router';
import { HomepageComponent } from './home/homepage/homepage.component';
import { AboutpageComponent } from './aboutpage/aboutpage.component';

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
  },
  {
    path: 'about',
    loadComponent: () => 
      import('./aboutpage/aboutpage.component').then(mod=>mod.AboutpageComponent)
  }
];
