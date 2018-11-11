import { Component, OnInit } from '@angular/core';
import { AppSharedService } from '../_shared/appshared.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {

  constructor(private appSharedService: AppSharedService) {
  }

  isLogined: boolean;
  ngOnInit() {
    this.appSharedService.login({userName: 'test', token: 'token'});
    this.appSharedService.isLogined.subscribe(data => {
      this.isLogined = data;
    });
  }
  
}
