import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarmodeldetailsComponent } from './carmodeldetails.component';

describe('CarmodeldetailsComponent', () => {
  let component: CarmodeldetailsComponent;
  let fixture: ComponentFixture<CarmodeldetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarmodeldetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarmodeldetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
