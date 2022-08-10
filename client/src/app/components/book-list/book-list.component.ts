import { Component, OnInit } from '@angular/core';
import { Book } from 'src/app/models/book';
import { BookService } from 'src/app/services/book.service';
import {MatDialog} from '@angular/material/dialog';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {

  books: Book[] = [];
  booksRecommended: Book[] = [];

  display = false;

  constructor(private bookService: BookService) { }

  ngOnInit(): void {
    this.getAllBooks();
    this.getAllBooksOrdered();
  }

  getAllBooks() {
    this.bookService.getAllBooks()
      .subscribe(response => {
          this.books = response;
        }
      );
  }

  getAllBooksOrdered() {
    this.bookService.getAllBooksRecommended()
      .subscribe(response => {
          this.booksRecommended = response;
        }
      );
  }

  onPressView() {
    //this.display = true;

    //To toggle the component
    this.display = !this.display;
  }

  onPressEdit() {
    //this.display = true;

    //To toggle the component
    this.display = !this.display;
  }

}

