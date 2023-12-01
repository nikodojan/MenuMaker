import { Component } from '@angular/core';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';



@Component({
  selector: 'main-layout',
  standalone: true,
  imports: [MatCardModule, MatButtonModule],
  templateUrl: './main-layout.component.html',
  styleUrl: './main-layout.component.sass'
})
export class MainLayoutComponent {

}
