export interface Speciality {
  id: number;
  name: string;
  image: string;
}

export class SpecialityP implements Speciality {
  id: number;
  name: string;
  image: string;

  constructor(id: number, name: string, image: string) {
    this.id = id;
    this.name = name;
    this.image = image;
  }
}
