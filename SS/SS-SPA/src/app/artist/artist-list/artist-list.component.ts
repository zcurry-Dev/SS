import { Component, OnInit, ViewChild } from '@angular/core';
import { ArtistService } from '../../_services/artist.service/artist.service';
import { AlertifyService } from '../../_services/alertify.service/alertify.service';
import { Artist } from '../../_models/artist';
import { ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';
import { Pagination, PaginatedResult } from 'src/app/_models/pagination';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { PageEvent } from '@angular/material/paginator';
import { Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { ImageService } from 'src/app/_services/image.service/images.service';
import { MatDialog } from '@angular/material/dialog';
import { ArtistAddComponent } from '../artist-add/artist-add.component';

@Component({
  selector: 'app-artist-list',
  templateUrl: './artist-list.component.html',
  styleUrls: ['./artist-list.component.css'],
})
export class ArtistListComponent implements OnInit {
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  artists: Artist[];
  pagination: Pagination;
  displayedColumns: string[] = [
    'id',
    'photo',
    'name',
    'verified',
    'currentCity',
    'homeCity',
  ];
  dataSource = new MatTableDataSource(this.artists);
  pageEvent: PageEvent;
  length: number;
  pageSize: number;
  search: string;
  searchTextChanged = new Subject<string>();
  fallbackImg = '../../../assets/fallbackUser.png';

  constructor(
    private artistService: ArtistService,
    private imageService: ImageService,
    private alertify: AlertifyService,
    private route: ActivatedRoute,
    public dialog: MatDialog
  ) {}

  ngOnInit() {
    this.getData();
    this.filter();
  }

  getData() {
    this.route.data.subscribe(async (data) => {
      this.artists = data['artists'].result;
      this.pagination = data['artists'].pagination;
      this.length = this.pagination.totalItems;
      this.pageSize = this.pagination.itemsPerPage;
      await this.getMainArtistImage();
      this.setUpDataSource();
    });
  }

  filter() {
    this.searchTextChanged
      .pipe(debounceTime(500), distinctUntilChanged())
      .subscribe((res) => {
        this.search = res.trim().toLowerCase();
        this.pagination.currentPage = 1;
        this.loadArtists();
      });
  }

  pageChanged(event?: PageEvent) {
    const ps = event.pageSize;
    const ipp = this.pagination.itemsPerPage;
    const cp = this.pagination.currentPage;

    if (ps !== ipp) {
      this.pageSize = ps;
      const currentResults = cp * ipp - ipp;
      this.pagination.currentPage = Math.floor(currentResults / ps) + 1;
    } else {
      this.pagination.currentPage = event.pageIndex + 1;
    }

    this.loadArtists();
  }

  loadArtists() {
    this.artistService
      .getArtists(this.pagination.currentPage, this.pageSize, this.search)
      .subscribe(
        (res: PaginatedResult<Artist[]>) => {
          this.artists = res.result;
          this.pagination = res.pagination;
          this.setUpDataSource();
          this.length = this.pagination.totalItems;
        },
        (error) => {
          this.alertify.error(error);
        }
      );
  }

  applyFilter($event) {
    this.searchTextChanged.next($event);
  }

  setUpDataSource() {
    this.getMainArtistImage();
    this.dataSource.data = this.artists;
    this.dataSource.sort = this.sort;
  }

  getMainArtistImage() {
    for (const artist of this.artists) {
      if (artist.mainPhotoId > 0) {
        this.artistService
          .getPhotoFile(artist.mainPhotoId)
          .subscribe((image) => {
            artist.mainPhotoURL = this.imageService.sanitizeImage(image);
          });
      }
    }
  }

  openAddArtistDialog() {
    const dialogRef = this.dialog.open(ArtistAddComponent, {
      width: '250px',
    });
  }
}
