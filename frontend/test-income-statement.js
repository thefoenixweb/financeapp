// Test script for backend income statement endpoint using Node.js and axios
const axios = require('axios');

const BACKEND_URL = 'http://localhost:5167/api';

(async () => {
  try {
    const { data } = await axios.get(`${BACKEND_URL}/financial-statement/fmp/income/AAPL`);
    console.log('Income statement for AAPL:', data);
  } catch (error) {
    if (error.response) {
      console.error('Error response:', error.response.status, error.response.data);
    } else if (error.request) {
      console.error('No response received:', error.request);
    } else {
      console.error('Error:', error.message);
    }
    console.error('Full error object:', error);
  }
})(); 