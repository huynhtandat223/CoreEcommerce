import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { AppSharedService } from 'src/app/_shared/appshared.service';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    constructor(private http: HttpClient, private appSharedService: AppSharedService) { }

    login(username: string, password: string) {
      return this.http.post<any>(`${environment.ApiUrl}/login`, { username, password })
            .pipe(map(user => {
                // login successful if there's a jwt token in the response
              if (user && user.token) {
                this.appSharedService.login(user);
              }
                return user;
            }));
    }

  logout() {
    this.appSharedService.logout();
  }
}
