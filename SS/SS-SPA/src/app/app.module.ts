import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule, TabsModule } from 'ngx-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { NgxGalleryModule } from '@kolkov/ngx-gallery';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { VenuesComponent } from './venues/venues.component';
import { BeersComponent } from './beers/beers.component';
import { appRoutes } from './routes';
import { ArtistListComponent } from './artist/artist-list/artist-list.component';
import { ArtistCardComponent } from './artist/artist-card/artist-card.component';
import { ArtistDetailComponent } from './artist/artist-detail/artist-detail.component';
import { AlertifyService } from './_services/Alertify.service';
import { AuthGuard } from './_guards/auth.guard';
import { ArtistService } from './_services/artist.service';
import { ArtistDetailResolver } from './_resolver/artist-detail.resolver';
import { ArtistListResolver } from './_resolver/artist-list.resolver';
import { ArtistEditComponent } from './artist/artist-edit/artist-edit.component';
import { ArtistEditResolver } from './_resolver/artist-edit.resolver';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    VenuesComponent,
    BeersComponent,
    ArtistListComponent,
    ArtistCardComponent,
    ArtistDetailComponent,
    ArtistEditComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    TabsModule.forRoot(),
    RouterModule.forRoot(appRoutes),
    NgxGalleryModule,
    JwtModule.forRoot({
      config: {
        tokenGetter,
        whitelistedDomains: ['localhost:5000', '192.168.1.25:700'],
        blacklistedRoutes: [
          'localhost:5000/api/auth',
          '192.168.1.25:700/api/auth'
        ]
      }
    })
  ],
  providers: [
    AuthService,
    ErrorInterceptorProvider,
    AlertifyService,
    AuthGuard,
    ArtistService,
    ArtistDetailResolver,
    ArtistListResolver,
    ArtistEditResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
