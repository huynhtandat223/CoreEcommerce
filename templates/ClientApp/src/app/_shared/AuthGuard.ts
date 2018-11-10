import { Injectable } from '@angular/core';
import { Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import * as Foo from '../authentication/_guards';
import { AppSharedService } from './appshared.service';

@Injectable({ providedIn: 'root' })
export class AuthGuard extends Foo.AuthGuard {

  constructor(router: Router, appSharedService: AppSharedService){
    super(router, appSharedService);
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        return super.canActivate(route, state);
    }
}
