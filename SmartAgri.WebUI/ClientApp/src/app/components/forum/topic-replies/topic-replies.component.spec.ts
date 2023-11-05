import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TopicRepliesComponent } from './topic-replies.component';

describe('TopicRepliesComponent', () => {
  let component: TopicRepliesComponent;
  let fixture: ComponentFixture<TopicRepliesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TopicRepliesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TopicRepliesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
