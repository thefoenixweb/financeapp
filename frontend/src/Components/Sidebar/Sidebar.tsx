import React, { useEffect, useState } from 'react'
import { Link, useLocation, useParams, useNavigate } from 'react-router-dom'
import { FaHome } from 'react-icons/fa'
import logo from '../NavBar/logo.png'

interface Props {}

const Sidebar = (props: Props) => {
  const location = useLocation();
  const params = useParams<{ ticker: string }>();
  const navigate = useNavigate();
  const [ticker, setTicker] = useState<string | undefined>();

  useEffect(() => {
    if (!params.ticker) {
      setTicker(undefined);
      return;
    }

    if (params.ticker === '[object Object]') {
      setTicker(undefined);
      return;
    }
    
    try {
      const parsedTicker = JSON.parse(params.ticker);
      const extractedTicker = typeof parsedTicker === 'object' && parsedTicker !== null && 'symbol' in parsedTicker 
        ? parsedTicker.symbol 
        : params.ticker;
      
      setTicker(extractedTicker);
    } catch {
      setTicker(params.ticker);
    }
  }, [params.ticker]);

  const handleNavigation = (path: string) => {
    if (!ticker) return;
    navigate(`/company/${ticker}/${path}`);
  };

  const isActive = (path: string) => {
    if (!ticker) return false;
    const currentPath = location.pathname;
    const targetPath = `/company/${ticker}/${path}`;
    return currentPath === targetPath;
  };

  return (
    <div className="fixed left-0 top-0 h-full w-64 shadow-lg bg-neutral-900 text-neutral-100 light-mode:bg-white light-mode:text-neutral-900 z-[9999] pointer-events-auto">
      {/* Header */}
      <Link 
        to="/" 
        className="flex items-center space-x-3 p-6 border-b border-neutral-700 light-mode:border-neutral-300 hover:bg-neutral-800 light-mode:hover:bg-neutral-50 transition-colors cursor-pointer"
      >
        <img src={logo} alt="Finance App Logo" className="w-8 h-8" />
        <h1 className="text-xl font-bold text-neutral-100 light-mode:text-neutral-800">Finance App</h1>
      </Link>

      {/* Navigation Tabs */}
      <nav className="p-4">
        <ul className="space-y-2">
          <li>
            <Link
              to="/dashboard"
              className={`flex items-center space-x-3 px-4 py-3 rounded-lg transition-colors ${
                location.pathname === '/dashboard'
                  ? 'bg-primary-gold text-white light-mode:bg-primary-green light-mode:text-white'
                  : 'text-neutral-400 hover:bg-neutral-800 light-mode:text-neutral-600 light-mode:hover:bg-neutral-50'
              }`}
            >
              <svg
                className="w-5 h-5"
                fill="none"
                stroke="currentColor"
                viewBox="0 0 24 24"
              >
                <path
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  strokeWidth={2}
                  d="M3 12l2-2m0 0l7-7 7 7M5 10v10a1 1 0 001 1h3m10-11l2 2m-2-2v10a1 1 0 01-1 1h-3m-6 0a1 1 0 001-1v-4a1 1 0 011-1h2a1 1 0 011 1v4a1 1 0 001 1m-6 0h6"
                />
              </svg>
              <span>Dashboard</span>
            </Link>
          </li>
          <li>
            <Link
              to="/stocks"
              className={`flex items-center space-x-3 px-4 py-3 rounded-lg transition-colors ${
                location.pathname === '/stocks'
                  ? 'bg-primary-gold text-white light-mode:bg-primary-green light-mode:text-white'
                  : 'text-neutral-400 hover:bg-neutral-800 light-mode:text-neutral-600 light-mode:hover:bg-neutral-50'
              }`}
            >
              <svg
                className="w-5 h-5"
                fill="none"
                stroke="currentColor"
                viewBox="0 0 24 24"
              >
                <path
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  strokeWidth={2}
                  d="M9 19v-6a2 2 0 00-2-2H5a2 2 0 00-2 2v6a2 2 0 002 2h2a2 2 0 002-2zm0 0V9a2 2 0 012-2h2a2 2 0 012 2v10m-6 0a2 2 0 002 2h2a2 2 0 002-2m0 0V5a2 2 0 012-2h2a2 2 0 012 2v14a2 2 0 01-2 2h-2a2 2 0 01-2-2z"
                />
              </svg>
              <span>Stocks</span>
            </Link>
          </li>
          {ticker && (
            <>
              <li>
                <button
                  onClick={() => handleNavigation('company-profile')}
                  className={`w-full flex items-center space-x-3 px-4 py-3 rounded-lg transition-colors ${
                    isActive('company-profile')
                      ? 'bg-primary-gold text-white light-mode:bg-primary-green light-mode:text-white'
                      : 'text-neutral-400 hover:bg-neutral-800 light-mode:text-neutral-600 light-mode:hover:bg-neutral-50'
                  }`}
                >
                  <svg
                    className="w-5 h-5"
                    fill="none"
                    stroke="currentColor"
                    viewBox="0 0 24 24"
                  >
                    <path
                      strokeLinecap="round"
                      strokeLinejoin="round"
                      strokeWidth={2}
                      d="M9 19v-6a2 2 0 00-2-2H5a2 2 0 00-2 2v6a2 2 0 002 2h2a2 2 0 002-2zm0 0V9a2 2 0 012-2h2a2 2 0 012 2v10m-6 0a2 2 0 002 2h2a2 2 0 002-2m0 0V5a2 2 0 012-2h2a2 2 0 012 2v14a2 2 0 01-2 2h-2a2 2 0 01-2-2z"
                    />
                  </svg>
                  <span>Company Profile</span>
                </button>
              </li>
              <li>
                <button
                  onClick={() => handleNavigation('income-statement')}
                  className={`w-full flex items-center space-x-3 px-4 py-3 rounded-lg transition-colors ${
                    isActive('income-statement')
                      ? 'bg-primary-gold text-white light-mode:bg-primary-green light-mode:text-white'
                      : 'text-neutral-400 hover:bg-neutral-800 light-mode:text-neutral-600 light-mode:hover:bg-neutral-50'
                  }`}
                >
                  <svg
                    className="w-5 h-5"
                    fill="none"
                    stroke="currentColor"
                    viewBox="0 0 24 24"
                  >
                    <path
                      strokeLinecap="round"
                      strokeLinejoin="round"
                      strokeWidth={2}
                      d="M9 19v-6a2 2 0 00-2-2H5a2 2 0 00-2 2v6a2 2 0 002 2h2a2 2 0 002-2zm0 0V9a2 2 0 012-2h2a2 2 0 012 2v10m-6 0a2 2 0 002 2h2a2 2 0 002-2m0 0V5a2 2 0 012-2h2a2 2 0 012 2v14a2 2 0 01-2 2h-2a2 2 0 01-2-2z"
                    />
                  </svg>
                  <span>Income Statement</span>
                </button>
              </li>
              <li>
                <button
                  onClick={() => handleNavigation('balance-sheet')}
                  className={`w-full flex items-center space-x-3 px-4 py-3 rounded-lg transition-colors ${
                    isActive('balance-sheet')
                      ? 'bg-primary-gold text-white light-mode:bg-primary-green light-mode:text-white'
                      : 'text-neutral-400 hover:bg-neutral-800 light-mode:text-neutral-600 light-mode:hover:bg-neutral-50'
                  }`}
                >
                  <svg
                    className="w-5 h-5"
                    fill="none"
                    stroke="currentColor"
                    viewBox="0 0 24 24"
                  >
                    <path
                      strokeLinecap="round"
                      strokeLinejoin="round"
                      strokeWidth={2}
                      d="M12 6V4m0 2a2 2 0 00-2 2v10a2 2 0 002 2m0-12a2 2 0 012 2v10a2 2 0 01-2 2m-6 0h12a2 2 0 002-2V8a2 2 0 00-2-2H6a2 2 0 00-2 2v10a2 2 0 002 2z"
                    />
                  </svg>
                  <span>Balance Sheet</span>
                </button>
              </li>
              <li>
                <button
                  onClick={() => handleNavigation('cashflow-statement')}
                  className={`w-full flex items-center space-x-3 px-4 py-3 rounded-lg transition-colors ${
                    isActive('cashflow-statement')
                      ? 'bg-primary-gold text-white light-mode:bg-primary-green light-mode:text-white'
                      : 'text-neutral-400 hover:bg-neutral-800 light-mode:text-neutral-600 light-mode:hover:bg-neutral-50'
                  }`}
                >
                  <svg
                    className="w-5 h-5"
                    fill="none"
                    stroke="currentColor"
                    viewBox="0 0 24 24"
                  >
                    <path
                      strokeLinecap="round"
                      strokeLinejoin="round"
                      strokeWidth={2}
                      d="M9 17v-2m3 2v-4m3 4v-6m2 10H7a2 2 0 01-2-2V5a2 2 0 012-2h5.586a1 1 0 01.707.293l5.414 5.414a1 1 0 01.293.707V19a2 2 0 01-2 2z"
                    />
                  </svg>
                  <span>Cashflow Statement</span>
                </button>
              </li>
            </>
          )}
          <li>
            <Link
              to="/contact"
              className={`flex items-center space-x-3 px-4 py-3 rounded-lg transition-colors ${
                location.pathname === '/contact'
                  ? 'bg-primary-gold text-white light-mode:bg-primary-green light-mode:text-white'
                  : 'text-neutral-400 hover:bg-neutral-800 light-mode:text-neutral-600 light-mode:hover:bg-neutral-50'
              }`}
            >
              <svg
                className="w-5 h-5"
                fill="none"
                stroke="currentColor"
                viewBox="0 0 24 24"
              >
                <path
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  strokeWidth={2}
                  d="M3 8l7.89 5.26a2 2 0 002.22 0L21 8M5 19h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v10a2 2 0 002 2z"
                />
              </svg>
              <span>Contact</span>
            </Link>
          </li>
        </ul>
      </nav>
    </div>
  )
}

export default Sidebar