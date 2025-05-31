import { Component } from '@angular/core';
import { Song } from '../../api/client';
import { SongService } from '../../services/song/song.service';

@Component({
  selector: 'app-add-song-form',
  templateUrl: './add-song-form.component.html',
  styleUrls: ['./add-song-form.component.css']
})
export class AddSongFormComponent {
  newSong: Omit<Song, 'id'> = { name: '', singerName: '', album: '' }; 
  successMessage: string = '';
  errorMessage: string = '';

  constructor(private songService: SongService) { }

  onSubmit(): void {
    this.successMessage = '';
    this.errorMessage = '';

    if (!this.newSong.name || !this.newSong.singer?.name) {
      this.errorMessage = 'שם השיר ושם האמן הם שדות חובה.';
      return;
    }

    this.songService.addSong(this.newSong).subscribe({
      next: (song) => {
        this.successMessage = `השיר "${song.name}" נוסף בהצלחה!`;
        // איפוס הטופס לאחר שליחה מוצלחת
        this.newSong = { name: '', artist: '', album: '' };
        // ייתכן שתרצה/י לרענן את רשימת השירים בקומפוננטה אחרת (לדוגמה, SongListComponent)
        // ניתן לעשות זאת באמצעות Service עם Subject/EventEmitter או לטעון מחדש את הרשימה אם הטופס והרשימה נמצאים באותו עמוד/קומפוננטת אב.
      },
      error: (err) => {
        console.error('Failed to add song:', err);
        this.errorMessage = 'שגיאה בהוספת השיר. אנא נסה/י שוב.';
      }
    });
  }
}