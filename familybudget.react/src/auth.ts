
const BasicAuthProvider = {
    isAuthenticated: false,
    signin(callback: VoidFunction) {
        BasicAuthProvider.isAuthenticated = true;
    },
    signout(callback: VoidFunction) {
        BasicAuthProvider.isAuthenticated = false;
    },
};

export { BasicAuthProvider };