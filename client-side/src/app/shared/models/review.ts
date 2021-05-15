import { User } from './user';

export interface Review {
  id: number;
  text: string;
  rateStar: string;
  rateNumber: number;
  isRecommended: boolean;
  isReply: boolean;
  addedDate: Date;
  doctorId: number;
  patient: User;
  reviewReplyDTOs: ReviewReply[];
}

export interface ReviewReply {
  reviewId: number;
  text: string;
  doctor: User;
  patient: User;
  addedDate: Date;
}
