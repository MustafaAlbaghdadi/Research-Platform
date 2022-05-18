import {Langauge} from "../Types";
import {Action} from "../../../Store";
import {ActionTypes} from "../../../ActionTypes";



export const ChangeLangAction = (lang: Langauge): Action<Langauge> => {
    return {
        type: ActionTypes.CHANGE_LANG,
        payload: lang
    }
};

