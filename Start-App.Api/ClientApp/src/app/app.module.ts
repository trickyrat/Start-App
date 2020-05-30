import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PersonComponent } from './person/person.component';
import { PersonListComponent } from './person-list/person-list.component';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { PersonService } from './person/person.service';
import { InformationComponent } from './person/information/information.component';
import { HeroformComponent } from './heroform/heroform.component';
import { HttpErrorHandler } from './http-error-handler.service';
import { MessageService } from './message.service';
import { RequestCache, RequestCacheWithMap } from './request-cache.service';

@NgModule({
  declarations: [
    AppComponent,
    PersonComponent,
    PersonListComponent,
    HomeComponent,
    NavMenuComponent,
    InformationComponent,
    HeroformComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    PersonService,
    HttpErrorHandler,
    MessageService,
    { provide: RequestCache, useClass: RequestCacheWithMap },
    //httpInterceptorProviders
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
