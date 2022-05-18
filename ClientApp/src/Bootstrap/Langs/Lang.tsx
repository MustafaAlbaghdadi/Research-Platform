import React, {Component} from 'react';
import {connect} from "react-redux";
import {Langauge} from "./Data/Types";
import {ILang} from "./Ilang";
import {En} from "./en";
import {Ar} from "./ar";
import {Store} from "../Store";

export let langs: ILang =Ar;

interface Props {
    SelectedLang: Langauge
}
class Lang extends Component<Props> {
    constructor(props: Props) {
        super(props);
    }

    render() {
        console.log(langs);
        if (this.props.SelectedLang.selected == "ar") {
            langs = Ar;

        } else if (this.props.SelectedLang.selected == "en") {

            langs = En;
        }
        console.log(langs);

        return (<></>);
    }
}

export default connect((store: Store) => {
    return {
        SelectedLang: store.ChangeLangReducer
    }
})(Lang)