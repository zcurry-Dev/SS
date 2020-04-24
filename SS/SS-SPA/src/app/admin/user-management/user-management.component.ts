import { Component, OnInit, ViewChild } from '@angular/core';
import { User } from 'src/app/_models/user';
import { AdminService } from 'src/app/_services/admin.service/admin.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap';
import { RolesModalComponent } from '../roles-modal/roles-modal.component';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';
import { distinctUntilChanged, debounceTime } from 'rxjs/operators';
import { Pagination, PaginatedResult } from 'src/app/_models/pagination';
import { ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-user-management',
  templateUrl: './user-management.component.html',
  styleUrls: ['./user-management.component.css'],
})
export class UserManagementComponent implements OnInit {
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  users: User[];
  displayedColumns: string[] = ['userId', 'userName', 'roles', 'editRoles'];
  dataSource = new MatTableDataSource(this.users);
  pagination: Pagination;
  pageEvent: PageEvent;
  length: number;
  pageSize: number;
  search: string;

  searchTextChanged = new Subject<string>();

  constructor(
    private adminService: AdminService,
    private dialog: MatDialog,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe((data) => {
      this.users = data['users'].result;
      this.pagination = data['users'].pagination;
      this.length = this.pagination.totalItems;
      this.pageSize = this.pagination.itemsPerPage;
      this.setUpDataSource();
    });

    this.searchTextChanged
      .pipe(debounceTime(500), distinctUntilChanged())
      .subscribe((res) => {
        this.search = res.trim().toLowerCase();
        this.pagination.currentPage = 1;
        this.loadUsers();
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

    this.loadUsers();
  }

  loadUsers() {
    this.adminService
      .getUsersWithRoles(
        this.pagination.currentPage,
        this.pageSize,
        this.search
      )
      .subscribe(
        (res: PaginatedResult<User[]>) => {
          this.users = res.result;
          this.pagination = res.pagination;
          this.setUpDataSource();
          this.length = this.pagination.totalItems;
        },
        (error) => {
          // this.alertify.error(error);
          console.log(error);
        }
      );
  }

  applyFilter($event) {
    this.searchTextChanged.next($event);
  }

  setUpDataSource() {
    this.dataSource.data = this.users;
    this.dataSource.sort = this.sort;
  }

  getRolesArray(user, roles) {
    const userRoles = user.roles;

    this.adminService.getAvailibleRoles().subscribe((data: any[]) => {
      const availableRoles = data;
      if (availableRoles) {
        for (const ar of availableRoles) {
          let isMatch = false;
          for (const ur of userRoles) {
            if (ar.name === ur) {
              isMatch = true;
              ar.checked = true;
              roles.push(ar);
              break;
            }
          }

          if (!isMatch) {
            ar.checked = false;
            roles.push(ar);
          }
        }
      }
    });
  }

  editRolesModal(user: User) {
    const roles = [];
    this.getRolesArray(user, roles);

    const dialogRef = this.dialog.open(RolesModalComponent, {
      data: {
        user,
        roles,
      },
    });

    dialogRef.afterClosed().subscribe((values) => {
      if (values) {
        const rolesToUpdate = {
          // ... spreads valuse into new array
          roleNames: [
            ...values.filter((el) => el.checked === true).map((el) => el.name),
          ],
        };
        if (rolesToUpdate) {
          this.adminService.updateUserRoles(user, rolesToUpdate).subscribe(
            () => {
              user.roles = [...rolesToUpdate.roleNames];
            },
            (error) => {
              console.log(error);
            }
          );
        }
      }
    });
  }
}
