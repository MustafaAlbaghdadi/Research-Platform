import {createStore} from 'redux'
import {combineReducers} from 'redux';
import {AuthInfo} from "../App/Login/Data/Types";
import {LoginReducer} from "../App/Login/Data/Reducers/Reducers";

import {ActionTypes} from "./ActionTypes";
import {Langauge} from "./Langs/Data/Types";
import {ChangeLangReducer} from "./Langs/Data/Reducers/Reducers";




export interface Store {
    LoginReducer:AuthInfo
    ChangeLangReducer:Langauge
 }


const rootReducers = combineReducers({
    LoginReducer,
    ChangeLangReducer
});


export default () => {
    return createStore(rootReducers);
}


export interface Action<T = any> {
    type: ActionTypes;
    payload: T;
}