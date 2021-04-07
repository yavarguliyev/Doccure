export interface Feature {
  name: string;
  photo: string;
}

export class FeatureF implements Feature {
  name: string;
  photo: string;

  constructor(name: string, photo: string) {
    this.name = name;
    this.photo = photo;
  }
}
