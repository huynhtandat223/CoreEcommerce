import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpErrorHandler, HandleError } from '../../static/services/http-error-handler.service';
import { environment } from '../../../environments/environment';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Authorization': 'my-auth-token'
  })
};

import { preProcess, preProcessNothing } from '../../static/services/api.preprocess';
import { BaseService } from '../../static/services/base.service';

@Injectable({
  providedIn: 'root'
})

export class CategoriesService extends BaseService {

  constructor(httpErrorHandler: HttpErrorHandler, http: HttpClient) 
  {
      super(httpErrorHandler, "/odata/categories", http);
  }
 
  public getGroupedCategories (): Observable<any> {
    return this.http.get<any>(this.apiUrl + '/grouped')
      .pipe(
        catchError(this.handleError('get' + this.apiEndpoint + + 'CategoryService.Grouped', []))
      );
  }
}
