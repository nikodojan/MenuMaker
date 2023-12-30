import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GroceriespageComponent } from './groceriespage.component';

describe('GroceriespageComponent', () => {
  let component: GroceriespageComponent;
  let fixture: ComponentFixture<GroceriespageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GroceriespageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GroceriespageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
