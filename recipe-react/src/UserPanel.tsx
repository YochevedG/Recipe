import { Link } from "react-router-dom";
import { useUserStore } from "./userstore";

export default function UserPanel() {
    const isLoggedIn = useUserStore(state => state.isLoggedin);
    const username = useUserStore(state => state.username);
    const role = useUserStore(state => state.role);
    const logout = useUserStore(state => state.logout);

    return (
        <>
            {isLoggedIn ?
                (<><span>{username}, {role} </span> <button onClick={logout}>Logout</button></>)
                :
                (<Link to="/login">Login</Link>)}
        </>
    )
}
