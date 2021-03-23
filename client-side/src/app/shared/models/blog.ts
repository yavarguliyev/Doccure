import { Doctor } from './doctor';

export interface Blog {
  id: number;
  title: string;
  slug: string;
  image: string;
  doctor: Doctor;
}

export class BlogB implements Blog {
  id: number;
  title: string;
  slug: string;
  image: string;
  doctor: Doctor;

  constructor(id: number, title: string, slug: string, image: string, doctor: Doctor) {
    this.id = id;
    this.title = title;
    this.slug = slug;
    this.image = image;
    this.doctor = doctor;
  }
}
