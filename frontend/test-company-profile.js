const axios = require('axios');

const BACKEND_URL = "http://localhost:5167/api";

async function testCompanyProfileFix() {
  console.log('🧪 Testing Company Profile API Fix...\n');
  
  const SYMBOL = 'AMZN';
  
  try {
    console.log(`📡 Testing: GET ${BACKEND_URL}/company-profile/${SYMBOL}/fetch`);
    const fetchResponse = await axios.get(`${BACKEND_URL}/company-profile/${SYMBOL}/fetch`);
    console.log('✅ Fetch Response Status:', fetchResponse.status);
    console.log('📊 Fetch Response Data:');
    console.log(JSON.stringify(fetchResponse.data, null, 2));
    console.log('\n' + '='.repeat(80) + '\n');
    
    console.log(`📡 Testing: GET ${BACKEND_URL}/company-profile/${SYMBOL}`);
    const getResponse = await axios.get(`${BACKEND_URL}/company-profile/${SYMBOL}`);
    console.log('✅ Get Response Status:', getResponse.status);
    console.log('📊 Get Response Data:');
    console.log(JSON.stringify(getResponse.data, null, 2));
    
  } catch (error) {
    console.error('❌ Error:', error.message);
    if (error.response) {
      console.error('Status:', error.response.status);
      console.error('Data:', error.response.data);
    }
  }
}

testCompanyProfileFix().catch(console.error); 