import { Link } from "react-router-dom";
import { AppBar, Box, Button, Toolbar } from "@mui/material";
import { useContext } from "react";
import { UserContext } from "../Login/UserContext";

const NavBar = () => {
    const context = useContext(UserContext);
    const isUserLoggedIn = !!context?.user.id;
    return (<>
        <AppBar position="static" color="default" elevation={2}>
            <Toolbar sx={{ justifyContent: "flex-end" }}>
                <Box sx={{ display: 'flex', gap: 2 }}>
                    <Button
                        component={Link}
                        to="/"
                        color="secondary"
                        variant="text"
                    >
                        Home
                    </Button>
                    {isUserLoggedIn && (
                        <Button
                            component={Link}
                            to="/songs"
                            color="secondary"
                            variant="text"
                        >
                            My Songs
                        </Button>
                    )}
                    {/* {isUserLoggedIn && ( */}
                        <Button
                            component={Link}
                            to='/playList'
                            color="secondary"
                            variant="text"
                        >
                            PlayList
                        </Button>
                    {/* )} */}
                    {/* {isUserLoggedIn && ( */}
                        <Button
                            color="secondary"
                            variant="text"
                            onClick={() => {
                                context?.userDispatch({ type: 'REMOVE', data: {} });
                                localStorage.removeItem('token');
                                alert('Logged out successfully!');
                            }}
                        >
                            Logout
                        </Button>
                    {/* )} */}
                </Box>
            </Toolbar>
        </AppBar>
    </>)
}
export default NavBar;