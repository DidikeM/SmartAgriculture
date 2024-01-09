import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BuyCreditComponent } from './buy-credit.component';

describe('BuyCreditComponent', () => {
  let component: BuyCreditComponent;
  let fixture: ComponentFixture<BuyCreditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BuyCreditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BuyCreditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
