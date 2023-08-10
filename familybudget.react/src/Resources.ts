export default class Resources {
  public static persistentKeys = {
    User: "User",
  };

  public static AvailablePagesFriendlyName = {
    UserProfilePage: "My Profile"
  }

  public static AvailablePagesPaths = {
    UserProfilePage: "/myprofile"
  }

  public static Notifications = {
    loginForm_failureTitle: "Login",
    loginForm_failureMessage: "Incorrect login data",

    registerForm_successTitle: "Register",
    registerForm_successMessage: "Registered succesfully",
    registerForm_failureTitle: "Register",
    registerForm_failureMessage: "Incorrect registration details",

    logOut_successTitle: "Log out",
    logOut_successMessage: "Logged out successfully",
    logOut_failureTitle: "Log out",
    logOut_failureMessage: "Error logging out",

    odata_getListErrorTitle: "There was an error getting the data.",
    odata_getSingleErrorTitle: "There was an error getting the object.",

    successTitle: "The action was successful.",
    successMessage: "Yes!",

    failureTitle: "Oops!",
    failureMessage: "This board didn't stand here!",

  };

  public static Buttons = {
    layout_signIn: "Sign in",
    layout_register: "Sign up",
    layout_signOut: "Sign out",

    edit: "Edit",
    search: "Search",
  };

  public static InputPlaceholder = {
    email: "Mail",
    password: "Password",
    firstName: "First name",
    lastName: "Surname",
  };

  public static PageHeader = {
    profilePage: "Profile",
    registerPage: "Registration",
    loginPage: "Login",
  };

  public static Validation = {
    passwordConfirmation: "Password does not match",
    phoneNumber: "Phone number is not valid",
    passwordPolicy: "Password must contain a lower case letter, an upper case letter and a number",
  };
}