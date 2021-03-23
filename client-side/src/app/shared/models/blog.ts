import { Doctor } from './doctor';

export interface Blog {
  id: number;
  title: string;
  slug: string;
  image: string;
  doctor: Doctor;
  video?: string;
}

export class BlogB implements Blog {
  id: number;
  title: string;
  slug: string;
  image: string;
  doctor: Doctor;
  video?: string;

  constructor(id: number, title: string, slug: string, image: string, doctor: Doctor, video?: string) {
    this.id = id;
    this.title = title;
    this.slug = slug;
    this.image = image;
    this.doctor = doctor;
    this.video = video;
  }
}
