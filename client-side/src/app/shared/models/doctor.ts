export interface Doctor{
  id: number;
  fullname: string;
  slug: string;
  image: string;

}

export class DoctorD implements Doctor {
  id: number;
  fullname: string;
  slug: string;
  image: string;

  constructor(id: number, fullname: string, slug: string, image: string) {
    this.id = id;
    this.fullname = fullname;
    this.slug = slug;
    this.image = image;
  }
}
