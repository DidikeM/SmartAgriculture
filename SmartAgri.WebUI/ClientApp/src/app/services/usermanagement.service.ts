import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { User } from '../models/user';
import { WithDrawDto } from '../dtos/withdrawdto';
import { UserManagementAdvertDto } from '../dtos/usermanagementadvertdto';
import { UserManagementAdminAdvertDto } from '../dtos/usermanagementadminadvertdto';
import { UserManagementStaticticsDto } from '../dtos/usermanagementstaticticsdto';
import { UserManagementCustomersDto } from '../dtos/usermanagementcustomersdto';
import { ProductDto } from '../dtos/productdto';
import { GuestMessage } from '../models/guestmessage';
import { ReplyGuestMessageDto } from '../dtos/replyguestmessagedto';

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
    
    getRecentBuyAdvertForAdmin() {
        return this.http.get<UserManagementAdminAdvertDto[]>(`${this.apiUrl}/getrecentbuyadvertforadmin`);
    }

    getRecentSellAdvertForAdmin() {
        return this.http.get<UserManagementAdminAdvertDto[]>(`${this.apiUrl}/getrecentselladvertforadmin`);
    }

    getAdminStatistics() {
        return this.http.get<UserManagementStaticticsDto>(`${this.apiUrl}/getadminstatistics`);
    }
    
    getUserSpecializedStatistics() {
        return this.http.get<UserManagementStaticticsDto>(`${this.apiUrl}/getuserspecializedsatistics`);
    }

    getCustomers() {
        return this.http.get<UserManagementCustomersDto[]>(`${this.apiUrl}/getcustomers`);
    }

    getCompletedAdvertStatusCount() {
        return this.http.get<any[]>(`${this.apiUrl}/getcompletedadvertstatuscount`);
    }

    addMessage(body: GuestMessage) {
        console.log("service ",body);
        return this.http.post<GuestMessage>(`${this.apiUrl}/addmessage`, body).subscribe();
    }

    getGuestMessages() {
        return this.http.get<GuestMessage[]>(`${this.apiUrl}/getguestmessages`);
    }

    replyGuestMessage(body: ReplyGuestMessageDto){
        return this.http.post<ReplyGuestMessageDto>(`${this.apiUrl}/replyguestmessage`, body);
    }
}