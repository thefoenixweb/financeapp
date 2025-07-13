import axios from 'axios';

const API_URL = 'http://localhost:5167/api';

export const fetchCompanyProfile = async (symbol: string) => {
  const response = await axios.get(`${API_URL}/CompanyProfile/${symbol}`);
  return response.data;
}; 