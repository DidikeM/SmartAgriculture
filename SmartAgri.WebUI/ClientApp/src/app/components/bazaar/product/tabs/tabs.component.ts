import { Component, Input, Output, EventEmitter} from '@angular/core';

@Component({
  selector: 'app-tabs',
  templateUrl: './tabs.component.html',
  styleUrls: ['./tabs.component.css']
})

export class TabsComponent {
  @Input() tabsArray: string[] = [];
  @Output() onTabChange = new EventEmitter<number>();
  
  activatedTab: number = 0;

  setTab(index: number){
    this.activatedTab = index;
    this.onTabChange.emit(this.activatedTab);
  }
  
}
