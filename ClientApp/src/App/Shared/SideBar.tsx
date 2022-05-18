import React, {Component} from 'react';
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faHome} from "@fortawesome/free-solid-svg-icons";
import {Action, Store} from "../../Bootstrap/Store";
import {connect} from "react-redux";
import {AuthInfo} from "../Login/Data/Types";
import {LoginAction} from "../Login/Data/Actions/Actions";
import {langs} from "../../Bootstrap/Langs/Lang";
import {ChangeLangAction} from "../../Bootstrap/Langs/Data/Actions/Actions";
import {Langauge} from "../../Bootstrap/Langs/Data/Types";
import {withRouter} from 'react-router-dom';



interface Props {
    dispatch: (action: Action<any>) => void;
    authInfo: AuthInfo;
    history: any;
    langauge:Langauge;
}

interface State {

}

class SideBar extends Component<Props, State> {
    constructor(props: Props) {
        super(props);

    }


    logout = () => {
        this.props.dispatch(LoginAction({
            token: '',
            userId: 0,
            expirationDate: '',
            userType: '',
            username: ''
        }))
    };

    changeLangar = () => {
        this.props.dispatch(ChangeLangAction({
            selected: "ar"
        }))
    };changeLangen = () => {
        this.props.dispatch(ChangeLangAction({
            selected: "en"
        }))
    };

    render() {
        return (
            <div
                style={{
                    background: '#32373d'
                }}
                className="w-full xl:w-1/6 lg:w-2/12 md:w-2/6 text-center fixed bottom-0  md:top-0 md:right-0 h-16
                            sm:h-16 md:h-screen  md:border-gray-600">

                <div
                    style={{backgroundImage: `url('/bg1.jpg')`}}
                    className="w-full h-48 img bg-wrap text-center py-4 relative md:block sm:hidden">
                    <div className="absolute top-0 right-0 z-0  w-full h-full bg-teal-900 opacity-25">

                    </div>


                    <img className="rounded-full relative z-10 mx-auto w-24 h-24 mt-5 " src={"/logo.jpg"}/>

                    <p className="text-white font-bold relative mt-5 w-full z-10">{this.props.authInfo.username}</p>
                </div>

                <div className="md:relative sm:h-full md:h-auto">
                    <ul className="list-reset flex flex-row md:flex-col text-center md:text-right  sm:h-full ">

                        <li className="flex-1 sm:border-l md:border-0 " style={{
                            borderBottom: '1px solid rgba(255, 255, 255, 0.05)',
                            borderLeft: '1px solid rgba(255, 255, 255, 0.05)'
                        }}>
                            <a href="#"
                               className="transition duration-500 block py-1 md:py-5 pl-1 align-middle text-gray-800
                               no-underline hover:bg-blue-500 pr-5 sm:h-full  md:h-auto">

                                <FontAwesomeIcon icon={faHome}
                                                 className="text-white mr-0 ml-3 sm:text-sm"/>
                                <span
                                    className="pb-1 md:pb-0 text-sm md:text-base text-white md:text-white block
                                    md:inline-block ">{langs.name}</span>
                            </a>
                        </li>


                        <li className="flex-1 sm:border-l md:border-0" style={{
                            borderBottom: '1px solid rgba(255, 255, 255, 0.05)',
                            borderLeft: '1px solid rgba(255, 255, 255, 0.05)'
                        }}>
                            <a href="#" onClick={this.changeLangen}
                               className="transition duration-500 block py-1 md:py-5 pl-1 align-middle text-gray-800
                               no-underline hover:bg-blue-500 pr-5 sm:h-full  md:h-auto">

                                <FontAwesomeIcon icon={faHome}
                                                 className="text-white mr-0 ml-3 sm:text-sm"/>
                                <span
                                    className="pb-1 md:pb-0 text-sm md:text-base text-white md:text-white block
                                    md:inline-block">انكليزي</span>
                            </a>
                        </li>


                        <li className="flex-1 sm:border-l md:border-0" style={{
                            borderBottom: '1px solid rgba(255, 255, 255, 0.05)',
                            borderLeft: '1px solid rgba(255, 255, 255, 0.05)'
                        }}>
                            <a href="#" onClick={this.changeLangar}
                               className="transition duration-500 block py-1 md:py-5 pl-1 align-middle text-gray-800
                               no-underline hover:bg-blue-500 pr-5 sm:h-full  md:h-auto">

                                <FontAwesomeIcon icon={faHome}
                                                 className="text-white mr-0 ml-3 sm:text-sm"/>
                                <span
                                    className="pb-1 md:pb-0 text-sm md:text-base text-white md:text-white block
                                    md:inline-block">عربي</span>
                            </a>
                        </li>


                        <li className="flex-1 sm:border-l md:border-0" style={{
                            borderBottom: '1px solid rgba(255, 255, 255, 0.05)',
                            borderLeft: '1px solid rgba(255, 255, 255, 0.05)'
                        }}>
                            <a href="#" onClick={this.logout}
                               className="transition duration-500 block py-1 md:py-5 pl-1 align-middle text-gray-800
                               no-underline hover:bg-blue-500 pr-5 sm:h-full  md:h-auto">

                                <FontAwesomeIcon icon={faHome}
                                                 className="text-white mr-0 ml-3 sm:text-sm"/>
                                <span
                                    className="pb-1 md:pb-0 text-sm md:text-base text-white md:text-white block
                                    md:inline-block ">تسجيل خروج</span>
                            </a>
                        </li>

                    </ul>
                </div>
            </div>
        );
    }
}

export default connect((store: Store) => {
    return {
        authInfo: store.LoginReducer,
        langauge:store.ChangeLangReducer,
    }
})(withRouter(SideBar))