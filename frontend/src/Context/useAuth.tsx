import React, { createContext, useEffect, useState } from "react";
import { UserProfile } from "../Models/User.tsx";
import { loginAPI, registerAPI } from "../Services/AuthService.tsx";
import { toast } from "react-toastify";
import axios from "axios";

type UserContextType = {
    user: UserProfile | null;
    token: string | null;
    registerUser: (email: string, username: string, password: string) => void; 
    loginUser: (username: string, password: string) => void;
    logout: () => void;
    isLoggedIn: () => boolean;
};

type Props = { children: React.ReactNode};

const UserContext = createContext<UserContextType>({} as UserContextType);

export const UserProvider = ({ children }: Props) => {
    const [token, setToken] = useState<string | null>(null);
    const [user, setUser] = useState<UserProfile | null>(null);
    const [isReady, setIsReady] = useState(false);

    useEffect(() => {
        const user = localStorage.getItem("user");
        const token = localStorage.getItem("token");

        if(user && token) {
            setUser(JSON.parse(user));
            setToken(token);
            axios.defaults.headers.common["Authorization"] = "Bearer" + token;
        }
        setIsReady(true);
    }, []);

    const registerUser = async (email: string, username: string, password: string) => {
        try {
            const res = await registerAPI(email, username, password);
            if(res) {
                localStorage.setItem("token", res?.data.token);
                const userObj = {
                    userName: res?.data.userName,
                    email: res?.data.email
                }
                localStorage.setItem("user", JSON.stringify(userObj));
                setToken(res?.data.token!);
                setUser(userObj!);
                toast.success("Login Successful");
                window.location.href = "/dashboard";
            }
        } catch (e) {
            toast.warning("server error occurred");
        }
    };

    const loginUser = async (username: string, password: string) => {
        try {
            const res = await loginAPI(username, password);
            if(res) {
                localStorage.setItem("token", res?.data.token);
                const userObj = {
                    userName: res?.data.userName,
                    email: res?.data.email
                }
                localStorage.setItem("user", JSON.stringify(userObj));
                setToken(res?.data.token!);
                setUser(userObj!);
                toast.success("Login Successful");
                window.location.href = "/dashboard";
            }
        } catch (e) {
            toast.warning("server error occurred");
        }
    };

    const isLoggedIn = () => {
        return !!user;
    }

    const logout = () => {
        localStorage.removeItem("token");
        localStorage.removeItem("user");
        setUser(null);
        setToken("");
        window.location.href = "/";
    }

    return (
        <UserContext.Provider value={{ loginUser, user, token, logout, isLoggedIn, registerUser}}>
            {isReady ? children : null}
        </UserContext.Provider> 
    )
}

export const useAuth = () => React.useContext(UserContext);



