import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GroceriesListDialogComponent } from './groceries-list-dialog.component';

describe('GroceriesListDialogComponent', () => {
  let component: GroceriesListDialogComponent;
  let fixture: ComponentFixture<GroceriesListDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GroceriesListDialogComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GroceriesListDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
