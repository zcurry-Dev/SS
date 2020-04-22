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
  displayedColumns: string[] = [
    // 'sort',
    'id',
    'userName',
    'roles',
    'editRoles',
  ];
  dataSource = new MatTableDataSource(this.users);
  availableRoles: any;

  constructor(
    private adminService: AdminService,
    private modalService: BsModalService,
    private dialog: MatDialog
  ) {}

  ngOnInit() {
    this.getUsersWithRoles();
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

  private getAvailibleRoles() {
    this.adminService.getAvailibleRoles().subscribe((data) => {
      console.log('data', data);
      this.availableRoles = data;
      console.log('availableRoles22222', this.availableRoles);
    });
  }

  private getRolesArrayPart2(roles, userRoles) {
    if (this.availableRoles) {
      for (let i = 0; i < this.availableRoles.length; i++) {
        let isMatch = false;
        for (let j = 0; j < userRoles.length; j++) {
          if (this.availableRoles[i].name === userRoles[j]) {
            isMatch = true;
            this.availableRoles[i].checked = true;
            roles.push(this.availableRoles[i]);
            break;
          }
        }

        if (!isMatch) {
          this.availableRoles[i].checked = false;
          roles.push(this.availableRoles[i]);
        }
      }

      console.log(roles);
    }

    return roles;
  }

  async editRolesModal(user) {
    console.log('clicked');

    let testVar = await this.adminService.getAvailibleRoles();

    let tv2 = await testVar.subscribe(async (data) => {
      this.availableRoles = data;
      console.log('this.availableRoles44444', this.availableRoles);
    });

    console.log('after testVar completes');
    console.log('this.availableRoles', this.availableRoles);
  }

  //   async getRolesArray(user) {
  //       const roles = [];
  //       const userRoles = user.roles;

  // let testVar = await this.adminService.getAvailibleRoles();

  //       // const getRoles = async () => {
  //       //   const
  //       //   console.log('here 1st?');
  //       //   return this.adminService.getAvailibleRoles().subscribe((data) => {
  //       //     console.log(data);

  //       //     abc = data;
  //       //     console.log(abc);
  //       //   });

  //       //   return await abc;

  //         // return this.adminService.getAvailibleRoles();

  //         // const roles = await this.adminService.getAvailibleRoles().toPromise();
  //         // console.log(roles);
  //         // roles.then((data) => {
  //         //   console.log('hereeeee');
  //         //   return data;
  //         // });
  //       };

  //       let aaaaaaa = this.adminService.getAvailibleRoles().toPromise();

  //       let rolessss = await getRoles();
  //       console.log('rolessss', rolessss);
  //       console.log('running AFTER getRoles is finished');

  //       // const getFruit = async (name) => {
  //       //   const fruits = {
  //       //     pinapple: 'pinapple',
  //       //     peach: 'peach',
  //       //     strawberry: 'strawberry',
  //       //   };
  //       //   console.log('here');

  //       //   return fruits[name];
  //       // };

  //       // let aaa = getFruit('peach');
  //       // console.log('aaa', aaa);

  //       // const getRoles = async () => {
  //       //   this.adminService.getAvailibleRoles().subscribe((data) => {
  //       //     return data;
  //       //     console.log('data', data);
  //       //     this.availableRoles = data;
  //       //     console.log('availableRoles22222', this.availableRoles);
  //       //   });
  //       // };

  //       // const aa = await this.getAvailibleRoles();
  //       // console.log('availableRoles', this.availableRoles);

  //       // this.adminService.getAvailibleRoles().subscribe((data) => {
  //       //   availableRoles2 = data;
  //       //   console.log('availableRoles2 eee', availableRoles2);
  //       // });

  //       // const availableRoles: any[] = [
  //       //   { name: 'Admin', value: 'Admin' },
  //       //   { name: 'User', value: 'User' },
  //       //   { name: 'Artist', value: 'Artist' },
  //       //   { name: 'Venue Manager', value: 'Venue Manager' },
  //       //   { name: 'Promoter', value: 'Promoter' },
  //       //   { name: 'Artist Manager', value: 'Artist Manager' },
  //       // ];

  //       // this.getRolesArrayPart2(roles, userRoles);

  //       return roles;

  //       // for (let i = 0; i < availableRoles.length; i++) {
  //       //   let isMatch = false;
  //       //   for (let j = 0; j < userRoles.length; j++) {
  //       //     if (availableRoles[i].name === userRoles[j]) {
  //       //       isMatch = true;
  //       //       availableRoles[i].checked = true;
  //       //       roles.push(availableRoles[i]);
  //       //       break;
  //       //     }
  //       //   }

  //       //   if (!isMatch) {
  //       //     availableRoles[i].checked = false;
  //       //     roles.push(availableRoles[i]);
  //       //   }
  //       // }

  //       // console.log(roles);

  //   }

  // editRolesModal(user: User) {
  //   const dialogRef = this.dialog.open(RolesModalComponent, {
  //     data: {
  //       user,
  //       roles: this.getRolesArray(user),
  //     },
  //   });

  //   dialogRef.afterClosed().subscribe((values) => {
  //     if (values) {
  //       const rolesToUpdate = {
  //         // ... spreads valuse into new array
  //         roleNames: [
  //           ...values.filter((el) => el.checked === true).map((el) => el.name),
  //         ],
  //       };
  //       if (rolesToUpdate) {
  //         this.adminService.updateUserRoles(user, rolesToUpdate).subscribe(
  //           () => {
  //             user.roles = [...rolesToUpdate.roleNames];
  //           },
  //           (error) => {
  //             console.log(error);
  //           }
  //         );
  //       }
  //     }
  //   });
  // }
}
