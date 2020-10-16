import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Dog, DogRequest } from './dog';

@Injectable({
  providedIn: 'root'
})
export class DogService {
  constructor(private httpClient: HttpClient) { }
  private url = 'api/dog';

  public get(): Observable<Dog[]> {
    return this.httpClient.get<Dog[]>(this.url);
  }

  public post(dog: DogRequest): Observable<void> {
    return this.httpClient.post<void>(this.url, dog);
  }
}
