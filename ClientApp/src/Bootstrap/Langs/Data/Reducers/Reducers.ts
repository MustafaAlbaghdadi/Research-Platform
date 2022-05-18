import {Langauge} from "../Types";
import {Action} from "../../../Store";
import {ActionTypes} from "../../../ActionTypes";

const lang = localStorage.getItem('lang');
export const InitialLang: Langauge = {
    selected: lang ? (lang === "en" ? "en" : "ar") : "ar",
};

export function ChangeLangReducer(state: Langauge = InitialLang, action: Action<Langauge>): Langauge {
    switch (action.type) {
        case ActionTypes.CHANGE_LANG:
            state = {...state, selected: action.payload.selected};
            localStorage.setItem('lang', action.payload.selected);

            window.location.reload(false);

            return state;
    }

    return state;
}