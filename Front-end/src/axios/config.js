import axios from "axios"

const urlApi = axios.create({
    baseURL: "http://localhost:5000"
});

export default urlApi;