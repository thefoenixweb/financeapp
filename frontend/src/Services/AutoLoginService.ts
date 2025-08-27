import axios from 'axios';

const BACKEND_URL = 'https://financeapp-fvemb9b0fhgdhyce.southafricanorth-01.azurewebsites.net/api/account';

export interface AutoLoginResponse {
  userName: string;
  email: string;
  token: string;
}

export const autoLoginWithSeededUser = async (): Promise<AutoLoginResponse | null> => {
  try {
    const response = await axios.post(`${BACKEND_URL}/login`, {
      username: 'string',
      password: 'StringLord555!'
    });
    
    if (response.status === 200) {
      return response.data;
    }
    return null;
  } catch (error) {
    console.error('Auto-login failed:', error);
    return null;
  }
};
