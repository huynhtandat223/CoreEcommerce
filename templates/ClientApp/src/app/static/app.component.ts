import { Component } from '@angular/core';
import { Router, Route } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  loginInfo: any = {
      first_name:'Andrew',
      last_name:'Yang',
      avatar:'ay.jpeg',
      title:'Senior Developer'
  };
  constructor(private router: Router) {
    const moduleRoutes: Route[] = [
      
    ];
    this.router.config.unshift(
      ...moduleRoutes
    );
  }
}
