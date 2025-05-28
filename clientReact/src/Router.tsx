import { createBrowserRouter } from "react-router-dom";
import AppLayout from "./components/Home/AppLayout";
import SongsPage from "./components/Songs/SongsPage";
import PlayList from "./components/Songs/PlayList";

const myRouter =
    createBrowserRouter([
        {
            path: '/',
            element: <AppLayout />,
            errorElement: <>main error</>,
            children: [
                {
                    path: '/songs',
                    element: <SongsPage />
                },
                {
                    path: '/playList',
                    element: <PlayList />
                }
            ]
        }
    ]);
export default myRouter