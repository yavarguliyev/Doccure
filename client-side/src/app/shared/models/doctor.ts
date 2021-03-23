export interface Doctor{
  id: number;
  fullname: string;
  slug: string;
  photo: string;

}

export class DoctorD implements Doctor {
  id: number;
  fullname: string;
  slug: string;
  photo: string;

  constructor(id: number, fullname: string, slug: string, photo: string) {
    this.id = id;
    this.fullname = fullname;
    this.slug = slug;
    this.photo = photo;
  }
}
