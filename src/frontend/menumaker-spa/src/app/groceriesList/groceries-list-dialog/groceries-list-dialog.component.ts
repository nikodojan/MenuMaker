import { Component, Inject } from '@angular/core';
import {
  MatDialog,
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatDialogTitle,
  MatDialogContent,
  MatDialogActions,
  MatDialogClose,
} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { GroceriesListDialogContentComponent } from '../groceries-list-dialog-content/groceries-list-dialog-content.component';

@Component({
  selector: 'groceries-list-dialog',
  standalone: true,
  imports: [   MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatButtonModule,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose,
    GroceriesListDialogContentComponent],
  templateUrl: './groceries-list-dialog.component.html',
  styleUrl: './groceries-list-dialog.component.scss'
})
export class GroceriesListDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<GroceriesListDialogComponent>
  ) {}

  onNoClick(): void {
    this.dialogRef.close();
  }
}
