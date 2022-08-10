import { BookBase } from "./book-base";


export interface BookDetailed extends BookBase{
  cover: null,
  content: string,
  genre: string
}
