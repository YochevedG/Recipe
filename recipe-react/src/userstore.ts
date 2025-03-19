import { create } from "zustand";

interface User {
    username: string;
    role: string;
    isLoggedin: boolean;
    login: (username: string, password: string) => Promise<void>;
    logout: () => void;
}

const keyname = "userstore"
export const useUserStore = create<User>(
    (set) => {
        const storedvalue = sessionStorage.getItem(keyname);
        const initialvals = storedvalue ?
            JSON.parse(storedvalue)
            : { username: "", role: "", isLoggedin: false };
        return {
            ...initialvals,
            logout: () => {
                const newstate = { username: "", role: "", isLoggedin: false };
                sessionStorage.setItem(keyname, JSON.stringify(newstate));
                set(newstate);
            },
            login: async (username: string,
                //password: string
            ) => {
                const roleval = username.toLowerCase().startsWith("a") ? "admin" : "user";
                const newstate = { username: username, role: roleval, isLoggedin: true };
                sessionStorage.setItem(keyname, JSON.stringify(newstate));
                set(newstate)
            }
        }
    }
)