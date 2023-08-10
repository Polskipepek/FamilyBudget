import React, { FunctionComponent, useContext, useEffect, useState } from "react";

import { IAppContext, AppContext } from "../../App";
import { IUser, UsersClient } from "../../Services/GeneratedClient";

interface IUserProfilePageProps { }

export const UserProfilePage: React.FC<IUserProfilePageProps> = (props) => {
	const { user } = useContext<IAppContext>(AppContext);
	const [editModalVisible, setEditModalVisible] = useState<boolean>(false);

	const [userData, setUserData] = useState<IUser>();

	useEffect(() => {
	}, []);

	const getUserData = () => {
		new UsersClient()
			.getUser(user?.userId ?? "")
			.then((resp) => resp != undefined && setUserData(resp))
			.catch((err) => console.log(err.message));
	};


	return (
		<>
			Profile
		</>
	);
};

export default UserProfilePage;
