import ApplicationConfiguration from "../../Bootstrap/Config";

export default class UrlManager {
    private static BASE_URL: string = ApplicationConfiguration.base_url;

    public static getURL(route: string): string {
        return this.BASE_URL + route;
    }

    public static getStorageUrl(route: string): string {
        return this.BASE_URL + "/storage/" + route;
    }

}
