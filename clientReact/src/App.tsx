import { RouterProvider } from 'react-router-dom'
import './App.css'
import myRouter from './Router'


function App() {

  function setEmojiFavicon(emoji: string) {
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

  setEmojiFavicon("🎶");


  return (
    <>
      <RouterProvider router={myRouter} />
    </>
  )
}

export default App
