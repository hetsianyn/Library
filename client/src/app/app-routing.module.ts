import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookListComponent } from './components/book-list/book-list.component';
import { BooksPageComponent } from './components/books-page/books-page.component';
import { EditBookComponent } from './components/edit-book/edit-book.component';
import { ViewBookComponent } from './components/view-book/view-book.component';

const routes: Routes = [
  {path: '', component: BooksPageComponent},
  {path: '', component: BookListComponent, outlet: 'secondary'},
  {path: '**', component: BooksPageComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
