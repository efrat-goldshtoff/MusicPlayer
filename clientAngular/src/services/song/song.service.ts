import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Song } from '../../api/client';



@Injectable({
  providedIn: 'root'
})
export class SongService {
  private apiUrl = 'https://localhost:7001/api/Songs'; 

  constructor(private http: HttpClient) { }

  getSongs(): Observable<Song[]> {
    return this.http.get<Song[]>(this.apiUrl);
  }

  addSong(song: Omit<Song, 'id'>): Observable<Song> { 
    return this.http.post<Song>(this.apiUrl, song);
  }

  // ניתן להוסיף כאן גם מתודות ל:
  // updateSong(song: Song): Observable<Song>
  // deleteSong(id: number): Observable<void>
}