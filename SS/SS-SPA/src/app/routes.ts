import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { VenuesComponent } from './venues/venues.component';
import { BeersComponent } from './beers/beers.component';
import { AuthGuard } from './_guards/auth.guard';
import { ArtistListComponent } from './artist/artist-list/artist-list.component';
import { ArtistDetailComponent } from './artist/artist-detail/artist-detail.component';
import { ArtistDetailResolver } from './_resolver/artist-detail.resolver';
import { ArtistListResolver } from './_resolver/artist-list.resolver';
import { ArtistEditComponent } from './artist/artist-edit/artist-edit.component';
import { ArtistEditResolver } from './_resolver/artist-edit.resolver';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { AdminUsersResolver } from './_resolver/adminUsers.resolver';
import { ArtistAddComponent } from './artist/artist-add/artist-add.component';

export const AppRoutes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {
        path: 'artist',
        component: ArtistListComponent,
        resolve: { artists: ArtistListResolver },
      },
      {
        path: 'artist/edit/:id',
        component: ArtistEditComponent,
        resolve: { artist: ArtistEditResolver },
        canDeactivate: [PreventUnsavedChanges],
      },
      {
        path: 'artist/:id',
        component: ArtistDetailComponent,
        resolve: { artist: ArtistDetailResolver },
      },
      { path: 'venues', component: VenuesComponent },
      { path: 'beers', component: BeersComponent },
      { path: 'addArtist', component: ArtistAddComponent },
      {
        path: 'admin',
        component: AdminPanelComponent,
        resolve: { users: AdminUsersResolver },
        data: { roles: ['Admin', 'Moderator'] },
      },
    ],
  },
  { path: '**', redirectTo: '', pathMatch: 'full' },
];
