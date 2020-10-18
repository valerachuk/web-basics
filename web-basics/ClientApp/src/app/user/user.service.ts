import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Login, User } from './user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private httpClient: HttpClient) { }

  private url = 'api/account';

  public get(): Observable<User[]> {
    return this.httpClient.get<User[]>(this.url);
  }

  public delete(user: User): Observable<void> {
    return this.httpClient.delete<void>(this.url, {
      params: new HttpParams().set('id', user.id.toString())
    });
  }

  public put(user: User): Observable<void> {
    return this.httpClient.put<void>(this.url, user);
  }

  public post(login: Login): Observable<void> {
    return this.httpClient.post<void>(this.url, login);
  }

}
