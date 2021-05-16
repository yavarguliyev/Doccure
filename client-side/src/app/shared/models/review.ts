import { DoctorRecommendation } from '../enums/doctorRecommendation';
import { User } from './user';

export interface Review {
  id: number;
  text: string;
  rateStar: string;
  rateNumber: number;
  isReply: boolean;
  addedDate: Date;
  doctorId: number;
  patient: User;
  reviewReplyDTOs: ReviewReply[];
  recommendation: DoctorRecommendation;
}

export class ReviewFormValues {
  text: string;
  rateStar: string;
  patientId: number;
  doctorId: number;

  constructor(text: string, rateStar: string, patientId: number, doctorId: number) {
    this.text = text;
    this.rateStar = rateStar;
    this.patientId = patientId;
    this.doctorId = doctorId;
  }
}

export interface ReviewReply {
  reviewId: number;
  text: string;
  doctor: User;
  patient: User;
  addedDate: Date;
}

export class ReviewReplyFormValues {
  reviewId: number;
  text: string;
  doctorId?: number;
  patientId?: number;

  constructor(text: string, reviewId: number, doctorId?: number, patientId?: number) {
    this.text = text;
    this.reviewId = reviewId;
    this.doctorId = doctorId;
    this.patientId = patientId;
  }
}
