import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { User } from '../models/user';
import { WithDrawDto } from '../dtos/withdrawdto';
import { UserManagementAdvertDto } from '../dtos/usermanagementadvertdto';
 
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
        return this.http.post(`${this.apiUrl}/withdrawcredit`, body).subscribe();
    }

    getActiveSellAdvertsForUser() {
        return this.http.get<UserManagementAdvertDto[]>(`${this.apiUrl}/getactiveselladvertsforuser`);
    }

    getActiveBuyAdvertsForUser() {
        return this.http.get<UserManagementAdvertDto[]>(`${this.apiUrl}/getactivebuyadvertsforuser`);
    }

    getPastSellAdvertsForUser() {
        return this.http.get<UserManagementAdvertDto[]>(`${this.apiUrl}/getpastbuyadvertsforuser`);
    }

    getPastBuyAdvertsForUser() {
        return this.http.get<UserManagementAdvertDto[]>(`${this.apiUrl}/getpastbuyadvertsforuser`);
    }

    getUserInfo(){
        return this.http.get<User>(`${this.apiUrl}/getUserInfo`);
    }

    postUserInfo(body: User){
        return this.http.post<User>(`${this.apiUrl}/postUserInfo`, body).subscribe();
    }
}