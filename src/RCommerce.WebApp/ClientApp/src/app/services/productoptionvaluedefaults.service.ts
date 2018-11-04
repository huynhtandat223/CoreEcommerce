import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpErrorHandler } from '../http-error-handler.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductoptionvaluedefaultsService extends BaseService {

  constructor(httpErrorHandler: HttpErrorHandler, http: HttpClient) 
  {
      super(httpErrorHandler, "productoptionvaluedefaults", http);
  }

}
