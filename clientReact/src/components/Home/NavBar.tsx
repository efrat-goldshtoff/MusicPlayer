import { useContext } from "react"
import { UserContext } from "../Login/UserContext"
import { Link } from "react-router-dom";

const style = {
    marginRight: "10px",
    color: 'blue'
}

const NavBar = () => {
    const context = useContext(UserContext);
    return (<>
        <nav style={{ position: 'fixed', top: '5px', right: '50px' }}>
            <Link to='/'
                style={style}>
                Home
            </Link>
            {context?.user && context.user.id && (
                <Link to='/allSongs'
                    style={style}>
                    MySongs
                </Link>
            )}
        </nav>
    </>)
}
export default NavBar;