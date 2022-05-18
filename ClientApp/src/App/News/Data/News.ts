export interface News {
    carouselSpeed:number;
    newsItems:NewsItem[];
}
export interface NewsItem {
    titleEN:string;
    titleAR:string;
    detailsAR:string;
    detailsEN:string;
    image:string;
}