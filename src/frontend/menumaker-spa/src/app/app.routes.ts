import { Routes } from '@angular/router';
import { HomepageComponent } from './home/homepage/homepage.component';
import { AboutpageComponent } from './aboutpage/aboutpage.component';
import { GroceriespageComponent } from './groceries/groceriespage/groceriespage.component';

export const routes: Routes = [
  {
    path: '',
    component: HomepageComponent
  },
  {
    path: 'recipes',
    loadComponent: () => 
      import('./recipes/recipespage/recipespage.component').then(comp=>comp.RecipespageComponent)
  },
  {
    path: 'recipes/:id',
    loadComponent: () => 
      import('./recipes/recipe/recipe.component').then(comp=>comp.RecipeComponent)
  },
  {
    path: 'about',
    loadComponent: () => 
      import('./aboutpage/aboutpage.component').then(comp=>comp.AboutpageComponent)
  },
  {
    path: 'groceries',
    loadComponent: () => 
      import('./groceries/groceriespage/groceriespage.component').then(comp=>comp.GroceriespageComponent)
  }
];
