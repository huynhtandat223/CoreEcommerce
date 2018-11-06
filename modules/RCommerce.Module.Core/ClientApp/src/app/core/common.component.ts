import { OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { BaseService } from '../../services/base.service';
import { BaseComponent } from './base.component';


export class CommonComponent extends BaseComponent {
  public data: any[] = [];
  public formGroup : FormGroup;
  
  constructor(private baseService: BaseService,private createFormGroup: any, private entityDefault) { 
    super();
  }

  protected processDatasource(data){
    return data;
  }
  protected initSaveHandler(entity){
    return entity;
  }
  protected initEditHandler(sender, rowIndex, dataItem){

  }

  ngOnInit() {
    this.baseService.getAll()
        .subscribe(data => this.data = this.processDatasource(data));
  }
  
  public addHandler({sender}){
    this.formGroup = this.createFormGroup(this.entityDefault);
    sender.addRow(this.formGroup);
  }
  public editHandler({sender, rowIndex, dataItem}){
    this.initEditHandler(sender, rowIndex, dataItem);
    sender.editRow(rowIndex, this.createFormGroup(dataItem));
  }

  public cancelHandler({sender, rowIndex}){
    sender.closeRow(rowIndex);
  }
  public removeHandler({ dataItem, rowIndex }){
      this.baseService.delete(dataItem)
        .subscribe(category => this.data.splice(rowIndex, 1));
  }
  public saveHandler({sender, rowIndex, formGroup, isNew}){
    let entityInForm = formGroup.value;
    entityInForm = this.initSaveHandler(entityInForm);

    if(isNew){
      this.baseService.create(entityInForm)
        .subscribe(category => this.data.push(category));
    }
    else{
      const categoryView = this.data[rowIndex];
      const categoryUpdate = {...categoryView, ...entityInForm};
      this.baseService.update(categoryUpdate)
          .subscribe(category => this.data[rowIndex] = category);
    }
    sender.closeRow(rowIndex);
  }

}
