import { Component, OnInit } from '@angular/core';
import { CategoriesService } from '../../../services/categories.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {
  public categories: any[] = [];
  formGroup : FormGroup;
  createFormGroup = dataItem => new FormGroup({
    'Name': new FormControl(dataItem.Name, Validators.required),
    'SKUPrefix': new FormControl(dataItem.SKUPrefix),
    'ParentId': new FormControl(dataItem.ParentId),
    'ParentName': new FormControl(dataItem.ParentName)
  });

  constructor(private categoriesService: CategoriesService) { }

  ngOnInit() {
    this.getCategories();
  }
  getCategories(): void{
    this.categoriesService.getAll()
      .subscribe(categories => this.categories = categories);
  }

  addHandler({sender}){
    this.formGroup = this.createFormGroup({Name : '', ParentId: 0, SKUPrefix: '', ParentName: ''});
    sender.addRow(this.formGroup);
  }
  editHandler({sender, rowIndex, dataItem}){
    sender.editRow(rowIndex, this.createFormGroup(dataItem));
  }

  cancelHandler({sender, rowIndex}){
    sender.closeRow(rowIndex);
  }
  removeHandler({ dataItem, rowIndex }){
      this.categoriesService.delete(dataItem)
        .subscribe(category => this.categories.splice(rowIndex, 1));
  }
  saveHandler({sender, rowIndex, formGroup, isNew}){
    const categoryInForm = formGroup.value;
    if(isNew){
      this.categoriesService.create(categoryInForm)
        .subscribe(category => this.categories.push(category));
    }
    else{
      const categoryView = this.categories[rowIndex];
      const categoryUpdate = {...categoryView, ...categoryInForm};
      this.categoriesService.update(categoryUpdate)
          .subscribe(category => this.categories[rowIndex] = category);
    }
    sender.closeRow(rowIndex);
  }

  onParentCategoryChange(e){
    this.formGroup.controls.ParentId.setValue(e.Id);
    this.formGroup.controls.ParentName.setValue(e.Name);
  }
}
