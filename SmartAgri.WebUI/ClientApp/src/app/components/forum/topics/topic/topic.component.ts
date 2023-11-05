import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { faUser } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-topic',
  templateUrl: './topic.component.html',
  styleUrls: ['./topic.component.css']
})
export class TopicComponent {
  faUser = faUser;

  constructor(private router: Router) {}

  navigateToReplyTopic(){
    this.router.navigate(['/forum/topic-replies']); 
  }
}
