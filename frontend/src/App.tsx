import { Outlet } from 'react-router-dom';
import Sidebar from './Components/Sidebar/Sidebar';
import { UserProvider } from './Context/useAuth';
import { ThemeProvider } from './Context/ThemeContext';
import { StockProvider } from './Context/StockContext';
import { PortfolioProvider } from './Context/PortfolioContext';
import { MarketProvider } from './Context/MarketContext';
import ErrorBoundary from './Components/ErrorBoundary';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import './App.css';

function App() {
  return (
    <ErrorBoundary>
      <ThemeProvider>
        <UserProvider>
          <StockProvider>
            <PortfolioProvider>
              <MarketProvider>
                <div className="app flex">
                  <Sidebar />
                  <main className="main-content ml-64 flex-1">
                    <Outlet />
                  </main>
                </div>
                <ToastContainer />
              </MarketProvider>
            </PortfolioProvider>
          </StockProvider>
        </UserProvider>
      </ThemeProvider>
    </ErrorBoundary>
  );
}

export default App;
