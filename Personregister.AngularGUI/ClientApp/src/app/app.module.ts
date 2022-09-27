import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { PersonComponent } from './person/person.component';
import { FodselComponent } from './fodsel/fodsel.component';
import { DodsfallComponent } from '../dodsfall/dodsfall.component';
import { AddPersonComponent } from './person/addPerson/addPerson.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    PersonComponent,
    FodselComponent,
    DodsfallComponent,
    AddPersonComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'person', component: PersonComponent },
      { path: 'fodsel', component: FodselComponent },
      { path: 'dodsfall', component: DodsfallComponent },
      { path: 'addPerson', component: AddPersonComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
