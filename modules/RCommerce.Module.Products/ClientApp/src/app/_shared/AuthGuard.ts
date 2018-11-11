import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, CanActivate } from '@angular/router';

import { AppSharedService } from './appshared.service';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {

    constructor(private appSharedService: AppSharedService){}

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        return this.appSharedService.canActivate(state.url);
    }
}
