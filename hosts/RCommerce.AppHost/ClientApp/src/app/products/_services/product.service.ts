import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpErrorHandler } from '../../static/services/http-error-handler.service';
import { BaseService } from '../../static/services/base.service';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { preProcess } from '../../static/services/api.preprocess';

@Injectable({
  providedIn: 'root'
})
export class ProductService extends BaseService {

  constructor(httpErrorHandler: HttpErrorHandler, http: HttpClient) 
  {
      super(httpErrorHandler, "/odata/products", http);
  }

  public getAll (): Observable<any[]> {
    return this.http.get<any>(`${this.apiUrl}?$expand=ProductCategories`)
      .pipe(
        map(preProcess),
        catchError(this.handleError('get' + this.apiEndpoint, []))
      )
  }

}
