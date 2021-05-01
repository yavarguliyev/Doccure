import { User } from './user';

export interface Chat {
  id: number;
  doctor: User;
  patient: User;
  chatMessageDTOs: ChatMessage[];
}

export interface ChatMessage {
  chatId: number;
  photo: string;
  isSeen: boolean;
  doctorContent: string;
  patientContent: string;
  addedDate: Date;
}
