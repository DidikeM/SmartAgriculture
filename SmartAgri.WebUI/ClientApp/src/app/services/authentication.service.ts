import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

import { AuthResponseDto } from '../dtos/authResponsedto';
import { UserForAuthenticationDto } from '../dtos/userforauthenticationdto';
import { UserForRegistrationDto } from '../dtos/userforregistrationdto ';
import { RegistrationResponseDto } from '../dtos/registrationresponsedto';
import { ForgotPasswordDto } from '../dtos/forgotpassworddto';
import { ResetPasswordDto } from '../dtos/resetpassworddto';

@Injectable({
    providedIn: 'root',
})

export class AuthenticationService {
    private authChangeSub = new BehaviorSubject<boolean>(this.checkAuth());
    public authChanged = this.authChangeSub.asObservable();
    
    private apiUrl = 'https://localhost:7119/auth'; 

    constructor(private http: HttpClient){}

    public registerUser = (body: UserForRegistrationDto) => {
        return this.http.post<RegistrationResponseDto> (`${this.apiUrl}/register`, body);
    }

    public loginUser = (body: UserForAuthenticationDto) => {
        return this.http.post<AuthResponseDto>(`${this.apiUrl}/login`, body);
    }

    checkAuth(): boolean {
        const token = localStorage.getItem("token");
        return !!token; 
    }

    public sendAuthStateChangeNotification = () => {
        this.authChangeSub.next(this.checkAuth());
    }

    public logout = () => {
        localStorage.removeItem("token");
        this.sendAuthStateChangeNotification();
    }

    public forgotPassword = (body: ForgotPasswordDto) => {
        console.log(body);
        return this.http.post(`${this.apiUrl}/forgotpassword`, body);
    }

    public resetPassword(body: ResetPasswordDto) {
        console.log("service");
        console.log(body);
        return this.http.post(`${this.apiUrl}/resetpassword`, body);
    }
}
