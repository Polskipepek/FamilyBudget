import React from "react";
import { AuthContextType } from "./IAuthContextType";

export let AuthContext = React.createContext<AuthContextType>(null!);