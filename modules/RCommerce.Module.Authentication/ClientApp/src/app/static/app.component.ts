import { Component } from '@angular/core';
import { Router } from '@angular/router';

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
}
