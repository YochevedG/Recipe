import Login from "./Login";
import { useUserStore } from "./userstore"

interface Props { element: React.ReactNode, requiredrole: string }
export default function ProtectedRoute({ element, requiredrole }: Props) {
    const isLoggedIn = useUserStore(state => state.isLoggedin);
    const role = useUserStore(state => state.role);
    const hasprivilege = requiredrole == "" || requiredrole == role;
    if (!isLoggedIn) {
        return <Login />
    }
    else if (!hasprivilege) {
        return <div>Access Denied</div>
    }
    else {
        return <>{element}</>
    }
}
