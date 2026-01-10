import axios from "axios"
// import { CompanyKeyMetrics, CompanyProfile, CompanySearch, CompanyIncomeStatement, CompanyBalanceSheet, CompanyCashFlow } from "../company";
import { CompanySearch } from "../company";


// const API_KEY = import.meta.env.VITE_API_KEY;
// const BASE_URL = "https://financialmodelingprep.com/api/v3/";
//const BACKEND_URL = "http://localhost:5167/api";
//?
const BACKEND_URL = "https://myfinanceapp-hsesc2c9atb0h8cs.southafricanorth-01.azurewebsites.net/api";

//interface to get the company search response
interface SearchResponse {
    data: CompanySearch[];
}

// //interface to get the company profile response
// interface CompanyProfileResponse {
//     data: CompanyProfile[];
// }

// //interface to get the company key metrics response
// interface CompanyKeyMetricsResponse {
//     data: CompanyKeyMetrics[];
// }



//function to get the company search response
export const searchCompanies = async (query: string) => {
  try {
    const data = await axios.get<SearchResponse>(
      `https://financialmodelingprep.com/stable/search-symbol?query=${query}&limit=10&exchange=NASDAQ&apikey=${import.meta.env.VITE_API_KEY}` // Use the API key from environment variables
    );
    return data;
  } catch (error) {
    if (axios.isAxiosError(error)) {
      console.log("error message: ", error.message);
      return error.message;
    } else {
      console.log("unexpected error: ", error);
      return "An expected error has occured.";
    }
  }
};

//function to get the company profile response
export const getCompanyProfile = async (symbol: string) => {
    try {
        // Try to get from DB first
        const { data } = await axios.get(`${BACKEND_URL}/company-profile/${symbol}`);
        if (data) return data;
    } catch (error: any) {
        if (error.response && error.response.status === 404) {
            // Not in DB, so fetch from FMP and store in DB using the correct endpoint
            const { data: fetchedData } = await axios.get(`${BACKEND_URL}/company-profile/${symbol}/fetch`);
            return fetchedData;
        }
        console.error('Error getting company profile:', error);
        return null;
    }
};

//function to get the company key metrics response (income statement)
export const getKeyMetrics = async (symbol: string) => {
    try {
        const { data } = await axios.get(`${BACKEND_URL}/financial-statement/fmp/income/${symbol}`);
        return data;
    } catch (error) {
        console.error('Error getting key metrics:', error);
        return [];
    }
};

//function to get the company income statement response
export const getIncomeStatement = async (symbol: string) => {
    try {
        // Try to get from DB first
        const { data } = await axios.get(`${BACKEND_URL}/financial-statement/fmp/income/${symbol}`);
        if (data && data.length > 0) return data;
    } catch (error: any) {
        if (error.response && error.response.status === 404) {
            // Not in DB, so fetch from FMP and store in DB using the correct endpoint
            const { data: fetchedData } = await axios.get(`${BACKEND_URL}/financial-statement/fmp/income/${symbol}/fetch`);
            return fetchedData;
        }
        console.error('Error getting income statement:', error);
        return [];
    }
};


//function to get the company balance sheet response
export const getBalanceSheet = async (symbol: string) => {
    try {
        // Try to get from DB first
        const { data } = await axios.get(`${BACKEND_URL}/financial-statement/fmp/balance/${symbol}`);
        if (data && data.length > 0) return data;
    } catch (error: any) {
        if (error.response && error.response.status === 404) {
            // Not in DB, so fetch from FMP and store in DB using the correct endpoint
            const { data: fetchedData } = await axios.get(`${BACKEND_URL}/financial-statement/fmp/balance/${symbol}/fetch`);
            return fetchedData;
        }
        console.error('Error getting balance sheet:', error);
        return [];
    }
};

//function to get the company cash flow statement response
export const getCashFlowStatement = async (symbol: string) => {
    try {
        // Try to get from DB first
        const { data } = await axios.get(`${BACKEND_URL}/financial-statement/fmp/cashflow/${symbol}`);
        if (data && data.length > 0) return data;
    } catch (error: any) {
        if (error.response && error.response.status === 404) {
            // Not in DB, so fetch from FMP and store in DB using the correct endpoint
            const { data: fetchedData } = await axios.get(`${BACKEND_URL}/financial-statement/fmp/cashflow/${symbol}/fetch`);
            return fetchedData;
        }
        console.error('Error getting cash flow statement:', error);
        return [];
    }
};



//function to get the portfolio response
export const getPortfolio = async () => {
    try {
        const token = localStorage.getItem('token');
        if (!token) {
            throw new Error('No authentication token found');
        }
        const data = await axios.get(`${BACKEND_URL}/portfolio`, {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        });
        return data;
    } catch (error) {
        console.error("Error getting portfolio:", error);
        return { data: [] };
    }
}

//function to add to portfolio
export const addToPortfolio = async (symbol: string) => {
    try {
        const token = localStorage.getItem('token');
        if (!token) {
            throw new Error('No authentication token found');
        }
        const data = await axios.post(`${BACKEND_URL}/portfolio?symbol=${symbol}`, {}, {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        });
        return data;
    } catch (error) {
        console.error("Error adding to portfolio:", error);
        throw error;
    }
}

//function to remove from portfolio
export const removeFromPortfolio = async (symbol: string) => {
    try {
        const token = localStorage.getItem('token');
        if (!token) {
            throw new Error('No authentication token found');
        }
        const data = await axios.delete(`${BACKEND_URL}/portfolio?symbol=${symbol}`, {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        });
        return data;
    } catch (error) {
        console.error("Error removing from portfolio:", error);
        throw error;
    }
}

