import { BookBase } from "./book-base";


export interface Book extends BookBase{
  cover: string;
  rating: number;
  reviewsNumber: number;
}
