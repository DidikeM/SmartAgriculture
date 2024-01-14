import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MessageReplyComponent } from './message-reply.component';

describe('MessageReplyComponent', () => {
  let component: MessageReplyComponent;
  let fixture: ComponentFixture<MessageReplyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MessageReplyComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MessageReplyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
