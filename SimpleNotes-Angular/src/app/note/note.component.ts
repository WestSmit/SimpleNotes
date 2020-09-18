import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Note } from '../models/note';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.scss']
})
export class NoteComponent{
  @Input() note: Note;
  @Output() onDeleted = new EventEmitter<number>();
  @Output() onChanged = new EventEmitter<Note>();

  delete() {
    this.onDeleted.emit(this.note.id);
  }
  save() {
    this.onChanged.emit(this.note);
  }
}
