import { useState } from "react";
// import { UserType } from "../Login/User";
import { Box, Button } from "@mui/material";
import Login from "../Login/Login";
import AvatarUser from "../Login/AvatarUser";

const HomePage = () => {
    // const initUser: UserType = {
    //     id: '',
    //     firstName: '',
    //     lastName: '',
    //     address: '',
    //     email: '',
    //     password: '',
    //     phone: ''
    // }

    const [isLogin, setIsLogin] = useState(false);
    const [isOpen, setIsOpen] = useState(false);
    const [myType, setMyType] = useState('Login');

    const handleLoginSuccessful = () => {
        setIsLogin((now1) => {
            if (!now1)
                setIsOpen(false);
            return now1;
        })
    }

    return (<>
        {!isLogin && (
            <Box
                sx={{
                    position: "absolute",
                    top: 10,
                    left: 10,
                    display: "flex",
                    gap: 2
                }}>
                <Button variant="contained"
                    color="secondary"
                    sx={{ mx: 2 }}
                    onClick={() => {
                        setIsOpen(true);
                        setMyType('Sign');
                    }}>
                    Sign
                </Button>
                <Button variant="contained"
                    color="secondary"
                    sx={{ mx: 2 }}
                    onClick={() => {
                        setIsOpen(true);
                        setMyType('Login');
                    }}>
                    Login
                </Button>
            </Box>
        )}
        {isOpen &&
            <Login
                successLogin={handleLoginSuccessful}
                typeAction={myType}
                close={() => setIsOpen(false)}
            />}
        {isLogin && <AvatarUser />}
    </>)
}
export default HomePage;