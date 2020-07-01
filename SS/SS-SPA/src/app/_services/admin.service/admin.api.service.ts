import { Injectable } from '@angular/core';
import { environment as env } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { User } from 'src/app/_models/user';
import { Observable, EMPTY } from 'rxjs';
import { PaginatedResult } from 'src/app/_models/pagination';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class AdminApiService {
  constructor(private http: HttpClient) {}

  ListUsers(
    page?,
    itemsPerPage?,
    search?
  ): Observable<PaginatedResult<User[]>> {
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

    const url = `${env.apiUrl}/${env.adminListUsers}`;
    return this.http
      .get<User[]>(url, { observe: 'response', params })
      .pipe(
        map((response) => {
          paginatedResult.result = response.body;
          if (response.headers.get('Pagination') != null) {
            paginatedResult.pagination = JSON.parse(
              response.headers.get('Pagination')
            );
          }
          return paginatedResult;
        }),
        catchError((error) => {
          console.log(error);
          return EMPTY;
        })
      );
  }

  SaveUsers(user: User, roles: {}) {
    const url = `${env.apiUrl}/${env.adminSaveUsers}`;
    return this.http.patch<User>(`${url}/${user.userName}`, roles).pipe(
      catchError((error) => {
        console.log(error);
        return EMPTY;
      })
    );
  }

  GetRoles() {
    const url = `${env.apiUrl}/${env.adminGetRoles}`;
    return this.http.get(url).pipe(
      catchError((error) => {
        console.log(error);
        return EMPTY;
      })
    );
  }
}
