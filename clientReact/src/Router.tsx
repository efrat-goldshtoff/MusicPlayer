import { createBrowserRouter } from "react-router-dom";
import AppLayout from "./components/Home/AppLayout";
import SongsPage from "./components/Songs/SongsPage";

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
                }
            ]
        }
    ]);
export default myRouter