import { Component, OnInit } from '@angular/core';
import { Message } from '../interfaces';
import { DashboardService } from './dashboard.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  public messages: Message[];
  public pendingMessage: string;

  public pendingEditId: number;
  public pendingEditMessage: string;

  constructor(
    private readonly dashboardService: DashboardService
  ) { }

  ngOnInit(): void {
    this.fetchMessages();
  }

  public onAdd(): void {

    if (!this.pendingMessage.trim()) {
      return;
    }

    this.dashboardService.addMessage({
      msg: this.pendingMessage
    }).subscribe(() => {
      this.fetchMessages();
      this.pendingMessage = '';
    });
  }

  public onDelete(id: number): void {
    this.dashboardService
      .deleteMessage(id)
      .subscribe(() => this.fetchMessages());
  }

  public onEdit(): void {

    if (!this.pendingEditMessage.trim()) {
      return;
    }

    this.dashboardService.updateMessage({
      msg: this.pendingEditMessage,
      id: this.pendingEditId
    }).subscribe(() => {
      this.pendingEditId = null;
      this.fetchMessages();
    });
  }

  private fetchMessages(): void {
    this.dashboardService.getMessages().subscribe(messges => this.messages = messges);
  }

}
