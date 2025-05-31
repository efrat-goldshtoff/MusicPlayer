import { Component, OnInit } from '@angular/core';
import { Song } from '../../api/client';
import { SongService } from '../../services/song/song.service';

@Component({
  selector: 'app-song-list',
  templateUrl: './song-list.component.html',
  styleUrls: ['./song-list.component.css']
})
export class SongListComponent implements OnInit {
  songs: Song[] = [];
  errorMessage: string = '';

  constructor(private songService: SongService) { }

  ngOnInit(): void {
    this.loadSongs();
  }

  loadSongs(): void {
    this.songService.getSongs().subscribe({
      next: (data) => {
        this.songs = data;
        this.errorMessage = '';
      },
      error: (err) => {
        console.error('Failed to load songs:', err);
        this.errorMessage = 'Failed to load songs. Please try again later.';
      }
    });
  }

  playSong(song: Song): void {
    console.log(`מנגן את השיר: ${song.name} - ${song.singer?.name}`);
  }
}