import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { User } from 'src/app/_models/user';
import { Observable } from 'rxjs';
import { PaginatedResult } from 'src/app/_models/pagination';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class AdminService {
  baseUrl = environment.apiUrl + 'admin/';

  constructor(private http: HttpClient) {}

  getUsersWithRoles(
    page?,
    itemsPerPage?,
    search?
  ): Observable<PaginatedResult<User[]>> {
    console.log('page: ', page, ' - itemsPerPage: ', itemsPerPage);

    const paginatedResult: PaginatedResult<User[]> = new PaginatedResult<
      User[]
    >();
    let params = new HttpParams();

    if (page != null && itemsPerPage != null) {
      params = params.append('pn', page);
      params = params.append('ps', itemsPerPage);
    }

    if (search) {
      params = params.append('search', search);
    }

    return this.http
      .get<User[]>(this.baseUrl + 'usersWithRoles', {
        observe: 'response',
        params,
      })
      .pipe(
        map((response) => {
          paginatedResult.result = response.body;
          if (response.headers.get('Pagination') != null) {
            paginatedResult.pagination = JSON.parse(
              response.headers.get('Pagination')
            );
          }
          return paginatedResult;
        })
      );
  }

  updateUserRoles(user: User, roles: {}) {
    return this.http.post(this.baseUrl + 'editRoles/' + user.userName, roles);
  }

  getAvailibleRoles() {
    return this.http.get(this.baseUrl + 'getRoles');
  }
}
