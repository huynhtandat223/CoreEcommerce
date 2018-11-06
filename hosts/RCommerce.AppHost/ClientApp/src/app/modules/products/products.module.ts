import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductsRoutingModule } from './products-routing.module';
import { CategoriesComponent } from './categories/categories.component';
import { GridModule } from '@progress/kendo-angular-grid';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { ProductoptionsComponent } from './productoptions/productoptions.component';
import { ProductoptionvaluedefaultComponent } from './productoptions/productoptionvaluedefault/productoptionvaluedefault.component';
import { ProductsComponent } from './products/products.component';
import { ProductdedailComponent } from './products/productdedail/productdedail.component';
import { LayoutModule } from '@progress/kendo-angular-layout';
import { GeneralInfomationComponent } from './products/productdedail/general-infomation/general-infomation.component';
import { DateInputsModule } from '@progress/kendo-angular-dateinputs';
import { InputsModule } from '@progress/kendo-angular-inputs';
import { TreeViewModule } from '@progress/kendo-angular-treeview';


@NgModule({
  imports: [
    CommonModule, GridModule, DropDownsModule, LayoutModule, DateInputsModule, InputsModule,
    ProductsRoutingModule, FormsModule, ReactiveFormsModule, TreeViewModule
  ],
  declarations: [CategoriesComponent, ProductoptionsComponent, ProductoptionvaluedefaultComponent, ProductsComponent, ProductdedailComponent, GeneralInfomationComponent]
})
export class ProductsModule { }
