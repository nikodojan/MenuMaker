import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecipespageComponent } from './recipespage.component';

describe('RecipespageComponent', () => {
  let component: RecipespageComponent;
  let fixture: ComponentFixture<RecipespageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RecipespageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RecipespageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
