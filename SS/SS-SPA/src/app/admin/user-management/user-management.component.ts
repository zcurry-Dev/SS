import { Component, OnInit, ViewChild } from '@angular/core';
import { User } from 'src/app/_models/user';
import { AdminService } from 'src/app/_services/admin.service/admin.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap';
import { RolesModalComponent } from '../roles-modal/roles-modal.component';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import {
  MatDialog,
  MatDialogRef,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-user-management',
  templateUrl: './user-management.component.html',
  styleUrls: ['./user-management.component.css'],
})
export class UserManagementComponent implements OnInit {
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  users: User[];
  bsModalRef: BsModalRef;
  displayedColumns: string[] = ['id', 'userName', 'roles', 'editRoles'];
  dataSource = new MatTableDataSource(this.users);

  constructor(
    private adminService: AdminService,
    private modalService: BsModalService,
    private dialog: MatDialog
  ) {}

  ngOnInit() {
    this.getUsersWithRoles();
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  getUsersWithRoles() {
    this.adminService.getUsersWithRoles().subscribe(
      (users: User[]) => {
        this.users = users;
        this.setUpDataSource();
      },
      (error) => {
        console.log(error);
      }
    );
  }

  setUpDataSource() {
    this.dataSource = new MatTableDataSource(this.users);
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
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
