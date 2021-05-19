export interface Group {
  slug: string;
  connections: Connection[]
}

interface Connection {
  connectionId: string;
  slug: string;
}
