import { Injectable } from '@angular/core';
import { BaseService } from '../../../services/base.service';
import { HttpClient } from '@angular/common/http';
import { HttpErrorHandler } from '../../../services/http-error-handler.service';

@Injectable({
  providedIn: 'root'
})
export class ProductoptionService extends BaseService {

  constructor(httpErrorHandler: HttpErrorHandler, http: HttpClient) 
  {
      super(httpErrorHandler, "productoptions", http);
  }

}
