import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl } from '@angular/forms';

import { TopicService } from 'src/app/services/topic.service';

@Component({
  selector: 'app-create-topic',
  templateUrl: './create-topic.component.html',
  styleUrls: ['./create-topic.component.css']
})
export class CreateTopicComponent {

  createTopicForm!: FormGroup;

  constructor(private topicService: TopicService) { }

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
    const topictitle = this.createTopicForm.get('topictitle')?.value;
    const topiccontent = this.createTopicForm.get('topiccontent')?.value;
    
    // console.log(topictitle,topiccontent);

    this.topicService.createTopic(topictitle, topiccontent);
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
