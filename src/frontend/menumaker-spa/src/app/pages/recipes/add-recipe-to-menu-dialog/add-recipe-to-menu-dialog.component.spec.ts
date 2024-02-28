import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddRecipeToMenuDialogComponent } from './add-recipe-to-menu-dialog.component';

describe('AddRecipeToMenuDialogComponent', () => {
  let component: AddRecipeToMenuDialogComponent;
  let fixture: ComponentFixture<AddRecipeToMenuDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddRecipeToMenuDialogComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddRecipeToMenuDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
