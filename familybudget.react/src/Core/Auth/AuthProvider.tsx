import React from "react";
import { BasicAuthProvider } from "../../auth";
import { IUser } from "../../Services/GeneratedClient";
import { AuthContext } from "./AuthContext";


export function AuthProvider({ children }: { children: React.ReactNode }) {
    let [user, setUser] = React.useState<any>(null);

    let signin = (newUser: IUser, callback: VoidFunction) => {
        return BasicAuthProvider.signin(() => {
            setUser(newUser);
            callback();
        });
    };

    let signout = (callback: VoidFunction) => {
        return BasicAuthProvider.signout(() => {
            setUser(null);
            callback();
        });
    };

    let value = { user, signin, signout };

    return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
}