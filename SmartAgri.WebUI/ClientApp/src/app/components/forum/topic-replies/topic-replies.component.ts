import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

import { Reply } from 'src/app/models/reply';
import { TopicService } from 'src/app/services/topic.service';

@Component({
  selector: 'app-topic-replies',
  templateUrl: './topic-replies.component.html',
  styleUrls: ['./topic-replies.component.css']
})
export class TopicRepliesComponent {
  isFetching = false;

  topicId?: number;
  replies: Reply[] = [];
  
  replyTopicForm!: FormGroup;
  loadingReplies: boolean = true;

  constructor(private route: ActivatedRoute, private topicService: TopicService) {}

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.topicId = +params['id'];
      // console.log(this.topicId);

      if (this.topicId) {
        this.loadReplies();
      }
    });

    this.replyTopicForm = new FormGroup({
      'replyText': new FormControl(null, [Validators.required])  
    });
  }

  loadReplies() {
    this.isFetching = true; 

    this.topicService.getReplies(this.topicId!).subscribe(replies => {
      // console.log(replies);
      this.replies = replies;
      this.isFetching = false; 
    });
  }

  getControl(name:any) : AbstractControl | null{
    return this.replyTopicForm.get(name);
  }

  onSubmit() {
    const replyText = this.replyTopicForm.get('replyText')?.value;
    
    // console.log(replyText);

    this.topicService.createReply(replyText,this.topicId!);
  }

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
