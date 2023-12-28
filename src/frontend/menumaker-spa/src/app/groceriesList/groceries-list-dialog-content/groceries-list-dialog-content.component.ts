import { Component, Input } from '@angular/core';
import { AsyncPipe } from '@angular/common';
import { GroceriesListCategory } from '../../types/appTypes';
import { MatDividerModule } from '@angular/material/divider';

@Component({
  selector: 'groceries-list-dialog-content',
  standalone: true,
  imports: [AsyncPipe, MatDividerModule],
  templateUrl: './groceries-list-dialog-content.component.html',
  styleUrl: './groceries-list-dialog-content.component.scss'
})
export class GroceriesListDialogContentComponent {
  constructor() {}

  @Input()
  groceriesListSorted : GroceriesListCategory[] = [];
}
