import { Routes } from '@angular/router';
import { HomepageComponent } from './pages/homepage/homepage.component';

export const routes: Routes = [
  {
    path: '',
    component: HomepageComponent
  },
  {
    path: 'recipes',
    loadComponent: () => 
      import('./pages/recipes/recipespage/recipespage.component').then(comp=>comp.RecipespageComponent)
  },
  {
    path: 'recipes/:id',
    loadComponent: () => 
      import('./pages/recipes/recipe/recipe.component').then(comp=>comp.RecipeComponent)
  },
  {
    path: 'about',
    loadComponent: () => 
      import('./pages/aboutpage/aboutpage.component').then(comp=>comp.AboutpageComponent)
  },
  {
    path: 'groceries',
    loadComponent: () => 
      import('./pages/groceries/groceriespage/groceriespage.component').then(comp=>comp.GroceriespageComponent)
  }
];
