import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  title = 'clientAngular';

  setEmojiFavicon(emoji: string) {
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
  ngOnInit(): void {
    this.setEmojiFavicon("🎵");

  }
}
