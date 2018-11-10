import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
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
import { AppLoadService } from './services/appload.service';

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

export function init_app(appLoadService: AppLoadService){
  return () => appLoadService.initializeApp();
}

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
    RouterModule.forRoot(appRoutes),
    GridModule, HttpClientModule,
    BrowserAnimationsModule,
    LayoutModule,
    TreeViewModule
  ],
  providers: [
    AppLoadService,
    { provide: APP_INITIALIZER, useFactory: init_app, deps: [AppLoadService], multi: true },
    HttpErrorHandler,
    MessageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
