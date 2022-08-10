import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { Book } from 'src/app/models/book';
import { BookDetailed } from 'src/app/models/book-detailed';
import { BookView } from 'src/app/models/book-view';
import { BookService } from 'src/app/services/book.service';
import  { Overlay} from '@angular/cdk/overlay'

@Component({
  selector: 'app-view-book',
  templateUrl: './view-book.component.html',
  styleUrls: ['./view-book.component.css']
})
export class ViewBookComponent implements OnInit {

    book: BookView = {
      id: 0,
      title: '',
      author: '',
      genre: '',
      content: '',
      cover: null,
      rating: 0,
      reviews: []
  }

  constructor(private bookService: BookService) { }

  ngOnInit(): void {

  }

  getBookDetailed() {
    this.bookService.getBookDetailed(this.book.id)
      .subscribe(response => {
          this.book = response;
        }
      );
  }

}
