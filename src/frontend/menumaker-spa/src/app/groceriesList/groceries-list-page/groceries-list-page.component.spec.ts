import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GroceriesListPageComponent } from './groceries-list-page.component';

describe('GroceriesListPageComponent', () => {
  let component: GroceriesListPageComponent;
  let fixture: ComponentFixture<GroceriesListPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GroceriesListPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GroceriesListPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
