import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Topic } from '../models/topic';

@Injectable({
    providedIn: 'root',
})

export class TopicService {
    private apiUrl = 'http://localhost:61098/form'; 

    constructor(private http: HttpClient){}

    getTopics(){
        return this.http.get<Topic[]>(`${this.apiUrl}/topics`);
    }

    createTopic(title: string, content: string){
        const topicData: Topic = {
            userId: 1,
            title: title,
            content: content
        }
 
        // console.log(topicData);

        this.http.post<Topic>(`${this.apiUrl}/createtopic`, topicData)
        .subscribe((responseData) => {
            console.log(responseData);
        });
    }
}
