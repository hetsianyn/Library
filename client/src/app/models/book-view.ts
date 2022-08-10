import { BookBase } from "./book-base";
import { Review } from "./review";

export interface BookView extends BookBase{
  genre:string
  cover: null;
  content: string;
  rating: number;
  reviews: Review[];
}
