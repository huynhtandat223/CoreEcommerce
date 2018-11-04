import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { HttpErrorHandler, HandleError } from '../http-error-handler.service';
import { environment } from '../../environments/environment';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Authorization': 'my-auth-token'
  })
};

import { preProcess, preProcessNothing } from './api.preprocess';

export class BaseService {
    
    protected handleError: HandleError;
    protected apiUrl: string;

    constructor(protected httpErrorHandler: HttpErrorHandler, protected apiEndpoint: string, protected http: HttpClient) 
    {
        this.handleError = httpErrorHandler.createHandleError(apiEndpoint + 'Service');
        this.apiUrl = `${environment.ApiUrl}${apiEndpoint}`;
    }

  public getAll (): Observable<any[]> {
    return this.http.get<any>(this.apiUrl)
      .pipe(
        map(preProcess),
        catchError(this.handleError('get' + this.apiEndpoint, []))
      );
  }

  public create(entity): Observable<any> {
    return this.http.post(this.apiUrl, entity, httpOptions)
      .pipe(
        map(preProcessNothing),
        catchError(this.handleError('create' + this.apiEndpoint, []))
      );
  }

  public delete(entity): Observable<any>{
    const id = typeof entity === 'number' ? entity : entity.Id;
    const url = `${this.apiUrl}/${id}`; 
    return this.http.delete(url, httpOptions)
      .pipe(
        map(preProcessNothing),
        catchError(this.handleError('delete' + this.apiEndpoint, []))
      )
  }

  public update(entity): Observable<any>{

    const id = typeof entity === 'number' ? entity : entity.Id;
    const url = `${this.apiUrl}/${id}`; 

    return this.http.put(url, entity, httpOptions)
    .pipe(
      map(preProcessNothing),
      catchError(this.handleError('update' + this.apiEndpoint, []))
    )
  }
}
