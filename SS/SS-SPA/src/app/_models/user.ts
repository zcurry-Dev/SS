export interface User {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  dateOfBirth: Date;
  created: Date;
  lastActive: Date;
  userName: string;
  displayName: string;
  roles?: string[];
}
