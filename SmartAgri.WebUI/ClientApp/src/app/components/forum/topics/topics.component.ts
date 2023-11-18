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
  isfetching = false;
  constructor(private router: Router, private topicService: TopicService) {}
  
  ngOnInit() {
    this.isfetching = true;
    this.topicService.getTopics().subscribe((responseData)=>{
      this.isfetching = false;
      console.log(responseData);
      this.topics = responseData;
    })
  }

  navigateToCreateTopic(){
    this.router.navigate(['/forum/createtopic']); 
  }
}
