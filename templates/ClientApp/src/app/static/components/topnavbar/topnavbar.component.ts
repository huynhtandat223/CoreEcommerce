import { Component } from '@angular/core';
import {smoothlyMenu} from "../../app.helpers";
import { Router, ActivatedRoute } from '@angular/router';
import { AppSharedService } from 'src/app/_shared/appshared.service';

@Component({
    selector: 'topnavbar',
    templateUrl: 'topnavbar.component.html'
})
export class Topnavbar {
    returnUrlParam: string;
    constructor(private router: Router, private activatedRoute: ActivatedRoute, private appSharedService: AppSharedService){
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
    this.appSharedService.logout();
      this.router.navigate(['/authentication/login']);
    }

    enableBackButton(){
        return this.returnUrlParam !== undefined;
    }
}
