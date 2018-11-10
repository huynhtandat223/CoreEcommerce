/**
 * Created by andrew.yang on 2/6/2017.
 */
import {Component, OnInit, Input} from '@angular/core';
import {Router} from "@angular/router";
import { appContext } from '../../../_shared/appContext';

@Component({
    selector: 'navigation',
    templateUrl: './navigation.component.html'
})
export class Navigation implements OnInit {
    @Input() loginInfo: any;

    links = [
        {routeLink: "products/categories", text: "Categories"},
        {routeLink: "products/productoptions", text: "Product Options"},
        {routeLink: "products/products", text: "Products"},
    ]

    constructor( private router: Router) { }

    ngOnInit() { 
        //console.log(appContext);
    }
    activeRoute(routename: string): boolean{
        return this.router.url.indexOf(routename) > -1;
    }
}
