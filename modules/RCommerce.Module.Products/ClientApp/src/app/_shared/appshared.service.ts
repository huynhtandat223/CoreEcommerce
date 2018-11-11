import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()
export class AppSharedService {
  private _isLogined = new BehaviorSubject<boolean>(false);
  isLogined = this._isLogined.asObservable();

  constructor() { }
  logout() {
    this._isLogined.next(false);
    localStorage.removeItem('currentUser');
  }
  login(user) {
    this._isLogined.next(true);
    localStorage.setItem('currentUser', JSON.stringify(user));
  }
}
