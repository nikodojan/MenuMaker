import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GroceryInfoModalComponent } from './grocery-info-modal.component';

describe('GroceryInfoModalComponent', () => {
  let component: GroceryInfoModalComponent;
  let fixture: ComponentFixture<GroceryInfoModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GroceryInfoModalComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GroceryInfoModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
