import { FormGroup } from '@angular/forms';
import { BaseComponent } from './base.component';
import { BaseService } from '../../services/base.service';

export class DetailComponent extends BaseComponent {
  public entity: FormGroup;
  getdefaultFormGroup(){
    if(this.entity == null) this.entity = this.createFormGroup(this.entityDefault);
    return this.entity;
  }
  
  constructor(private baseService: BaseService, private createFormGroup: any, private entityDefault) { 
    super();
  }

  public onSubmited(entity){
    if(entity.Id > 0)
      this.baseService.update(entity)
        .subscribe(entity => this.entity = this.createFormGroup(entity));
    else
      this.baseService.create(entity)
        .subscribe(entity => this.entity.reset());
  }

}
