import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { ActivatedRouteSnapshot, Router } from '@angular/router';

@Injectable()
export class AppSharedService {
  private _isLogined = new BehaviorSubject<boolean>(false);
  isLogined = this._isLogined.asObservable();

  constructor(private router: Router) { 
    if(localStorage.getItem('currentUser') !== null)
      this._isLogined.next(true);
  }
  logout() {
    this._isLogined.next(false);
    localStorage.removeItem('currentUser');
  }
  login(user) {
    this._isLogined.next(true);
    localStorage.setItem('currentUser', JSON.stringify(user));
  }
  canActivate(currentUrl: string): boolean{
    let isUserLogined = this._isLogined.getValue();

    if(isUserLogined) return true;

    this.router.navigate(['/authentication/login'], { queryParams: { returnUrl: currentUrl } });
    return false;
  }
}
