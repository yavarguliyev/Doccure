import { Gender } from '../enums/gender.enum';

export interface User {
  id: number;
  code: string;
  photo?: string;
  fullname: string;
  slug: string;
  email: string;
  birth?: Date;
  gender: Gender;
  token: string;
  role: string;
  status: boolean;
  inviteToken?: string;
  confirmToken?: string;
  connectionId?: string;
  adminId?: number;
  doctorId?: number;
  patientId?: number;
  postalCode: string;
  address: string;
  city: string;
  state: string;
  country: string;
  biography: string;
  message: string;
}

export interface UserFormValues {
  fullname?: string;
  email?: string;
  gender: Gender;
  birth?: Date;
  password?: string;
  confirmPassword?: string;
}
