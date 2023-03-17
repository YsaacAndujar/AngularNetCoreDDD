import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarsmodelsComponent } from './carsmodels.component';

describe('CarsmodelsComponent', () => {
  let component: CarsmodelsComponent;
  let fixture: ComponentFixture<CarsmodelsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarsmodelsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarsmodelsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
