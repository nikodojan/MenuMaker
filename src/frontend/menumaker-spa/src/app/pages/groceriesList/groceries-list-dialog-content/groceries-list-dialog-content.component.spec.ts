import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GroceriesListDialogContentComponent } from './groceries-list-dialog-content.component';

describe('GroceriesListDialogContentComponent', () => {
  let component: GroceriesListDialogContentComponent;
  let fixture: ComponentFixture<GroceriesListDialogContentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GroceriesListDialogContentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GroceriesListDialogContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
