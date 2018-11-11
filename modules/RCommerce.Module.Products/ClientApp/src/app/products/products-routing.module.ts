import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CategoriesComponent } from './categories/categories.component';
import { ProductoptionsComponent } from './productoptions/productoptions.component';
import { ProductsComponent } from './products/products.component';
import { ProductdedailComponent } from './products/productdedail/productdedail.component';

const routes: Routes = [
  {
    path: 'categories',
    component: CategoriesComponent
  },
  {
    path: 'productoptions',
    component: ProductoptionsComponent
  },
  {
    path: 'products',
    component: ProductsComponent
  },
  {
    path: 'addnew',
    component: ProductdedailComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }
