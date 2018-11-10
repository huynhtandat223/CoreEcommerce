import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import {Topnavbar} from "./components/topnavbar/topnavbar.component";
import {Navigation} from "./components/navigation/navigation.component";
import {RouterModule} from "@angular/router";
import {HomeComponent} from "./pages/home/home.component";
import { GridModule } from '@progress/kendo-angular-grid';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { HttpErrorHandler } from './services/http-error-handler.service';
import { MessageService } from './services//message.service';
import { LayoutModule } from '@progress/kendo-angular-layout';
import { TreeViewModule } from '@progress/kendo-angular-treeview';

const appRoutes = [
  {
      path:'',
      redirectTo:'home',
      pathMatch:'full'
  },
  {
      path: 'home',
      component: HomeComponent
  }
]

@NgModule({
  declarations: [
    AppComponent,
    Navigation,
    Topnavbar,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot(appRoutes , { enableTracing: true }),
    GridModule, HttpClientModule,
    BrowserAnimationsModule,
    LayoutModule,
    TreeViewModule
  ],
  providers: [HttpErrorHandler,
    MessageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
