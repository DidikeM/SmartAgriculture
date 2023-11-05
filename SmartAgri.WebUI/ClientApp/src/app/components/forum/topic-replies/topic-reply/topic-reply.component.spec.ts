import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TopicReplyComponent } from './topic-reply.component';

describe('TopicReplyComponent', () => {
  let component: TopicReplyComponent;
  let fixture: ComponentFixture<TopicReplyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TopicReplyComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TopicReplyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
