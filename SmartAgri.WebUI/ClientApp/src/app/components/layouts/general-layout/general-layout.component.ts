import { Component, OnInit } from '@angular/core';
import { trigger, state, style, transition, animate } from '@angular/animations';

import { faBars, faXmark } from '@fortawesome/free-solid-svg-icons';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-general-layout',
  templateUrl: './general-layout.component.html',
  styleUrls: ['./general-layout.component.css'],
  animations: [
    trigger('rotateIcon', [
      state('open', style({ transform: 'rotate(90deg)' })),
      state('closed', style({ transform: 'rotate(0deg)' })),
      transition('open <=> closed', animate('200ms ease-in-out')),
    ]),
  ],
})

export class GeneralLayoutComponent implements OnInit {
  faBars = faBars;
  faXmark = faXmark;

  toggleIcon: any = faBars;
  isDropdownOpen: boolean = false;

  public isUserAuthenticated!: boolean;

  constructor(private authService: AuthenticationService, private router: Router) { }
  
  ngOnInit(): void {
    this.authService.authChanged
    .subscribe(res => {
      // console.log(res);
      this.isUserAuthenticated = res;
      //console.log(this.isUserAuthenticated);

      this.isUserAuthenticated = this.authService.checkAuth();
    })
  }

  public logout = () => {
    this.authService.logout();
    this.router.navigate(["/"]);
  }

  toggleDropdown() {
    this.isDropdownOpen = !this.isDropdownOpen;
    //console.log(this.isDropdownOpen);
    this.toggleIcon = this.isDropdownOpen ? faXmark : faBars;
  }

}
