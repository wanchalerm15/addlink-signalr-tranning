import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { SignalCorsComponent } from './signal-cors/signal-cors.component';
import { SignalNetComponent } from './signal-net/signal-net.component';

@NgModule({
  declarations: [
    AppComponent,
    SignalCorsComponent,
    SignalNetComponent
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
