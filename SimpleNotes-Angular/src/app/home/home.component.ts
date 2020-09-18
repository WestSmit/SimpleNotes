import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Note } from '../models/note';
import { NotesService } from '../services/notes.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  private subscriptions: Subscription[] = [];

  notes: Note[];
  newNote = new Note();

  constructor(private data: NotesService) { }

  ngOnInit() {
    this.getNotes();
  }
  
  ngOnDestroy() {
    this.subscriptions.forEach(sub => sub.unsubscribe());
  }

  getNotes() {
    var s = this.data.getNotes().subscribe(
      (next) => {
        this.notes = next;
        console.log(next);
      },
      (error) => {
        console.error(error);
      });
    this.subscriptions.push(s);
  }

  addNote() {
    if (this.newNote.text == null) {
      return;
    }

    this.data.addNote(this.newNote).subscribe(
      (next) => {
        this.getNotes();
        this.newNote = new Note();
      },
      (error) => {
        console.log(error);
      });
  }

  onDeleted(id: number) {
    this.data.deleteNote(id).subscribe(
      (next) => {
        this.getNotes();
      },
      (error) => {
        console.log(error);
      });
  }

  onChanged(note: Note) {
    this.data.editNote(note).subscribe(
      (next) => {
        this.getNotes();
      },
      (error) => {
        console.log(error);
      });
  }
}
