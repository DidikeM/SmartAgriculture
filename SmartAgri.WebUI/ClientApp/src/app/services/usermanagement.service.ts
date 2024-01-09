import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { WithDrawDto } from '../dtos/withdrawdto';
 
@Injectable({
    providedIn: 'root',
})

export class UserManagementService {
    private apiUrl = 'https://localhost:7119/usermanagement'; 

    constructor(private http: HttpClient){}

    getBalanceForUser(){
        return this.http.get<number>(`${this.apiUrl}/getbalanceforuser`);
    }

    buyCredit(amount: number){
        return this.http.post(`${this.apiUrl}/buycredit`, amount).subscribe();
    }

    sellCredit(amount: number){
        return this.http.post(`${this.apiUrl}/sellcredit`, amount).subscribe();
    }

    withDrawCredit(body: WithDrawDto){

        console.log(body);
        
        return this.http.post(`${this.apiUrl}/withdrawcredit`, body).subscribe();
    }
}