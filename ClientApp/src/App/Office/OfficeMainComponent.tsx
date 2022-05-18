import React, {Component} from 'react';
import { Route , Switch } from 'react-router';
import CreateOffice from "./UI/CreateOffice";
import Offices from "./UI/Offices";

class OfficeMainComponent extends Component {
    render() {
        return (

            <Switch>
                <Route exact path='/Office/Create' component={CreateOffice} />
                <Route path={"/"} component={Offices} />
            </Switch>
        );
    }
}

export default OfficeMainComponent;