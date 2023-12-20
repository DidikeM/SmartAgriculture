import {Injectable, inject } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})

class AuthGuard{
    constructor(private router:Router, private jwtHelper: JwtHelperService){}

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean{
        const token = localStorage.getItem("token");

        if (token && !this.jwtHelper.isTokenExpired(token)){
            return true;
        }
        this.router.navigate(["/auth/login"]);
        return false;
    }
}

export const IsAuthGuard: CanActivateFn = (route: ActivatedRouteSnapshot,state: RouterStateSnapshot):boolean =>{
  return inject(AuthGuard).canActivate(route,state);
}