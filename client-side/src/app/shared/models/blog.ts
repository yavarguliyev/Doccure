import { Doctor } from './doctor';

export interface Blog {
  id: number;
  title: string;
  slug: string;
  description: string;
  photo: string;
  doctor?: Doctor;
  video?: any;
  commentCount: number;
  addedDate: Date;
}

export class BlogB implements Blog {
  id: number;
  title: string;
  slug: string;
  description: string;
  photo: string;
  doctor?: Doctor;
  video?: any;
  commentCount: number;
  addedDate: Date;

  constructor(
    id: number,
    title: string,
    slug: string,
    description: string,
    photo: string,
    doctor?: Doctor,
    video?: any,
  ) {
    this.id = id;
    this.title = title;
    this.slug = slug;
    this.description = description;
    this.photo = photo;
    this.doctor = doctor;
    this.video = video;
  }
}
