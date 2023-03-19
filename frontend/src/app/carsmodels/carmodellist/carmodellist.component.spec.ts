import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarmodellistComponent } from './carmodellist.component';

describe('CarmodellistComponent', () => {
  let component: CarmodellistComponent;
  let fixture: ComponentFixture<CarmodellistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarmodellistComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarmodellistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
