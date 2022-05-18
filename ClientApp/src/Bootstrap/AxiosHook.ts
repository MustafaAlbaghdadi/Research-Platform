import Axios from "axios";


export const axiosHook =()=>{
    const token = localStorage.getItem('token');
    Axios.interceptors.request.use(
        config => {
            config.headers.authorization = "Bearer " + token;
            return config;
        },
        error => {
            return Promise.reject(error);
        }
    );
};