import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Message } from '../interfaces';

@Injectable()
export class DashboardService {

  private readonly apiUrl = 'http://localhost:8080/api/values';

  constructor(
    private readonly http: HttpClient
  ) { }

  public getMessages(): Observable<Message[]> {
    return this.http.get<Message[]>(this.apiUrl);
  }

  public addMessage(message: Message): Observable<void> {
    return this.http.post<void>(this.apiUrl, message);
  }

  public deleteMessage(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  public updateMessage(message: Message): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${message.id}`, { msg: message.msg });
  }

}
