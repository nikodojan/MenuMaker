import { Component } from '@angular/core';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatSidenavModule} from '@angular/material/sidenav';
import { RecipespageComponent } from '../recipes/recipespage/recipespage.component';
import { ListcontainerComponent } from '../sidelist/listcontainer/listcontainer.component';
import { RouterOutlet, RouterLink } from '@angular/router';

@Component({
  selector: 'main-layout',
  standalone: true,
  imports: [RouterOutlet, RouterLink, MatCardModule, MatButtonModule, MatSidenavModule, RecipespageComponent, ListcontainerComponent],
  templateUrl: './main-layout.component.html',
  styleUrl: './main-layout.component.scss'
})
export class MainLayoutComponent {

}