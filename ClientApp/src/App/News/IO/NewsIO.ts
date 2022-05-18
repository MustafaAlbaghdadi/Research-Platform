import {NewsItem} from "../Data/News";
import Axios, {AxiosResponse} from "axios";
import {ROUTES} from "../../../Bootstrap/ROUTEs";

export class NewsIO {
    public async CreateNewsItem(newsItem: NewsItem, file: any): Promise<AxiosResponse<NewsItem>> {
        let formData: FormData = new FormData();
        formData.append("file", file);
        const postData = JSON.stringify(newsItem);
        formData.append("newsItem", postData);
        return await Axios.post(ROUTES.CREATE_NEWS_ITEM, formData);
    }
}
