import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';

import { TopicService } from 'src/app/services/topic.service';

@Component({
  selector: 'app-create-topic',
  templateUrl: './create-topic.component.html',
  styleUrls: ['./create-topic.component.css']
})
export class CreateTopicComponent {
  
  createTopicForm!: FormGroup;

  constructor(private router:Router, private topicService: TopicService) { }

  ngOnInit() {
    this.createTopicForm = new FormGroup({
      'topictitle': new FormControl(null,[Validators.required]),
      'topiccontent': new FormControl(null, [Validators.required])  
    });
  }

  getControl(name:any) : AbstractControl | null{
    return this.createTopicForm.get(name);
  }

  onSubmit() {
    const topicTitle = this.createTopicForm.get('topictitle')?.value;
    const topicContent = this.createTopicForm.get('topiccontent')?.value;

    this.topicService.createTopic(topicTitle, topicContent);
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
