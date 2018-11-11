import { Injectable } from '@angular/core';
import { BaseService } from '../../static/services/base.service';
import { HttpClient } from '@angular/common/http';
import { HttpErrorHandler } from '../../static/services/http-error-handler.service';

@Injectable({
  providedIn: 'root'
})
export class ProductoptionService extends BaseService {

  constructor(httpErrorHandler: HttpErrorHandler, http: HttpClient) 
  {
      super(httpErrorHandler, "/odata/productoptions", http);
  }

}
