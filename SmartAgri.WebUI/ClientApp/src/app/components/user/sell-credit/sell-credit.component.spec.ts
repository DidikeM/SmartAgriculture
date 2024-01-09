import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SellCreditComponent } from './sell-credit.component';

describe('SellCreditComponent', () => {
  let component: SellCreditComponent;
  let fixture: ComponentFixture<SellCreditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SellCreditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SellCreditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
