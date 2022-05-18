import React, {Component} from 'react';
import {Action, Store} from "../../Bootstrap/Store";
import {connect} from "react-redux";
import {LoginIO} from "./IO/LoginIO";
import {LoginAction} from "./Data/Actions/Actions";
import {AxiosResponse} from "axios";
import {AuthInfo, Login} from "./Data/Types";
import history from "../Shared/history";

interface Props {
    dispatch: (action: Action<any>) => void;
    login: AuthInfo;
}

interface State {
    username: string;
    password: string;
    loading: boolean;
    error: boolean;
}

class LoginComponent extends Component<Props, State> {
    loginIO: LoginIO;

    constructor(props: Props) {
        super(props);
        this.state = {username: '', password: '', loading: false, error: false};
        this.loginIO = new LoginIO();
    }


    submit = async (event) => {

        event.preventDefault();
        if (this.state.username === '' || this.state.password === '')
            return;

        const login: Login = {
            Username: this.state.username,
            Password: this.state.password
        };

        this.setState({loading: true});
        let response: AxiosResponse<AuthInfo>;
        try {
            response = await this.loginIO.login(login);
            this.setState({loading: false});

        } catch (e) {
            this.setState({loading: false, error: true});
            return;

        }

        this.props.dispatch(LoginAction(response.data));
        window.location.href = "/";
    };

    changeUsername = (event) => {
        this.setState({username: event.target.value, error: false});


    };
    changePassword = (event) => {
        this.setState({password: event.target.value, error: false});


    };

    render() {
        return (
            <div
                className="min-h-screen flex items-center justify-center bg-gray-50 py-12 px-4 sm:px-6 lg:px-8 text-right">

                <div className="max-w-md w-full">
                    <div>
                        <img className="mx-auto h-12 w-auto"
                             src="https://tailwindui.com/img/logos/workflow-mark-on-white.svg" alt="Workflow"/>
                        <h2 className="mt-6 text-center text-3xl leading-9 font-extrabold text-gray-900">
                            Sign in to your account
                        </h2>
                        <p className="mt-2 text-center text-sm leading-5 text-gray-600">
                            Or
                            <a href="#"
                               className="font-medium text-indigo-600 hover:text-indigo-500 focus:outline-none focus:underline transition ease-in-out duration-150">
                                start your 14-day free trial
                            </a>
                        </p>
                    </div>
                    <form className="mt-8">
                        <input type="hidden" name="remember" value="true"/>
                        <div className="rounded-md shadow-sm">
                            <div>
                                <input disabled={this.state.loading} onChange={this.changeUsername}
                                       aria-label="Email address" name="email"
                                       type="text" required
                                       className="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-t-md focus:outline-none focus:shadow-outline-blue focus:border-blue-300 focus:z-10 sm:text-sm sm:leading-5"
                                       placeholder="Email address"/>
                            </div>
                            <div className="-mt-px">
                                <input disabled={this.state.loading} aria-label="Password" name="password"
                                       type="password" required
                                       onChange={this.changePassword}
                                       className="appearance-none rounded-none relative block w-full px-3 py-2 border border-gray-300 placeholder-gray-500 text-gray-900 rounded-b-md focus:outline-none focus:shadow-outline-blue focus:border-blue-300 focus:z-10 sm:text-sm sm:leading-5"
                                       placeholder="Password"/>
                            </div>
                        </div>

                        {this.state.error &&
                        <div className="mt-6  justify-between">

                            <div className="text-sm leading-5 text-right text-red-700">
                                خطءا في اسم المستخدم او كلمة المرور *
                            </div>
                        </div>
                        }


                        <div className="mt-6">
                            <button disabled={this.state.loading} type="submit"
                                    onClick={this.submit}
                                    className="group relative w-full flex justify-center py-2 px-4 border border-transparent text-sm leading-5 font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-500 focus:outline-none focus:border-indigo-700 focus:shadow-outline-indigo active:bg-indigo-700 transition duration-150 ease-in-out">
                                          <span className="absolute left-0 inset-y-0 flex items-center pl-3">
                                            <svg
                                                className="h-5 w-5 text-indigo-500 group-hover:text-indigo-400 transition ease-in-out duration-150"
                                                fill="currentColor" viewBox="0 0 20 20">
                                              <path fill-rule="evenodd"
                                                    d="M5 9V7a5 5 0 0110 0v2a2 2 0 012 2v5a2 2 0 01-2 2H5a2 2 0 01-2-2v-5a2 2 0 012-2zm8-2v2H7V7a3 3 0 016 0z"
                                                    clip-rule="evenodd"/>
                                            </svg>
                                          </span>
                                Sign in
                            </button>
                        </div>
                    </form>
                </div>
            </div>
        );
    }


}

export default connect((store: Store) => {
    console.log(store);
    return {
        login: store.LoginReducer
    }
})(LoginComponent)