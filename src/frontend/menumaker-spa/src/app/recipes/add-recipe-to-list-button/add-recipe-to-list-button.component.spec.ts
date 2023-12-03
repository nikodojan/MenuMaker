import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddRecipeToListButtonComponent } from './add-recipe-to-list-button.component';

describe('AddRecipeToListButtonComponent', () => {
  let component: AddRecipeToListButtonComponent;
  let fixture: ComponentFixture<AddRecipeToListButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddRecipeToListButtonComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddRecipeToListButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
