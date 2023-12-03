import { TestBed } from '@angular/core/testing';

import { GroceriesListService } from './groceries-list.service';

describe('GroceriesListService', () => {
  let service: GroceriesListService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GroceriesListService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
