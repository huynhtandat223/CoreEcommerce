import {Component, OnInit, Input} from '@angular/core';
import {Router} from "@angular/router";

@Component({
    selector: 'navigation',
    templateUrl: './navigation.component.html'
})
export class Navigation implements OnInit {
  loginInfo: any = {
    first_name: '',
    last_name: '',
    title:''
  };

    links = [
        {routeLink: "products/categories", text: "Categories"},
        {routeLink: "products/productoptions", text: "Product Options"},
        {routeLink: "products/products", text: "Products"},
    ]

    constructor( private router: Router) { }

    ngOnInit() { 
    }
    activeRoute(routename: string): boolean{
        return this.router.url.indexOf(routename) > -1;
    }
}
