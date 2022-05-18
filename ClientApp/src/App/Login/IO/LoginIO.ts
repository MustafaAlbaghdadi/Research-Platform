import {AuthInfo, Login} from "../Data/Types";
import UrlManager from "../../Shared/UrlManager";
import {ROUTES} from "../../../Bootstrap/ROUTEs";
import Axios, {AxiosResponse} from "axios";

export class LoginIO {

    public async login(login: Login): Promise<AxiosResponse<AuthInfo>> {
        const url = UrlManager.getURL(ROUTES.LOGIN);
        return await Axios.post(url, login);

    }
}