import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import {Topnavbar} from "./components/topnavbar/topnavbar.component";
import {Navigation} from "./components/navigation/navigation.component";
import {RouterModule} from "@angular/router";
import { appRoutes } from "./app.routes";
import {HomeComponent} from "./pages/home/home.component";
import { GridModule } from '@progress/kendo-angular-grid';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpErrorHandler }     from './services/http-error-handler.service';
import { MessageService }       from './services//message.service';
import { LayoutModule } from '@progress/kendo-angular-layout';
import { TreeViewModule } from '@progress/kendo-angular-treeview';
import { ErrorInterceptor, JwtInterceptor, fakeBackendProvider } from './authentication/_helpers';

@NgModule({
  declarations: [
    AppComponent,
    Navigation,
    Topnavbar,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    FormsModule, ReactiveFormsModule,
    HttpModule,
    RouterModule.forRoot(appRoutes, { enableTracing: true }),
    GridModule, HttpClientModule,
    BrowserAnimationsModule,
    LayoutModule,
    TreeViewModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },

    // provider used to create fake backend
    fakeBackendProvider,
    HttpErrorHandler,
    MessageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
