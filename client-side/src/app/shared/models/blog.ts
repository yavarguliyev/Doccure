import { Doctor } from './doctor';

export interface Blog {
  id: number;
  title: string;
  slug: string;
  description: string;
  photo: string;
  doctorId?: number;
  video?: any;
}

export class BlogB implements Blog {
  id: number;
  title: string;
  slug: string;
  description: string;
  photo: string;
  doctorId?: number;
  video?: any;

  constructor(
    id: number,
    title: string,
    slug: string,
    description: string,
    photo: string,
    doctorId?: number,
    video?: any
  ) {
    this.id = id;
    this.title = title;
    this.slug = slug;
    this.description = description;
    this.photo = photo;
    this.doctorId = doctorId;
    this.video = video;
  }
}
