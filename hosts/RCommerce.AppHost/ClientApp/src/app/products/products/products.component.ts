import { Component, OnInit } from '@angular/core';
import { CommonComponent } from '../../static/pages/core/common.component';
import { ProductService } from '../_services/product.service';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { CategoriesService } from '../_services/categories.service';
import { of } from 'rxjs/observable/of';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent extends CommonComponent {

  public checkedKeys: any[] = [];

  public children = (dataItem: any): any => of(dataItem.Children);
  public hasChildren = (dataItem: any): boolean => !!dataItem.Children;

  categoriesGrouped: any[];
  categoriesUnGrouped: any[];
  ngOnInit(){
    this.categoryService.getGroupedCategories()
      .subscribe(data => {
        this.categoriesGrouped = data.Grouped;
        this.categoriesUnGrouped = data.UnGrouped;
        super.ngOnInit();
      });
  }
  protected initEditHandler(sender, rowIndex, dataItem){
    this.checkedKeys = dataItem.ProductCategories.map(i => this.categoriesUnGrouped.find(cat => cat.Id == i.CategoryId).ParentId_Id);
  }
  initSaveHandler(entity){

    entity.ProductCategories = [];

    let productCategories = [];    
    let categoryIds = Array<any>();
    this.checkedKeys.forEach(element => {
      categoryIds = categoryIds.concat(element.split('_'));
    });
    const categoryFilter = (value, index, self) => {
      return value > 0 && self.indexOf(value) === index;
    }
    categoryIds.filter(categoryFilter).forEach(element => productCategories.push({ProductId: entity.Id, CategoryId: element}));
    entity.ProductCategories = productCategories;

    this.checkedKeys = []; //reset.
    return entity;
  }
  
  bindCategories(dataItem){
    return dataItem.ProductCategories.map(i => this.categoriesUnGrouped.find(cate => cate.Id == i.CategoryId).Name).join(', ');
  }

  constructor(private categoryService: CategoriesService, private productService: ProductService, private router: Router) { 
    super(productService, dataItem => new FormGroup(
      {
        'Id': new FormControl(dataItem.Id),
        'Name': new FormControl(dataItem.Name),
        'SKU': new FormControl(dataItem.SKU),
        'ProductCategories': new FormControl(dataItem.ProductCategories),
        'RegularPrice': new FormControl(dataItem.RegularPrice),
        'QtyOnHand': new FormControl(dataItem.QtyOnHand),
        'IsInStock': new FormControl(dataItem.IsInStock),
        'Weight': new FormControl(dataItem.Weight)
      }), 
      { 
        Id: 0, Name: '', SKU: '', ProductCategories: {}, RegularPrice: 0, QtyOnHand: 0, IsInStock: false, Weight: 0
      });
  }

  public goToUrl(){
    this.router.navigate(['/products/addnew'], {queryParams: {returnUrl: this.router.url}});
  }
}
