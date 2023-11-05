import { Component } from '@angular/core';
import { trigger, state, style, transition, animate } from '@angular/animations';

import { faBars, faXmark } from '@fortawesome/free-solid-svg-icons';

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
export class GeneralLayoutComponent {
  faBars = faBars;
  faXmark = faXmark;

  toggleIcon: any = faBars;
  isDropdownOpen: boolean = false;

  toggleDropdown() {
    this.isDropdownOpen = !this.isDropdownOpen;
    console.log(this.isDropdownOpen);
    this.toggleIcon = this.isDropdownOpen ? faXmark : faBars;
  }}
