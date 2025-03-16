import { useReducer } from "react"
import { UserReducer, UserType } from "../Login/User"
import { UserContext } from "../Login/UserContext";
import { Outlet } from "react-router-dom";
import HomePage from "./HomePage";
import NavBar from "./NavBar";

const AppLayout = () => {

    const initUser: UserType = {
        id: '',
        firstName: '',
        lastName: '',
        email: '',
        password: ''
    }
    const [user, userDispatch] = useReducer(UserReducer, initUser);

    return (<>
        <UserContext value={{ user, userDispatch }}>
            <HomePage />
            <NavBar />
            <Outlet />
        </UserContext>
    </>)
}
export default AppLayout