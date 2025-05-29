import { useContext, useEffect, useState } from "react";
import { Button, Paper } from "@mui/material";
import Login from "../Login/Login";
import AvatarUser from "../Login/AvatarUser";
import { UserContext } from "../Login/UserContext";

// const style = {
//     border: '1px solid purple',
//     color: 'purple'
// }

const HomePage = () => {
    const context = useContext(UserContext);
    const [isLogin, setIsLogin] = useState(false);
    const [isOpen, setIsOpen] = useState(false);
    const [myType, setMyType] = useState('Login');

    useEffect(() => {
        setIsLogin(!!context?.user.id);
    }, [context?.user.id])

    const handleLoginSuccessful = () => {
        setIsOpen(false);
        setIsLogin(true);
    }

    return (<>

        {!isLogin && (
            <Paper
                elevation={3}
                sx={{
                    position: "absolute",
                    top: 20,
                    left: 20,
                    padding: 2,
                    borderRadius: 2,
                    display: "flex",
                    gap: 2
                }}>
                <Button
                    variant="outlined"
                    color="secondary"
                    onClick={() => {
                        setIsOpen(true);
                        setMyType('Sign');
                    }}>
                    Sign
                </Button>
                <Button
                    variant="outlined"
                    color="secondary"
                    onClick={() => {
                        setIsOpen(true);
                        setMyType('Login');
                    }}>
                    Login
                </Button>
            </Paper>
        )}
        {isOpen &&
            <Login
                successLogin={handleLoginSuccessful}
                typeAction={myType}
                close={() => setIsOpen(false)}
            />}
        {isLogin && <AvatarUser />}

        {/* {!isLogin && (
            <Box
                sx={{
                    position: "absolute",
                    top: 10,
                    left: 10,
                    display: "flex",
                    gap: 2
                }}>
                <Button
                    sx={style}
                    onClick={() => {
                        setIsOpen(true);
                        setMyType('Sign');
                    }}>
                    Sign
                </Button>
                <Button
                    sx={style}
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
        {isLogin && <AvatarUser />} */}
    </>)
}
export default HomePage;