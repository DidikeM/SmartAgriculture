import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { ForumRoutingModule } from './forum-routing.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { TopicsComponent } from './topics/topics.component';
import { TopicComponent } from './topics/topic/topic.component';
import { CreateTopicComponent } from './create-topic/create-topic.component';
import { TopicRepliesComponent } from './topic-replies/topic-replies.component';
import { TopicReplyComponent } from './topic-replies/topic-reply/topic-reply.component';
import { QuillModule } from 'ngx-quill'
import { ConcatenatePipe } from './concatenate.pipe';

@NgModule({
  declarations: [
    TopicsComponent,
    CreateTopicComponent,
    TopicComponent,
    TopicRepliesComponent,
    TopicReplyComponent,
    ConcatenatePipe
  ],
  imports: [
    CommonModule,
    ForumRoutingModule,
    ReactiveFormsModule,
    QuillModule.forRoot(),
    FontAwesomeModule
  ]
})
export class ForumModule { }

