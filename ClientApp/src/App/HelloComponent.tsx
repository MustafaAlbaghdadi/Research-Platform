import React, {Component} from 'react';
import {connect} from "react-redux";
import {AuthInfo} from "./Login/Data/Types";
import {Store} from "../Bootstrap/Store";

interface State {
    res: number;
}

interface Props {
    authInfo: AuthInfo;
}

class HelloComponent extends Component<Props, State> {
    constructor(props: Props) {
        super(props);
        this.state = {res: 0}

    }


    componentDidMount(): void {


    }

    render() {
        return (
            <div className="bg-blue-500 w-full h-full">
                Hello

            </div>
        );
    }
}

export default connect((store: Store) => {
    return {
        authInfo: store.LoginReducer
    }
})(HelloComponent)