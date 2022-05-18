import {Office} from "../Data/Office";
import Axios, {AxiosResponse} from "axios";
import {ROUTES} from "../../../Bootstrap/ROUTEs";

export class OfficeIO {
    public async Create(office: Office): Promise<AxiosResponse<Office>> {
        return Axios.post(ROUTES.CREATE_OFFICE, office);
    }
    public async Offices() :Promise<AxiosResponse<Office[]>>{
        return  Axios.get(ROUTES.OFFICES);
    }
}