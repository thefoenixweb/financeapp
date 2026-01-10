import axios from "axios";
import { handleError } from "../Helpers/ErrorHandler.tsx";
import { UserProfileToken } from "../Models/User.tsx";

const api = "myfinanceapp-hsesc2c9atb0h8cs.southafricanorth-01.azurewebsites.net/api/";

export const loginAPI = async (username: string, password: string) => {

    //connecting over the internet so a try catch is essential for the unexpected
    try {
                                    //where the api and the frontend connect
                                    //data sent through as an object
        const data = await axios.post<UserProfileToken>(api + "account/login", {

            username: username,
            password: password,

        });
        return data;

    } catch(error) {
        handleError(error);

    }

};



//same as login api but modified
    export const registerAPI = async (email: string, username: string, password: string) => {

        //connecting over the internet so a try catch is essential for the unexpected
        try {
                                        //where the api and the frontend connect
                                        //data sent through as an object
            const data = await axios.post<UserProfileToken>(api + "account/register", {
    
                email: email,
                username: username,
                password: password,
    
            });
            return data;
    
        } catch(error) {
            handleError(error);
    
        };

} 


