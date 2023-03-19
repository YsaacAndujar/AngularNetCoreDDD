import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarmodelcreateComponent } from './carmodelcreate.component';

describe('CarmodelcreateComponent', () => {
  let component: CarmodelcreateComponent;
  let fixture: ComponentFixture<CarmodelcreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarmodelcreateComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarmodelcreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
