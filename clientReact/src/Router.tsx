import { createBrowserRouter } from "react-router-dom";
import AppLayout from "./components/Home/AppLayout";
import AllSongs from "./components/Songs/AllSongs";

const myRouter =
    createBrowserRouter([
        {
            path: '/',
            element: <AppLayout />,
            errorElement: <>main error</>,
            children: [
                {
                    path: '/allSongs',
                    element: <AllSongs />
                }
            ]
        }
    ]);
export default myRouter