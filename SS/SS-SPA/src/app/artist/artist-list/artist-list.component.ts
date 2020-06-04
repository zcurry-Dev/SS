import { Component, OnInit, ViewChild } from '@angular/core';
import { ArtistApiService } from '../../_services/artist.service/artist.api.service';
import { AlertifyService } from '../../_services/alertify.service/alertify.service';
import { Artist } from '../../_models/artist';
import { Pagination } from 'src/app/_models/pagination';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { PageEvent } from '@angular/material/paginator';
import { Subject, Observable } from 'rxjs';
import { debounceTime, distinctUntilChanged, tap } from 'rxjs/operators';
import { MatDialog } from '@angular/material/dialog';
import { ArtistAddComponent } from '../artist-add/artist-add.component';
import { ArtistService } from 'src/app/_services/artist.service/artist.subject.service';

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
    private _artistAPI: ArtistApiService,
    private alertify: AlertifyService,
    public dialog: MatDialog,
    private _artist: ArtistService
  ) {}

  ngOnInit() {
    this.watchArtistList();
    this.watchFilter();
  }

  watchArtistList() {
    this._artistAPI
      .List(this.pagination?.currentPage, this.pageSize, this.search)
      .subscribe((artistList) => {
        console.log(artistList);
        this._artist.update({ artistList });
        this.populateDataSource();
      });
  }

  applyFilter($event) {
    this.searchTextChanged.next($event);
  }

  watchFilter() {
    this.searchTextChanged
      .pipe(debounceTime(500), distinctUntilChanged())
      .subscribe((res) => {
        this.search = res.trim().toLowerCase();
        this.pagination.currentPage = 1;
        this.watchArtistList();
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

    this.watchArtistList();
  }

  openAddArtistDialog() {
    const dialogRef = this.dialog.open(ArtistAddComponent, {
      width: '250px',
    });
  }

  populateDataSource() {
    this._artist.artistList$
      .pipe(
        distinctUntilChanged(),
        tap((artists) => console.log('Found artists', artists?.result))
      )
      .subscribe(
        (artists) => {
          this.artists = artists?.result;
          this.pagination = artists?.pagination;
          this.setUpDataSource();
          this.length = this.pagination?.totalItems;
          this.pageSize = this.pagination?.itemsPerPage;
        },
        (error) => {
          this.alertify.error(error);
        }
      )
      .unsubscribe();
  }

  setUpDataSource() {
    this.dataSource = new MatTableDataSource<Artist>(this.artists);
    this.dataSource.data = this.artists;
    this.dataSource.sort = this.sort;
  }
}
