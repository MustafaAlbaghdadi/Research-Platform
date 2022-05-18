export interface AuthInfo {
    userId:number;
    username:string;
    userType:string;
    token:string;
    expirationDate:string;
}
export interface Login {
    Username:string;
    Password:string;
}