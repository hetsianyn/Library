import { BookBase } from "./book-base";


export interface BookDetailed extends BookBase{
  cover: File,
  content: string,
  genre: string
}
