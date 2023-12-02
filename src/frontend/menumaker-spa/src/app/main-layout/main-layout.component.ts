import { Component } from '@angular/core';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatSidenavModule} from '@angular/material/sidenav';
import { RecipespageComponent } from '../recipes/recipespage/recipespage.component';

@Component({
  selector: 'main-layout',
  standalone: true,
  imports: [MatCardModule, MatButtonModule, MatSidenavModule, RecipespageComponent],
  templateUrl: './main-layout.component.html',
  styleUrl: './main-layout.component.sass'
})
export class MainLayoutComponent {

}
