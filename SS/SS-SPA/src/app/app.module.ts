import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import {
  BsDropdownModule,
  TabsModule,
  PaginationModule,
  ModalModule,
} from 'ngx-bootstrap';
import { FileUploadModule } from 'ng2-file-upload';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { NgModule } from '@angular/core';
import { NgxGalleryModule } from '@kolkov/ngx-gallery';
import { RouterModule } from '@angular/router';
import { TimeagoModule } from 'ngx-timeago';
import { AppMaterialModule } from './app.material.module';
import { FlexLayoutModule } from '@angular/flex-layout';

import { AppComponent } from './app.component';
import { AppRoutes } from './routes';

import { AuthGuard } from './_guards/auth.guard';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';

import { ArtistEditResolver } from './_resolver/artist-edit.resolver';
import { ArtistListResolver } from './_resolver/artist-list.resolver';
import { ArtistDetailResolver } from './_resolver/artist-detail.resolver';
import { AdminUsersResolver } from './_resolver/adminUsers.resolver';

import { ErrorInterceptorProvider } from './_services/_error.interceptor/error.interceptor';
import { AlertifyService } from './_services/alertify.service/alertify.service';
import { AdminApiService } from './_services/admin.service/admin.api.service';
import { ArtistApiService } from './_services/artist.service/artist.api.service';
import { AuthApiService } from './_services/auth.service/auth.api.service';
import { UtilityApiService } from './_services/utility.service/utility.api.service';
import { AdminService } from './_services/admin.service/admin.subject.service';
import { ArtistService } from './_services/artist.service/artist.subject.service';
import { AuthService } from './_services/auth.service/auth.subject.service';
import { UtilityService } from './_services/utility.service/utility.subject.service';

import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { ArtistCardComponent } from './artist/artist-card/artist-card.component';
import { ArtistDetailComponent } from './artist/artist-detail/artist-detail.component';
import { ArtistEditComponent } from './artist/artist-edit/artist-edit.component';
import { ArtistListComponent } from './artist/artist-list/artist-list.component';
import { BeersComponent } from './beers/beers.component';
import { HomeComponent } from './home/home.component';
import { NavComponent } from './nav/nav.component';
import { PhotoManagementComponent } from './admin/photo-management/photo-management.component';
import { RegisterComponent } from './register/register.component';
import { RolesModalComponent } from './admin/roles-modal/roles-modal.component';
import { UserManagementComponent } from './admin/user-management/user-management.component';
import { VenuesComponent } from './venues/venues.component';
import { HasRoleDirective } from './_directives/hasRole.directive';
import { ArtistAddComponent } from './artist/artist-add/artist-add.component';
import { LoginComponent } from './login/login.component';
import { ProfileComponent } from './profile/profile.component';
import { EditAboutComponent } from './artist/artist-edit/edit-about/edit-about.component';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AdminPanelComponent,
    AppComponent,
    ArtistAddComponent,
    ArtistCardComponent,
    ArtistDetailComponent,
    ArtistEditComponent,
    ArtistListComponent,
    BeersComponent,
    HomeComponent,
    NavComponent,
    PhotoManagementComponent,
    RegisterComponent,
    RolesModalComponent,
    UserManagementComponent,
    VenuesComponent,
    HasRoleDirective,
    LoginComponent,
    ProfileComponent,
    EditAboutComponent,
  ],
  imports: [
    AppMaterialModule,
    BrowserAnimationsModule,
    BrowserModule,
    BsDatepickerModule.forRoot(),
    BsDropdownModule.forRoot(),
    FileUploadModule,
    FormsModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter,
        whitelistedDomains: ['localhost:5000', '192.168.1.25:700'],
        blacklistedRoutes: [
          'localhost:5000/api/auth',
          '192.168.1.25:700/api/auth',
        ],
      },
    }),
    ModalModule.forRoot(),
    NgxGalleryModule,
    PaginationModule.forRoot(),
    ReactiveFormsModule,
    RouterModule.forRoot(AppRoutes),
    TabsModule.forRoot(),
    TimeagoModule.forRoot(),
    FlexLayoutModule,
  ],
  providers: [
    ErrorInterceptorProvider,
    AuthGuard,
    AlertifyService,
    ArtistDetailResolver,
    ArtistListResolver,
    ArtistEditResolver,
    PreventUnsavedChanges,
    AdminUsersResolver,
    AdminApiService,
    ArtistApiService,
    AuthApiService,
    UtilityApiService,
    ArtistService,
    AdminService,
    AuthService,
    UtilityService,
  ],
  entryComponents: [RolesModalComponent],
  bootstrap: [AppComponent],
})
export class AppModule {}
