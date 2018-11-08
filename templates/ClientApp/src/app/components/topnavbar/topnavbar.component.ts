import { Component } from '@angular/core';
import {smoothlyMenu} from "../../app.helpers";
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'topnavbar',
    templateUrl: 'topnavbar.component.html'
})
export class Topnavbar {
    returnUrlParam: string;
    constructor(private router: Router, private activatedRoute: ActivatedRoute){
        this.activatedRoute.queryParams.subscribe(params => {
            this.returnUrlParam = params['returnUrl'];
        });
    }

    ngOnInit() {

    }
    toggleNavigation(): void {
        jQuery("body").toggleClass("mini-navbar");
        smoothlyMenu();
    }
    logout() {
        localStorage.clear();
    }

    enableBackButton(){
        return this.returnUrlParam !== undefined;
    }
}