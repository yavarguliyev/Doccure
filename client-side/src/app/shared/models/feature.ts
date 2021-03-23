export interface Feature {
  id: number;
  name: string;
  image: string;
}

export class FeatureF implements Feature {
  id: number;
  name: string;
  image: string;

  constructor(id: number, name: string, image: string) {
    this.id = id;
    this.name = name;
    this.image = image;
  }
}
