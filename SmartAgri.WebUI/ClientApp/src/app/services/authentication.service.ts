import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/internal/Subject';

import { AuthResponseDto } from '../dtos/authResponsedto';
import { UserForAuthenticationDto } from '../dtos/userforauthenticationdto';
import { BehaviorSubject } from 'rxjs';

@Injectable({
    providedIn: 'root',
})

export class AuthenticationService {
    private authChangeSub = new BehaviorSubject<boolean>(this.checkAuth());
    public authChanged = this.authChangeSub.asObservable();
    
    private apiUrl = 'http://localhost:61098/auth'; 

    constructor(private http: HttpClient){}

    public loginUser = (body: UserForAuthenticationDto) => {
        return this.http.post<AuthResponseDto>(`${this.apiUrl}/login`, body);
    }

     checkAuth(): boolean {
        // Token kontrolü veya başka bir yöntemle oturum durumunu kontrol et
        const token = localStorage.getItem("token");
        return !!token; // Token varsa true, yoksa false döndürür
    }

    public sendAuthStateChangeNotification = () => {
        this.authChangeSub.next(this.checkAuth());
    }

    public logout = () => {
        localStorage.removeItem("token");
        this.sendAuthStateChangeNotification();
    }

    // private createCompleteRoute = (route: string, envAddress: string) => {
    //     return `${envAddress}/${route}`;
    // }
}
