export type StatusOptions = 'Open' | 'Closed';

export interface Issue {
  id?: string;
  title: string;
  description?: string;
  status?: StatusOptions;
  createdAt?: Date;
  updatedAt?: Date;
}
