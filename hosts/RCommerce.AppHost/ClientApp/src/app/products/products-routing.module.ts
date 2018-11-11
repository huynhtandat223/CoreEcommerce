import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CategoriesComponent } from './categories/categories.component';
import { ProductoptionsComponent } from './productoptions/productoptions.component';
import { ProductsComponent } from './products/products.component';
import { ProductdedailComponent } from './products/productdedail/productdedail.component';
import { AuthGuard } from '../_shared/AuthGuard';

const routes: Routes = [
  {
    path: 'categories',
    component: CategoriesComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'productoptions',
    component: ProductoptionsComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'products',
    component: ProductsComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'addnew',
    component: ProductdedailComponent,
    canActivate: [AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }
