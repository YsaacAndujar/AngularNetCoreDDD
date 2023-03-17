import { TestBed } from '@angular/core/testing';

import { BrandsapiService } from './brandsapi.service';

describe('BrandsapiService', () => {
  let service: BrandsapiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BrandsapiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
