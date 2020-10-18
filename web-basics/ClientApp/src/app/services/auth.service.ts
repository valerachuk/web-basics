import { Injectable, Inject } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http'
import { AUTH_API_URL } from '../app-injection-token'
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Token } from '../model/token'

export const ACCESS_TOKEN_KEY = 'access_token'

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private http: HttpClient,
    @Inject(AUTH_API_URL) private apiUrl: string,
    private jwtHelper: JwtHelperService,
    private router: Router
  ) { }

  login(email: string, password: string): Observable<Token> {
    return this.http.post<Token>(`${this.apiUrl}api/auth/login`, {
      email, password
    }).pipe(
      tap(token => {
        localStorage.setItem(ACCESS_TOKEN_KEY, token.access_token);
      })
    )
  }

  isAuthenticated(): boolean {
    const token = localStorage.getItem(ACCESS_TOKEN_KEY);
    return token && !this.jwtHelper.isTokenExpired(token);
  }

  isAdmin(): boolean {
    const token = localStorage.getItem(ACCESS_TOKEN_KEY);
    return this.jwtHelper.decodeToken(token).role === 'Admin';
  }

  logout(): void {
    localStorage.removeItem(ACCESS_TOKEN_KEY);
    this.router.navigate(['']);
  }
}
