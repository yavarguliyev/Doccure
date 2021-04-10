import { Gender } from '../enums/gender.enum';

export interface User {
  id: number;
  code: string;
  photo?: string;
  fullname: string;
  slug: string;
  email: string;
  phone: number;
  fullAddress: string;
  role: string;
  age: number;
  gender: Gender;
  bloodGroup: string;
  status: boolean;
  token: string;
  inviteToken?: string;
  confirmToken?: string;
  connectionId?: string;
  adminId?: number;
  doctorId?: number;
  patientId?: number;
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
