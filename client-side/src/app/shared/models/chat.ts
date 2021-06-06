import { User } from './user';

export interface Chat {
  id: number;
  doctor: User;
  patient: User;
  chatMessageDTOs: ChatMessage[];
}

export interface ChatMessage {
  id: number;
  chatId: number;
  photo: string;
  photoURL: string;
  isSeen: boolean;
  doctorContent: string;
  patientContent: string;
  addedDate: Date;
}

export class ChatMessageFormValues {
  chatId: number;
  userId: number;
  photo: string;
  photoURL: string;
  doctorContent: string;
  patientContent: string;

  constructor(
    chatId: number,
    userId: number,
    photo: string,
    photoURL: string,
    doctorContent: string,
    patientContent: string
  ) {
    this.chatId = chatId;
    this.userId = userId;
    this.photo = photo;
    this.photoURL = photoURL;
    this.doctorContent = doctorContent;
    this.patientContent = patientContent;
  }
}
