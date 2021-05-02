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

export class ChatMessageFormValues {
  chatId: number;
  userId: number;
  photo: string;
  doctorContent: string;
  patientContent: string;

  constructor(chatId: number, userId: number, photo: string, doctorContent: string, patientContent: string) {
    this.chatId = chatId;
    this.userId = userId;
    this.photo = photo;
    this.doctorContent = doctorContent;
    this.patientContent = patientContent;
  }
}
