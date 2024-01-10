import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActiveAdvertisementsComponent } from './active-advertisements.component';

describe('ActiveAdvertisementsComponent', () => {
  let component: ActiveAdvertisementsComponent;
  let fixture: ComponentFixture<ActiveAdvertisementsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActiveAdvertisementsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ActiveAdvertisementsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
