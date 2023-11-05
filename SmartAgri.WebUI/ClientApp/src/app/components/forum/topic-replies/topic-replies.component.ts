import { Component } from '@angular/core';

import { faUser } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-topic-replies',
  templateUrl: './topic-replies.component.html',
  styleUrls: ['./topic-replies.component.css']
})
export class TopicRepliesComponent {
  faUser = faUser;
}
