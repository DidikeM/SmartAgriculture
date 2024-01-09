import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WithdrawCreditComponent } from './withdraw-credit.component';

describe('WithdrawCreditComponent', () => {
  let component: WithdrawCreditComponent;
  let fixture: ComponentFixture<WithdrawCreditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WithdrawCreditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WithdrawCreditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
