import { Component, Input } from '@angular/core';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';

import { faUser } from '@fortawesome/free-solid-svg-icons';
import { Reply } from 'src/app/models/reply';

@Component({
  selector: 'app-topic-reply',
  templateUrl: './topic-reply.component.html',
  styleUrls: ['./topic-reply.component.css']
})
export class TopicReplyComponent {
  @Input() reply!: Reply;

  faUser = faUser;

  constructor(private sanitizer: DomSanitizer){}

  sanitizeHTML(html: string): SafeHtml {
    return this.sanitizer.bypassSecurityTrustHtml(html);
  }
}
