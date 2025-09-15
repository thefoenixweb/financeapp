import axios from "axios";
import { handleError } from "../Helpers/ErrorHandler.tsx";
import { PortfolioGet, PortfolioPost } from "../Models/Portfolio";

const api = "https://financeapp-fvemb9b0fhgdhyce.southafricanorth-01.azurewebsites.net/portfolio/";

export const portfolioAddAPI = async (stockSymbol: string, token: string) => {
    try {
        const config = {
            headers: {
                Authorization: `Bearer ${token}`,
            },
        };
        const response = await axios.post<PortfolioPost>(api + `?symbol=${stockSymbol}`, {}, config);
        return { data: response.data, error: null };
    } catch (error) {
        const errorMessage = handleError(error);
        return { data: null, error: errorMessage };
    }
}

export const portfolioDeleteAPI = async (stockSymbol: string, token: string) => {
    try {
        const config = {
            headers: {
                Authorization: `Bearer ${token}`,
            },
        };
        const response = await axios.delete<PortfolioPost>(api + `?symbol=${stockSymbol}`, config);
        return { data: response.data, error: null };
    } catch (error) {
        const errorMessage = handleError(error);
        return { data: null, error: errorMessage };
    }
}

                                //dont need to pass the stock symbol as a query parameter because we are getting all the stocks
export const portfolioGetAPI = async (token: string) => {
    try {
        const config = {
            headers: {
                Authorization: `Bearer ${token}`,
            },
        };
        const response = await axios.get<PortfolioGet[]>(api, config);
        return { data: response.data, error: null };
    } catch (error) {
        const errorMessage = handleError(error);
        return { data: null, error: errorMessage };
    }
}