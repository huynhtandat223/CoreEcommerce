import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { CategoriesService } from '../../../services/categories.service';
import { of } from 'rxjs/observable/of';

@Component({
  selector: 'app-general-infomation',
  templateUrl: './general-infomation.component.html',
  styleUrls: ['./general-infomation.component.css']
})
export class GeneralInfomationComponent implements OnInit {
  @Input('formGroup') formGroup: FormGroup;
  @Output() onFormSubmit = new EventEmitter<any>();

  public checkedKeys: any[] = [];

  public children = (dataItem: any): any => of(dataItem.Children);
  public hasChildren = (dataItem: any): boolean => !!dataItem.Children;


  categories: Array<any> = [];
  constructor(private categoriesService: CategoriesService) { 

  }

  ngOnInit() {
    this.categoriesService.getGroupedCategories()
      .subscribe(categories => this.categories = categories);
  }
  
  onSubmit(){
    if(this.formGroup.valid){
      let product = this.formGroup.value;
      let productCategories = [];
      let categoryIds = Array<any>();
      this.checkedKeys.forEach(element => {
        categoryIds = categoryIds.concat(element.split('_'));
      });
      const categoryFilter = (value, index, self) => {
        return value > 0 && self.indexOf(value) === index;
      }
      categoryIds.filter(categoryFilter).forEach(element => productCategories.push({ProductId: product.Id, CategoryId: element}));
      product.ProductCategories = productCategories;
      this.onFormSubmit.emit(product);
    }
  }
}
