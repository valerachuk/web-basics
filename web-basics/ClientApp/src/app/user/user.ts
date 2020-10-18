export interface User {
  id: number;
  email: string;
  password: string;
  role: Role;
}

export interface Login {
  email: string;
  password: string;
}

export enum Role {
  User = 0,
  Admin
}
