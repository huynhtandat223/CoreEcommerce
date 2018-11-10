import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AppSharedService } from 'src/app/_shared/appshared.service';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {

    constructor(private router: Router, private appSharedService: AppSharedService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    let value = false;
    this.appSharedService.isLogined.subscribe(data => value = data);
    if (value)
      return true;

    this.router.navigate(['/authentication/login'], { queryParams: { returnUrl: state.url } });
        return false;
    }
}
