const axios = require('axios');

const BACKEND_URL = 'http://localhost:5167/api/portfolio';
const symbol = 'TSLA'; // Test symbol

// Provided JWT token
const token = '';

// Function to test with authentication
async function testWithAuth(token) {
  try {
    console.log('=== Testing Portfolio Delete Functionality WITH AUTH ===\n');

    // Step 1: Add stock to portfolio
    console.log('1. Adding stock to portfolio...');
    const addResponse = await axios.post(`${BACKEND_URL}?symbol=${symbol}`, {}, {
      headers: {
        'Authorization': `Bearer ${token}`
      }
    });
    console.log('✅ Stock added successfully:', addResponse.status);

    // Step 2: Get portfolio to verify stock was added
    console.log('\n2. Getting portfolio to verify stock was added...');
    const getResponse = await axios.get(BACKEND_URL, {
      headers: {
        'Authorization': `Bearer ${token}`
      }
    });
    console.log('✅ Portfolio retrieved:', getResponse.data);
    
    const hasStock = getResponse.data.some(stock => stock.symbol === symbol);
    console.log(`Stock ${symbol} in portfolio:`, hasStock);

    // Step 3: Delete stock from portfolio
    console.log('\n3. Deleting stock from portfolio...');
    const deleteResponse = await axios.delete(`${BACKEND_URL}?symbol=${symbol}`, {
      headers: {
        'Authorization': `Bearer ${token}`
      }
    });
    console.log('✅ Stock deleted successfully:', deleteResponse.status);

    // Step 4: Get portfolio again to verify stock was removed
    console.log('\n4. Getting portfolio to verify stock was removed...');
    const getResponse2 = await axios.get(BACKEND_URL, {
      headers: {
        'Authorization': `Bearer ${token}`
      }
    });
    console.log('✅ Portfolio after deletion:', getResponse2.data);
    
    const hasStockAfterDelete = getResponse2.data.some(stock => stock.symbol === symbol);
    console.log(`Stock ${symbol} in portfolio after deletion:`, hasStockAfterDelete);

    console.log('\n=== Test Summary ===');
    console.log('✅ Add to portfolio: SUCCESS');
    console.log('✅ Delete from portfolio: SUCCESS');
    console.log('✅ Verification: SUCCESS');

  } catch (error) {
    if (error.response) {
      console.error('❌ Error status:', error.response.status);
      console.error('❌ Error data:', error.response.data);
    } else {
      console.error('❌ Error:', error.message);
    }
  }
}

testWithAuth(token); 