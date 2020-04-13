import { Component, OnInit } from '@angular/core';
import { ArtistService } from '../../_services/artist.service/artist.service';
import { AlertifyService } from '../../_services/alertify.service/alertify.service';
import { Artist } from '../../_models/artist';
import { ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';
import { Pagination, PaginatedResult } from 'src/app/_models/pagination';

@Component({
  selector: 'app-artist-list',
  templateUrl: './artist-list.component.html',
  styleUrls: ['./artist-list.component.css'],
})
export class ArtistListComponent implements OnInit {
  artists: Artist[];
  pagination: Pagination;

  constructor(
    private artistService: ArtistService,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe((data) => {
      this.artists = data['artists'].result;
      this.pagination = data['artists'].pagination;
    });
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadArtists();
  }

  loadArtists() {
    this.artistService
      .getArtists(this.pagination.currentPage, this.pagination.itemsPerPage)
      .subscribe(
        (res: PaginatedResult<Artist[]>) => {
          this.artists = res.result;
          this.pagination = res.pagination;
        },
        (error) => {
          this.alertify.error(error);
        }
      );
  }
}
