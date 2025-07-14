# FinanceApp 💰📊

A comprehensive financial analysis and portfolio management application built with .NET 8 Web API and React TypeScript frontend. This application provides real-time stock data, financial statement analysis, portfolio tracking, and company profiling capabilities.

## 🌟 Features

### 📈 Stock Management
- Real-time stock data integration with Financial Modeling Prep (FMP) API
- Stock search and filtering capabilities
- Detailed stock information including market cap, volume, and price data
- Stock comparison and analysis tools

### 📊 Financial Statements
- **Income Statement Analysis** - Revenue, expenses, and profitability metrics
- **Balance Sheet Analysis** - Assets, liabilities, and shareholder equity
- **Cash Flow Statement Analysis** - Operating, investing, and financing activities
- Historical financial data tracking
- Financial ratio calculations

### 🏢 Company Profiles
- Comprehensive company information
- Industry classification and sector analysis
- Company description and business overview
- Key company metrics and statistics

### 💼 Portfolio Management
- Create and manage multiple portfolios
- Add/remove stocks from portfolios
- Portfolio performance tracking
- Portfolio diversification analysis
- Real-time portfolio value updates

### 🔐 User Authentication & Authorization
- JWT-based authentication system
- User registration and login
- Role-based access control
- Secure password requirements
- Session management

### 📱 Modern UI/UX
- Responsive design with Tailwind CSS
- Interactive charts and data visualization
- Real-time data updates
- Intuitive navigation and user experience
- Loading states and error handling

## 🛠️ Tech Stack

### Backend (.NET 8)
- **Framework**: ASP.NET Core 8.0
- **Database**: SQL Server with Entity Framework Core
- **Authentication**: JWT Bearer tokens with ASP.NET Core Identity
- **API Documentation**: Swagger/OpenAPI
- **External APIs**: Financial Modeling Prep (FMP) API
- **Architecture**: Repository pattern with dependency injection

### Frontend (React + TypeScript)
- **Framework**: React 18 with TypeScript
- **Build Tool**: Vite
- **Styling**: Tailwind CSS
- **State Management**: React Context API
- **Routing**: React Router DOM
- **HTTP Client**: Axios
- **Charts**: Chart.js with react-chartjs-2
- **Forms**: React Hook Form with Yup validation
- **UI Components**: React Icons, React Spinners, React Toastify

### Development Tools
- **Testing**: Vitest with Testing Library
- **Linting**: ESLint with TypeScript support
- **Package Manager**: npm
- **Version Control**: Git

## 🚀 Getting Started

### Prerequisites
- .NET 8 SDK
- SQL Server (or SQL Server Express)
- Node.js 18+ and npm
- Git

### Backend Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/thefoenixweb/financeapp.git
   cd FinanceApp/api
   ```

2. **Configure the database connection**
   - Update the connection string in `appsettings.json` or `appsettings.Development.json`
   - Ensure SQL Server is running and accessible

3. **Install dependencies and run migrations**
   ```bash
   dotnet restore
   dotnet ef database update
   ```

4. **Configure external API keys**
   - Add your Financial Modeling Prep API key to `appsettings.json`:
   ```json
   {
     "FMPApiKey": "your_fmp_api_key_here"
   }
   ```

5. **Run the API**
   ```bash
   dotnet run
   ```
   The API will be available at `http://localhost:5167` (or your configured port)

### Frontend Setup

1. **Navigate to the frontend directory**
   ```bash
   cd ../frontend
   ```

2. **Install dependencies**
   ```bash
   npm install
   ```

3. **Configure environment variables**
   - Create a `.env` file in the frontend directory
   - Add your API base URL:
   ```
   VITE_API_BASE_URL=http://localhost:5167
   ```

4. **Run the development server**
   ```bash
   npm run dev
   ```
   The frontend will be available at `http://localhost:3000`



## 🔧 API Endpoints

### Authentication
- `POST /api/Account/register` - User registration
- `POST /api/Account/login` - User login
- `POST /api/Account/refresh-token` - Refresh JWT token

### Stocks
- `GET /api/Stock` - Get all stocks
- `GET /api/Stock/{symbol}` - Get stock by symbol
- `POST /api/Stock` - Create new stock
- `PUT /api/Stock/{id}` - Update stock
- `DELETE /api/Stock/{id}` - Delete stock

### Portfolios
- `GET /api/Portfolio` - Get user portfolios
- `POST /api/Portfolio` - Create portfolio
- `PUT /api/Portfolio/{id}` - Update portfolio
- `DELETE /api/Portfolio/{id}` - Delete portfolio

### Financial Statements
- `GET /api/FinancialStatement/{symbol}` - Get financial statements
- `GET /api/CashFlowStatement/{symbol}` - Get cash flow statements
- `GET /api/IncomeStatement/{symbol}` - Get income statements
- `GET /api/BalanceSheetStatement/{symbol}` - Get balance sheet statements

### Company Profiles
- `GET /api/CompanyProfile/{symbol}` - Get company profile





## 🙏 Acknowledgments

- [Financial Modeling Prep](https://financialmodelingprep.com/) for providing financial data APIs


