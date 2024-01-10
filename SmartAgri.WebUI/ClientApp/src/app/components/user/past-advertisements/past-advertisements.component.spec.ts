import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PastAdvertisementsComponent } from './past-advertisements.component';

describe('PastAdvertisementsComponent', () => {
  let component: PastAdvertisementsComponent;
  let fixture: ComponentFixture<PastAdvertisementsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PastAdvertisementsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PastAdvertisementsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
