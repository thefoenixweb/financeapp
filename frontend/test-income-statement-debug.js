// Debug test script for backend income statement endpoint using Node.js and axios
const axios = require('axios');

const BACKEND_URL = 'http://localhost:5167/api';
const symbols = ['AMZN', 'AAPL'];

(async () => {
  for (const symbol of symbols) {
    try {
      const { data } = await axios.get(`${BACKEND_URL}/financial-statement/fmp/income/${symbol}`);
      console.log(`Income statement for ${symbol}:`, data);
    } catch (error) {
      if (error.response) {
        console.error(`Error response for ${symbol}:`, error.response.status, error.response.data);
      } else if (error.request) {
        console.error(`No response received for ${symbol}:`, error.request);
      } else {
        console.error(`Error for ${symbol}:`, error.message);
      }
      console.error('Full error object:', error);
    }
  }
})(); 