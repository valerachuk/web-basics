import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service'

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  public get isLoggedId(): boolean {
    return this.as.isAuthenticated();
  }

  public get isAdmin(): boolean {
    return this.as.isAdmin();
  }

  constructor(
    private as: AuthService
  ) { }
}
