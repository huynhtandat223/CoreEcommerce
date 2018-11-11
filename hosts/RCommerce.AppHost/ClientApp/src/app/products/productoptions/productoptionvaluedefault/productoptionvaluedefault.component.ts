import { Component, OnInit, Input } from '@angular/core';
import { CommonComponent } from '../../../static/pages/core/common.component';
import { ProductoptionvaluedefaultsService } from '../../_services/productoptionvaluedefaults.service';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-productoptionvaluedefault',
  templateUrl: './productoptionvaluedefault.component.html',
  styleUrls: ['./productoptionvaluedefault.component.css']
})
export class ProductoptionvaluedefaultComponent extends CommonComponent {
  @Input('options') options: any[];
  
  constructor(private productOptionValueDefaultService: ProductoptionvaluedefaultsService) { 
    super(productOptionValueDefaultService
      , dataItem => new FormGroup(
        {
          'OptionId': new FormControl(dataItem.OptionId),
          'Value': new FormControl(dataItem.Value),
          'SortOrder': new FormControl(dataItem.SortOrder)
        }
      )
      , { OptionId: 0, Value: '', SortOrder: 0});
  }

  onProductOptionChange(e){
    this.formGroup.controls.OptionId.setValue(e.Id);
  }
  getOption(Id){
    return this.options.find(x => x.Id === Id);
  }

}
