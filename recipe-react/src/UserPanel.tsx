import { Link } from "react-router-dom";
import { useUserStore } from "./userstore";

export default function UserPanel() {
    const isLoggedIn = useUserStore(state => state.isLoggedin);
    const username = useUserStore(state => state.username);
    const role = useUserStore(state => state.role);
    const logout = useUserStore(state => state.logout);

    return (
        <>
            {isLoggedIn ? (
                <span className="nav-link">
                    {username}, {role} <button className="btn btn-link p-0 ms-2" onClick={logout}>Logout</button>
                </span>
            ) : (
                <Link className="nav-link" to="/login">Login</Link>
            )}
        </>
    );
}