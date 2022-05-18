import {AuthInfo} from "../Types";
import {Action} from "../../../../Bootstrap/Store";
import {ActionTypes} from "../../../../Bootstrap/ActionTypes";

export const LoginAction=(login:AuthInfo):Action<AuthInfo>=>{
    return {
        type:ActionTypes.LOGIN,
        payload:login
    }
};
