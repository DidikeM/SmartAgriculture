import { Component } from '@angular/core';

@Component({
  selector: 'app-topic-replies',
  templateUrl: './topic-replies.component.html',
  styleUrls: ['./topic-replies.component.css']
})
export class TopicRepliesComponent {
  QuillConfiguration = {
    toolbar: [
      ['bold', 'italic', 'underline', 'strike'],
      ['blockquote', 'code-block'],
      [{ list: 'ordered' }, { list: 'bullet' }],
      [{ 'script': 'sub'}, { 'script': 'super' }], 
      [{ 'indent': '-1'}, { 'indent': '+1' }],
      [{ header: [1, 2, 3, 4, 5, 6, false] }],
      [{ 'align': [] }],
      ['link'],
      ['clean'],
    ],
  }
}
