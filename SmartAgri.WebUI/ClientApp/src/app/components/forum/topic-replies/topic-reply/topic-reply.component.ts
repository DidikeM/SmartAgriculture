import { Component } from '@angular/core';

import { faUser } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-topic-reply',
  templateUrl: './topic-reply.component.html',
  styleUrls: ['./topic-reply.component.css']
})
export class TopicReplyComponent {
  faUser = faUser;
}
