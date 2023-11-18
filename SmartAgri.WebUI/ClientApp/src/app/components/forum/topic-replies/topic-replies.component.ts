import { Component } from '@angular/core';

import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-topic-replies',
  templateUrl: './topic-replies.component.html',
  styleUrls: ['./topic-replies.component.css']
})
export class TopicRepliesComponent {

  replyTopicForm!: FormGroup;

  ngOnInit() {
    this.replyTopicForm = new FormGroup({
      'replyText': new FormControl(null, [Validators.required])  
    });
  }

  getControl(name:any) : AbstractControl | null{
    return this.replyTopicForm.get(name);
  }

  onSubmit() {
    const replyText = this.replyTopicForm.get('replyText')?.value;
    
    console.log(replyText);
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
