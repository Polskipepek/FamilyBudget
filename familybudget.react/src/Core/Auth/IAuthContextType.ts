import { IUser } from "../../Services/GeneratedClient";

export interface AuthContextType {
    user: IUser;
    signin: (user: IUser, callback: VoidFunction) => void;
    signout: (callback: VoidFunction) => void;
}