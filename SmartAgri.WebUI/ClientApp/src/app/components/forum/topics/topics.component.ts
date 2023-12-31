import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { TopicService } from 'src/app/services/topic.service';
import { Topic } from 'src/app/models/topic';

@Component({
  selector: 'app-topics',
  templateUrl: './topics.component.html',
  styleUrls: ['./topics.component.css']
})
export class TopicsComponent {
  topics: Topic[] = []; 
  isFetching = false;

  constructor(private router: Router, private topicService: TopicService) {}
  
  ngOnInit() {
    this.isFetching = true;
    this.topicService.getTopics().subscribe((responseData)=>{
      this.isFetching = false;
      // console.log(responseData)

      this.topics = responseData;

      this.topics.forEach(topic => {
        if (topic.id !== undefined) {
          this.topicService.getReplies(topic.id).subscribe(replies => {
            topic.replyCount = replies.length; 
          });
        }
      });
    });
  }

  navigateToCreateTopic(){
    this.router.navigate(['/forum/createtopic']); 
  }
}
