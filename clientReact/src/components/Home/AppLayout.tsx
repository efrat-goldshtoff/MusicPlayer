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
     <div style={{ height: '90vh', overflow: 'hidden', display: 'flex', flexDirection: 'column' }}>
        <UserContext value={{ user, userDispatch }}>
            <HomePage />
            <NavBar />
            <div style={{ flex: 1, overflow: 'auto' }}>
                <Outlet />
            </div>
        </UserContext>
    </div>
        {/* <UserContext value={{ user, userDispatch }}>
            <HomePage />
            <NavBar />
            <Outlet />
        </UserContext> */}
    </>)
}
export default AppLayout