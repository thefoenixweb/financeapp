const axios = require('axios');

const BACKEND_URL = 'http://localhost:5167/api/financial-statement/fmp/income';
const symbol = 'AMZN'; // Change to any symbol you want to test

async function testPostIncomeStatement() {
  try {
    console.log(`Sending POST to ${BACKEND_URL} with body:`, { symbol });
    const response = await axios.post(BACKEND_URL, { symbol });
    console.log('Response status:', response.status);
    console.log('Response data:', response.data);
  } catch (error) {
    if (error.response) {
      console.error('Error status:', error.response.status);
      console.error('Error data:', error.response.data);
    } else {
      console.error('Error:', error.message);
    }
  }
}

testPostIncomeStatement(); 