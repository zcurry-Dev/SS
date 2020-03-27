import { Component, OnInit } from '@angular/core';
import { ArtistService } from '../../_services/artist.service';
import { AlertifyService } from '../../_services/Alertify.service';
import { Artist } from '../../_models/artist';
import { ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';

@Component({
  selector: 'app-artist-list',
  templateUrl: './artist-list.component.html',
  styleUrls: ['./artist-list.component.css']
})
export class ArtistListComponent implements OnInit {
  artists: Artist[];

  constructor(
    private artistService: ArtistService,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.artists = data['artists'];
    });
  }
}
