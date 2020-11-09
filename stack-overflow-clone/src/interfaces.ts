export interface Question {
  id: number;
  author: string;
  title: string;
  content: string;
  viewsCount: number;
  creationDate: string;
  answers: Array<string>;
};
