import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment'
import { Note } from '../models/note';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NotesService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  public getNotes(): Observable<Note[]> {
    return this.http.get<Note[]>(this.baseUrl + 'notes/');
  }

  public getNote(id: number): Observable<Note> {
    return this.http.get<Note>(this.baseUrl + 'notes/' + id);
  }

  public addNote(note: Note) {
    return this.http.post(this.baseUrl + 'notes/', note);
  }

  public deleteNote(id: number) {
    return this.http.delete(this.baseUrl + 'notes/' + id);
  }

  public editNote(note: Note): Observable<object> {
    return this.http.put(this.baseUrl + 'notes/' + note.id, note)
  }
}
