// import { useContext } from "react"
// import { UserContext } from "../Login/UserContext"
import { Link } from "react-router-dom";
import { AppBar, Box, Button, Toolbar } from "@mui/material";

// const style = {
//     marginRight: "10px",
//     color: 'purple'
// }

const NavBar = () => {
    // const context = useContext(UserContext);
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
                    {/* {context?.user && context.user.id && ( */}
                    <Button
                        component={Link}
                        to="/songs"
                        color="secondary"
                        variant="text"
                    >
                        My Songs
                    </Button>
                    {/* )} */}
                    {/* {context?.user && context.user.id && ( */}
                    <Button
                        component={Link}
                        to='/playList'
                        color="secondary"
                        variant="text"
                    >
                        PlayList
                    </Button>
                    {/* )} */}
                </Box>
            </Toolbar>
        </AppBar>
        {/* <nav style={{
            position: 'fixed',
            top: '5px',
            right: '50px'
        }}>
            <Link to='/'
                style={style}>
                Home
            </Link>
            {context?.user && context.user.id && (
                <Link to='/songs'
                    style={style}>
                    MySongs
                </Link>
            )}
        </nav> */}
    </>)
}
export default NavBar;