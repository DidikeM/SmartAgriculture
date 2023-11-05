import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GeneralLayoutComponent } from './general-layout.component';

describe('GeneralLayoutComponent', () => {
  let component: GeneralLayoutComponent;
  let fixture: ComponentFixture<GeneralLayoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GeneralLayoutComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GeneralLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
