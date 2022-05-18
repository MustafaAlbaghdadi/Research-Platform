import React, {Component} from 'react';
import Route from "react-router-dom/Route";
import {AuthInfo} from "./App/Login/Data/Types";
import LoginComponent from "./App/Login/LoginComponent";
import HelloComponent from "./App/HelloComponent";
import {connect} from 'react-redux';
import {Store} from "./Bootstrap/Store";
import {Layout} from "./App/Shared/Layout";
import {Langauge} from "./Bootstrap/Langs/Data/Types";
import Lang from "./Bootstrap/Langs/Lang";
import {axiosHook} from "./Bootstrap/AxiosHook";

interface Props {
    authInfo: AuthInfo;
    changeLangReducer: Langauge;
    match: any;

}

interface State {
    authorized: boolean;
}

class Main extends Component<Props, State> {
    constructor(props: Props) {
        super(props);
        this.state = {authorized: false};
    }

    checkExpire(date1: string): boolean {
        var authDate = Date.parse(date1);

        var mydate = new Date().getDate();

        if (authDate > mydate) {
            return false
        } else {
            return true
        }

    }

    render() {
        return (

            <>

                <Lang/>
                {

                    this.checkExpire(this.props.authInfo.expirationDate) && <LoginComponent/>
                }

                {!this.checkExpire(this.props.authInfo.expirationDate) &&
                <Layout>

                    <Route path="/" component={HelloComponent}/>

                    {/*<Route exact path={"/payment/:id(\\d+)/"}*/}
                    {/*       component={({match}) => <PaymentMainComponent*/}
                    {/*           id={match.params["id"]}/>}/>*/}
                </Layout>}
                {axiosHook()}
            </>


        );
    }
}

export default connect((store: Store) => {
    return ({
        authInfo: store.LoginReducer,
        changeLangReducer:store.ChangeLangReducer
    });

})(Main);
