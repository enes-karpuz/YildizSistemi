import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { MainpageComponent } from './mainpage/mainpage.component';
import { GezegenComponent } from './mainpage/gezegen/gezegen.component';
import { UyduComponent } from './mainpage/uydu/uydu.component';

@NgModule({
  declarations: [
    AppComponent,
    MainpageComponent,
    GezegenComponent,
    UyduComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
