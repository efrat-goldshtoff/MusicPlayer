import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SongListComponent } from '../components/song-list/song-list.component';
import { AddSongFormComponent } from '../components/add-song-form/add-song-form.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,
     SongListComponent,AddSongFormComponent
    ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  title = 'clientAngular';

  setEmojiFavicon(emoji: string) {
    if (typeof document !== 'undefined') {

      const canvas = document.createElement("canvas");
      canvas.width = 64;
      canvas.height = 64;
      const ctx = canvas.getContext("2d");
      ctx!.font = "50px Arial";
      ctx!.textAlign = "center";
      ctx!.textBaseline = "middle";
      ctx!.fillText(emoji, 32, 32);

      const favicon = document.createElement("link");
      favicon.rel = "icon";
      favicon.href = canvas.toDataURL("image/png");

      document.head.appendChild(favicon);
    }
  }
  ngOnInit(): void {
    this.setEmojiFavicon("🎵");

  }
  
}
