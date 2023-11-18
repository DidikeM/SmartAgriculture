import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-topics',
  templateUrl: './topics.component.html',
  styleUrls: ['./topics.component.css']
})
export class TopicsComponent {

  constructor(private router: Router) {}

  navigateToCreateTopic(){
    this.router.navigate(['/forum/createtopic']); 
  }
}
