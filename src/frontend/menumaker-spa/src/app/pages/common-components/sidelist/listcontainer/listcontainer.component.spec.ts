import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListcontainerComponent } from './listcontainer.component';

describe('ListcontainerComponent', () => {
  let component: ListcontainerComponent;
  let fixture: ComponentFixture<ListcontainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListcontainerComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ListcontainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
