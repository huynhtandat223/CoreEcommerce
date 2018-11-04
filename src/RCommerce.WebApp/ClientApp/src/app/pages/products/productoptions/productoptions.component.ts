import { Component, OnInit } from '@angular/core';
import { ProductoptionService } from '../../../services/productoption.service';
import { CommonComponent } from '../../core/common.component';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-productoptions',
  templateUrl: './productoptions.component.html',
  styleUrls: ['./productoptions.component.css']
})
export class ProductoptionsComponent extends CommonComponent {

  constructor(private productOptionService: ProductoptionService) { 
    super(productOptionService, dataItem => new FormGroup({'Name': new FormControl(dataItem.Name)}), { Name: ''});
  }

}
