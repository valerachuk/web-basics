import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { User, Role } from './user';
import { UserService } from './user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor(private userService: UserService) { }

  public users: User[];

  public form = new FormGroup({
    email: new FormControl(null, [Validators.required, Validators.email]),
    password: new FormControl(null, Validators.required),
  });

  private fetchUsers(): void {
    this.userService.get().subscribe(users => this.users = users);
  }

  ngOnInit() {
    this.fetchUsers();
  }

  public getRole(user: User): string {
    return Role[user.role];
  }

  public isAdmin(user: User): boolean {
    return user.role === Role.Admin;
  }

  public toAdmin(user: User): void {
    this.setRole(user, Role.Admin);
  }

  public toUser(user: User): void {
    this.setRole(user, Role.User);
  }

  private setRole(user: User, role: Role): void {
    this.userService.put({
      ...user,
      role
    }).subscribe(() => this.fetchUsers());
  }

  public deleteUser(user: User): void {
    this.userService.delete(user).subscribe(() => this.fetchUsers());
  }

  public onSubmit(): void {
    if (this.form.valid) {
      this.userService.post(this.form.value).subscribe(() => {
        this.fetchUsers();
        this.form.reset();
      },
        err => {
          if (err.status === 409) {
            alert('Try another email');
          } else {
            alert('Unknown error');
          }
        });
      return;
    }

    this.form.markAllAsTouched();
  }

}
