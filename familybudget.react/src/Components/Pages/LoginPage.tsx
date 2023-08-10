import { IUser } from "../../Services/GeneratedClient"
import { LoginForm } from "../Authorization/Login/LoginForm"

interface ILoginPageProps { }

const LoginPage: React.FC<ILoginPageProps> = (props) => {

    return (
        <>
            <LoginForm toggleUser={(user: IUser | undefined) => { }} closeModal={() => { }} />
        </>
    );
};

export default LoginPage;
