import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ArtistService } from './services/artistService.service'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchArtistComponent } from './fetch-Artist/fetch-Artist.component'
import { CreateArtist } from './addArtist/addArtist.component'
import { HttpModule } from '@angular/http';
import { CommonModule } from '@angular/common'; 



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FetchArtistComponent,
    CreateArtist
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    HttpModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'fetch-artist', component: FetchArtistComponent },
      //{ path: 'register-artist', component: CreateArtist },
      { path: 'artist/edit/:id', component: CreateArtist },
      { path: '**', redirectTo: 'home' }
    ])
  ],
  providers: [ArtistService, HttpClientModule, HttpModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
