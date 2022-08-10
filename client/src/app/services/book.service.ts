import { HttpClient } from '@angular/common/http';
import {EventEmitter, Injectable, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Book } from '../models/book';
import { BookDetailed } from '../models/book-detailed';
import { BookView } from '../models/book-view';

@Injectable({
  providedIn: 'root'
})

export class BookService {
  private url = "books";

  books: Book[] = [];

  constructor(private http: HttpClient) { }

  //Get Books
  getAllBooks(): Observable<Book[]>{
    return this.http.get<Book[]>(`${environment.apiUrl}/${this.url}`);
  }
  getAllBooksRecommended(): Observable<Book[]>{
    return this.http.get<Book[]>(`${environment.apiUrl}/recommended`);
  }

  createBook(book: BookDetailed): Observable<BookDetailed[]>{
    return this.http.post<BookDetailed[]>(`${environment.apiUrl}/${this.url}/save`,
      book);
  }

  getBookDetailed(id: number): Observable<BookView>{
    return this.http.get<BookView>(`${environment.apiUrl}/${this.url}/${id}`);
  }
}
