import { Component } from '@angular/core';
import { UserManagementAdvertDto } from 'src/app/dtos/usermanagementadvertdto';
import { UserManagementService } from 'src/app/services/usermanagement.service';

@Component({
  selector: 'app-active-advertisements',
  templateUrl: './active-advertisements.component.html',
  styleUrls: ['./active-advertisements.component.css']
})
export class ActiveAdvertisementsComponent {
  activeBuyAdverts: UserManagementAdvertDto[] = [];
  activeSellAdverts: UserManagementAdvertDto[] = [];

  constructor(private userManagementService: UserManagementService) { }

  ngOnInit() {
    this.userManagementService.getActiveBuyAdvertsForUser().subscribe(
      (buyAdverts) => {
        this.activeBuyAdverts = buyAdverts;
        console.log("activebuyadvert", this.activeBuyAdverts)
      }
    );

    this.userManagementService.getActiveSellAdvertsForUser().subscribe(
      (sellAdverts) => {
        this.activeSellAdverts = sellAdverts;
        console.log("activeSellAdverts", this.activeSellAdverts)

      }
    );
  }
}
