import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecentAdvertsComponent } from './recent-adverts.component';

describe('RecentAdvertsComponent', () => {
  let component: RecentAdvertsComponent;
  let fixture: ComponentFixture<RecentAdvertsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RecentAdvertsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RecentAdvertsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
