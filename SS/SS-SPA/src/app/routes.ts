import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ArtistsComponent } from './artists/artists.component';
import { VenuesComponent } from './venues/venues.component';
import { BeersComponent } from './beers/beers.component';
import { AuthGuard } from './_guards/auth.guard';

export const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'artists', component: ArtistsComponent },
      { path: 'venues', component: VenuesComponent },
      { path: 'beers', component: BeersComponent }
    ]
  },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];
