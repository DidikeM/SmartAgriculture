import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Topic } from '../models/topic';
import { Reply } from '../models/reply';

@Injectable({
    providedIn: 'root',
})

export class TopicService {
    private apiUrl = 'https://localhost:7119/form'; 

    constructor(private http: HttpClient){}

    getTopics(){
        return this.http.get<Topic[]>(`${this.apiUrl}/gettopics`);
    }

    createTopic(title: string, content: string){
        const topicData: Topic = {
            userId: 1,
            title: title,
            content: content
        }
        this.http.post<Topic>(`${this.apiUrl}/createtopic`, topicData).subscribe();
    }
    
    getReplies(topicId: number){
        return this.http.get<Reply[]>(`${this.apiUrl}/getreplies?topicId=${topicId}`);
    }

    createReply(text: string, tId: number)
    {
        const replyData: Reply = {
            userId: 1,
            text: text,
            topicId: tId
        }
        
        this.http.post<Reply>(`${this.apiUrl}/createreply`, replyData)
            .subscribe((response) => {
                window.location.reload();
            },);
    }
}
