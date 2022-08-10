import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Book } from './models/book';
import { BookService } from './services/book.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Web Library';
  books: Book[] = [];

  display = false;


  constructor(private bookService: BookService) { }

  ngOnInit() {
    this.getAllBooks();
  }

  getAllBooks(){
    this.bookService.getAllBooks()
      .subscribe(
        response => {
          this.books = response;
        }
      );
  }

  onPress() {
    //this.display = true;

    //To toggle the component
    this.display = !this.display;
  }
}


