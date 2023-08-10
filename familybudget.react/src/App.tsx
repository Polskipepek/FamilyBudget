import "./App.css";
import { Link, Outlet, Route, Routes } from "react-router-dom";
import Resources from "./Resources";
import UserProfilePage from "./Components/Pages/UserProfilePage";
import { Children, createContext, useContext, useEffect, useState } from "react";
import { IUser } from "./Services/GeneratedClient";
import { AuthProvider } from "./Core/Auth/AuthProvider";
import LoginPage from "./Components/Pages/LoginPage";
import { RequireAuth } from "./Core/Auth/RequireAuth";
import BasicLayout from "./Components/BasicLayout";

const usePersistentState = (key: string, defaultValue: any) => {
	const _key = `persistent_state_${key}`;
	const [getPersistentState, setPersistentState] = useState(() => {
		var storageItem = localStorage.getItem(_key);
		if (storageItem) {
			try {
				return JSON.parse(storageItem);
			} catch {
				return defaultValue;
			}
		}
		return defaultValue;
	});

	useEffect(() => {
		localStorage.setItem(_key, JSON.stringify(getPersistentState));
	}, [key, getPersistentState]);
	return [getPersistentState, setPersistentState];
};

export interface IPersistentState {
	usePersistentState: (key: string, defaultValue: any) => any[];
}

export interface IAppContext {
	toggleUser: ((newAppUser: IUser | undefined) => void) | undefined;
	user: IUser | undefined;
	refreshPage: (() => void) | undefined;
}

export const PersistentStateContext = createContext<IPersistentState>({ usePersistentState: usePersistentState });

const defaultAppContext: IAppContext = {
	toggleUser: undefined,
	user: undefined,
	refreshPage: undefined,
};

export const AppContext = createContext<IAppContext>(defaultAppContext);

const App: React.FunctionComponent = () => {
	const { usePersistentState } = useContext<IPersistentState>(PersistentStateContext);
	const [user, setUser] = usePersistentState(Resources.persistentKeys.User, undefined);
	const [refresh, setRefresh] = useState<boolean>(false);

	const refreshPage = () => setRefresh(!refresh);
	const toggleUser = (newAppUser: IUser | undefined) => setUser(newAppUser);


	return (
		<AuthProvider>
			<AppContext.Provider value={{ user, toggleUser, refreshPage }}>
				<Routes>
					<Route element={<BasicLayout children={"xd"} />}>
						{/* <Route path="/" element={<PublicPage />} /> */}
						<Route path="/login" element={<LoginPage />} />
						<Route
							path="/profile"
							element={
								<RequireAuth>
									<UserProfilePage />
								</RequireAuth>
							}
						/>
					</Route>
				</Routes>
				{user && <Route path={Resources.AvailablePagesFriendlyName.UserProfilePage} Component={UserProfilePage} />}
			</AppContext.Provider>
		</AuthProvider>
	);
};

export default App;


