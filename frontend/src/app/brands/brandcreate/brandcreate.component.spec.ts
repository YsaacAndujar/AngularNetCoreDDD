import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BrandcreateComponent } from './brandcreate.component';

describe('BrandcreateComponent', () => {
  let component: BrandcreateComponent;
  let fixture: ComponentFixture<BrandcreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BrandcreateComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BrandcreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
