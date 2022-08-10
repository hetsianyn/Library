import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Book } from 'src/app/models/book';
import { BookDetailed } from 'src/app/models/book-detailed';
import { BookService } from 'src/app/services/book.service';
import {NgForm} from '@angular/forms';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-books-page',
  templateUrl: './books-page.component.html',
  styleUrls: ['./books-page.component.css']
})
export class BooksPageComponent implements OnInit {
  booksInDb: Book[] =[];
  booksNumber: number = this.booksInDb.length;

  books: BookDetailed[] = [];
  book: BookDetailed = {
    id: this.booksNumber,
    title: '',
    author: '',
    genre: '',
    cover: null,
    content: 'sasd'
  }


  @Output() bookUpdated = new EventEmitter<BookDetailed[]>();

  constructor(private bookService: BookService) { }

  ngOnInit(): void {

  }

  onSubmit(book: BookDetailed){
    console.log(this.book)
  }

  getAllBooks() {
    this.bookService.getAllBooks()
      .subscribe(response => {
          this.booksInDb = response;
        }
      );
  }

  createBook(book: BookDetailed){
    this.bookService.createBook(book)
      .subscribe((books: BookDetailed[]) => this.bookUpdated.emit(books));
  }


}
