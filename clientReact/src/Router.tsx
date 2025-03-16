import { createBrowserRouter } from "react-router-dom";
import AppLayout from "./components/Home/AppLayout";

const myRouter =
    createBrowserRouter([
        {
            path: '/',
            element: <AppLayout/>,
            errorElement: <>main error</>,
            children: [

            ]
        }
    ]);
export default myRouter