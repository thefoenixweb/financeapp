const axios = require('axios');

const BASE_URL = 'http://localhost:5167/api'; // Adjust if your backend runs on a different port
const SYMBOL = 'AAPL'; // Change to any symbol you want to test

async function testCashFlowStatement() {
  const url = `${BASE_URL}/cashflow/${SYMBOL}`;
  console.log('🧪 Testing Cash Flow Statement API...');

  // 1. Try GET
  console.log(`\n📡 GET ${url}`);
  let needPost = false;
  try {
    const res = await axios.get(url);
    console.log('✅ GET Response Status:', res.status);
    console.log('📊 GET Response Data:');
    console.dir(res.data, { depth: null });
    return;
  } catch (err) {
    if (err.response && err.response.status === 404) {
      console.log('❌ GET 404 Not Found, will POST to fetch/store from FMP...');
      needPost = true;
    } else {
      console.error('❌ GET Error:', err.message);
      return;
    }
  }

  // 2. POST to fetch/store from FMP
  if (needPost) {
    console.log(`\n📡 POST ${url}`);
    try {
      const postRes = await axios.post(url);
      console.log('✅ POST Response Status:', postRes.status);
      console.log('📊 POST Response Data:');
      console.dir(postRes.data, { depth: null });
    } catch (err) {
      if (err.response) {
        console.error('❌ POST Error Status:', err.response.status);
        console.error('❌ POST Error Data:', err.response.data);
      } else {
        console.error('❌ POST Error:', err.message);
      }
      return;
    }
  }

  // 3. GET again
  console.log(`\n📡 GET (after POST) ${url}`);
  try {
    const res2 = await axios.get(url);
    console.log('✅ GET (after POST) Response Status:', res2.status);
    console.log('📊 GET (after POST) Response Data:');
    console.dir(res2.data, { depth: null });
  } catch (err) {
    if (err.response) {
      console.error('❌ GET (after POST) Error Status:', err.response.status);
      console.error('❌ GET (after POST) Error Data:', err.response.data);
    } else {
      console.error('❌ GET (after POST) Error:', err.message);
    }
  }
}

testCashFlowStatement(); 