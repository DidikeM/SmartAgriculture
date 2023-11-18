import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { TopicsComponent } from './topics/topics.component';
import { CreateTopicComponent } from './create-topic/create-topic.component';
import { TopicRepliesComponent } from './topic-replies/topic-replies.component';

const routes: Routes = [
  {
    path:'',
    children:[
      { path: 'topics', component: TopicsComponent },
      { path: 'createtopic', component: CreateTopicComponent },
      { path: 'topicreplies', component:  TopicRepliesComponent},
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ForumRoutingModule { }
