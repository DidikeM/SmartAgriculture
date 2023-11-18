import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';

import { faUser } from '@fortawesome/free-solid-svg-icons';
import { Topic } from 'src/app/models/topic';

@Component({
  selector: 'app-topic',
  templateUrl: './topic.component.html',
  styleUrls: ['./topic.component.css']
})
export class TopicComponent {
  @Input() topics: Topic[] = []; 

  faUser = faUser;

  constructor(private router: Router, private sanitizer: DomSanitizer) {}

  navigateToReplyTopic(){
    this.router.navigate(['/forum/topicreplies']); 
  }

  sanitizeHTML(html: string): SafeHtml {
    return this.sanitizer.bypassSecurityTrustHtml(html);
  }
  
}
