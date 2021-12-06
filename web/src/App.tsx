import React, { useEffect } from "react";
import { LoginPage } from "./pages/authorization/loginPage/LoginPage";
import { MainPage } from "./pages/MainPage";
import { useUserStore } from "./store/userStore";
import { Redirect, Route, Switch, useHistory } from "react-router-dom";

function App() {
    const { user } = useUserStore();
    const history = useHistory();

    useEffect(() => {
        if (user == null) {
            history.push("/login");
        }
    }, [user]);

    return (
        <Switch>
            <Route
                exact
                path="/"
                render={() => <Redirect to={user ? "/home" : "/login"} />}
            />
            <Route path="/login" render={() => <LoginPage />} />
            <Route path="/home" render={() => <MainPage />} />
        </Switch>
    );
}

export default App;
