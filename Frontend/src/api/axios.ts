import axios from 'axios';

const TOKEN_KEY = "access_token";

export const api = axios.create({
    baseURL: "https://localhost:56509",
});

api.interceptors.request.use((config) => {
    const token = localStorage.getItem(TOKEN_KEY);
    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
});
