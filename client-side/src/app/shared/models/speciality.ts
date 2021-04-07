export interface Speciality {
  name: string;
  photo: string;
}

export class SpecialityP implements Speciality {
  name: string;
  photo: string;

  constructor(name: string, photo: string) {
    this.name = name;
    this.photo = photo;
  }
}
