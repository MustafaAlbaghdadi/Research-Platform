import {AuthInfo} from "../Types";
import {Action} from "../../../../Bootstrap/Store";
import {ActionTypes} from "../../../../Bootstrap/ActionTypes";
import Axios from "axios";


const token = localStorage.getItem('token');
const expirationDate = localStorage.getItem('expirationDate');
const userId = localStorage.getItem('userId');
const username = localStorage.getItem('username');
const userType = localStorage.getItem('userType');
export const InitialLogin: AuthInfo = {
    token: token ? token : '',
    expirationDate: expirationDate ? expirationDate : '',
    username: username ? username : '',
    userId: parseInt(userId ? userId : '0'),
    userType: userType ? userType : '',
};

export function LoginReducer(state: AuthInfo = InitialLogin, action: Action<AuthInfo>): AuthInfo {
    switch (action.type) {

        case ActionTypes.LOGIN:
            state = {
                ...state,
                token: action.payload.token,
                expirationDate:action.payload.expirationDate,
                userId:action.payload.userId,
                username:action.payload.username,
                userType:action.payload.userType
            };
            localStorage.setItem('token', action.payload.token);
            localStorage.setItem('userType', action.payload.userType);
            localStorage.setItem('username', action.payload.username);
            localStorage.setItem('userId', action.payload.userId.toString());
            localStorage.setItem('expirationDate', action.payload.expirationDate);

            return state;
    }
    return state;

}